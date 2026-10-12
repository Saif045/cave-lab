# GameFactory

GameFactory supplies server-authoritative co-op mechanisms and a working
[starter composition](starter/README.md). Games can compose the mechanisms
directly without inheriting starter player, inventory or GAS types.

| Area | Purpose |
| --- | --- |
| `runtime/`, `diagnostics/`, `networking/`, `steam/` | Runtime roles, evidence, identities, authority, replication and Steam lifecycle |
| `gameplay/`, `shell/` | Reusable interaction, carry and round/application lifecycle |
| `starter/` | Reference player, gameplay semantics and default composition |
| `sandbox/`, `tests/`, `tools/`, `artifacts/` | Probes, tests, development tooling and ignored evidence |
| `docs/` | Cross-cutting architecture, consumption, protocols and ADRs |

Start with [ownership](docs/ownership.md), [current state](docs/current-state.md)
or [consumer guidance](docs/consuming-gamefactory.md) for the relevant question.
[AGENTS.md](AGENTS.md) routes implementation work to a narrow reading set.
Detailed subsystem contracts stay beside their code; do not load every document
for a normal feature task. This remains one production assembly, not a plugin
or independently packaged module distribution.
