# Default reference composition

`shell/online_gameplay.tscn` composes the reusable OnlineGameplayShell and
OnlineGameplayWorld with `StarterRoundContent`, `StarterPlayerSpawnDataProvider`
and `player/network_player_3d.tscn`. The player composes Netfox movement,
interaction and carry permissions, inventory/equipment, GAS/vitals and revive.
Round content spawns the sample switch and carryable cube. It is a complete
working default, not a required superclass or gameplay model for consumers.

| Path | Reference responsibility |
| --- | --- |
| `player/` | NetworkPlayer3D, input, simulation, camera and presentation |
| `gameplay/gas/` | Health, Stamina, Sprint, Dash, Fortify, Downed, Dead, Respawn and their replicated player projections |
| `gameplay/inventory/` | One-slot storage and equipment semantics |
| `gameplay/interaction/` | GAS permission, instant revive and sample switch |
| `gameplay/carry/` | GAS permission and inventory-aware CarryableItem cube |
| `shell/` | Default round content, spawn data, gameplay scene and configured GameShell autoload scene |

GodotGAS interop in GodotGasAdapter/NetworkGasComponent is specific to this
starter's vitality and equipment model; it is not a generic factory GAS API.
Reusable contracts remain under `factory/gameplay`, `factory/networking` and
`factory/shell`. See their scoped guides when replacing a mechanism, and
[the ownership migration](../docs/v0.2-ownership-migration.md) when updating
existing scenes, namespaces or scripts.

The GodotGAS registries and generated tags are in `gameplay/gas/resources/`.
All five addon resource paths are explicitly configured in `project.godot`;
the addon has no root-directory requirement. Games choose their own GAS data
paths and semantics. Root Maaack/Steam/Netfox autoload and input settings remain
shared project integration.
