# Starter scope

Read [README.md](README.md) for reference composition and migration, then only
the affected player/gameplay/shell sources. For GAS changes continue to
`gameplay/gas/AGENTS.md`; for mechanism changes route to the corresponding
`factory/gameplay` or `factory/shell` guide.

Starter may use reusable mechanisms. Reusable code must not use starter or
game types/resources. Inventory, vitals, equipment effects, revive and sample
objects are reference semantics, never required game models. Keep presentation
outside rollback, GAS canonical on the server, and server spawning/identity in
NetworkWorld/PlayerLifecycle. Do not load all starter or historical probe docs.
