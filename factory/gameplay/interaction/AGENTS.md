# Interaction scope

Read [../AGENTS.md](../AGENTS.md) for the Task A interaction invariants and
the interaction section of [consumer guidance](../../../docs/consuming-gamefactory.md#composing-player-independent-interaction)
for composition/migration. For pickup target/holder changes, read only
[carry/README.md](../carry/README.md) in addition to those interaction rules.

Keep actor permission independent of target rules, GAS and player classes.
The client supplies only target NetworkObjectId; the server resolves and
validates sender/represented owner, permission, self-target, range and target.
Local CanInteract is a side-effect-free hint; server dispatch is decisive.
