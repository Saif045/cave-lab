# Gameplay Networking Scope

Read this guide for gameplay code layered on the networking foundation. Keep a
feature's rules and state ownership explicit; do not introduce a generic
ability, command, event-bus, or progression framework for one slice.

Each topic has one canonical documentation home beside its code; routing
guides specify the minimum reading set. Repository documentation may be
extensive, but agent context stays task-scoped. Read unrelated topics only
when the task crosses their boundary. For carry, continue to
`carry/AGENTS.md` and `carry/README.md`; do not duplicate that mechanism guide
in a central docs tree.

Use this default choice:

| Need | Mechanism |
|---|---|
| Continuous latency-sensitive player simulation | Netfox rollback |
| Discrete request to server | Reliable RPC plus server validation |
| Ordinary authoritative state | `ReplicationComponent` / `MultiplayerSynchronizer` |
| Spawn/despawn | `NetworkWorld` / `MultiplayerSpawner` |

For interaction, a client chooses a target locally but sends only a
`NetworkObjectId`; the server resolves it through `NetworkWorld` and validates
the sender, represented player, target, range, and current interactability.
The client never authoritatively changes a target's state. Do not put switches,
doors, pickups, or inventory into player rollback history without concrete
evidence.

Interaction owns target request routing and authoritative network validation.
Actor-state permission belongs to the starter/game composition through
`IInteractionPermission.CanRequestInteraction(NetworkObject, PeerId)`.
`PlayerInteractor.PermissionPath` must explicitly reference a policy node;
missing, empty, or wrong-type configuration fails closed. Actors without a
vitality model compose an explicit permissive policy. Do not add default-player
GAS, incapacitation, or revive dependencies to the reusable interactor.
The default player composes `StarterPlayerInteractionPermission`, which checks
canonical GAS on the server and vital projections locally.

Games can set `EnableDefaultInput=false` and call
`RequestInteraction(NetworkObjectId)` from their own input/target selection.
The default convenience retains `interact` and nearest local candidate selection.
Both request paths use the same reliable RPC/server validation. Policy checks
are actor-only; target rules stay in `IInteractable.CanInteract`.
Local policy/CanInteract checks are side-effect-free availability hints, never
authorization. `InteractionContext.ServerPlayerPosition` is local during
candidate selection and authoritative only in the server dispatch. Revive is
starter/reference gameplay and keeps its own vital semantics.

Presentation is deterministic/local where possible. Owner-distinguishing
colors derive from owner metadata, are consistent on all peers, and are never
replicated or rolled back.

Read `factory/docs/architecture.md` for a cross-module ownership change and
`factory/docs/current-state.md` before claiming a gameplay slice acceptance-proven.

Starter-player vital tags are canonical server GAS state, projected through ordinary
replication; clients must not derive Downed/Dead from health. Gate gameplay
requests against canonical incapacitation as well as suppressing local input.
Netfox reads that gate but records only physical state and reset consumption,
never GAS tags/attributes. Normal death preserves stored/equipped items and
their source effects; player despawn must release hidden items to World and
remove equipment capabilities. In the player prefab, inventory must exit before
GAS so source removal can run against the live ASC.
