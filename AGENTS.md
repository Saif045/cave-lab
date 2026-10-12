# Repository ownership router

- Work under `factory/**`: read [factory/AGENTS.md](factory/AGENTS.md), then the
  nearest scoped guide. GameFactory maintains all first-party foundation,
  starter, verification, tooling, documentation and evidence here.
- Work under `game/**`: read `game/AGENTS.md` when present. The downstream game
  owns product behavior and content; this upstream repository has no game yet.
- Shared root integration changes: read the relevant factory and game guides
  and reconcile both requirements. Root project/solution/export configuration
  is shared integration; `addons/**` and `third_party/**` are vendor material.

For ambiguous placement, read [ownership](factory/docs/ownership.md). Keep agent
context narrow: do not recursively load every guide, starter document or
historical acceptance record. Preserve unrelated changes; use focused commits.
