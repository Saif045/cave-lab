# Starter GAS interop

This starter owns its Health/Stamina and Sprint/Dash/Fortify abilities,
Downed/revive/Dead/Respawn lifecycle, movement/equipment projections and source-
owned equipment effects. GodotGasAdapter centralizes C#↔GDScript interop;
NetworkGasComponent projects this player model through ordinary replication.
Neither is a generic GameFactory GAS API or a required game base.

GodotGAS owns ability/attribute/effect/tag mechanics; GameFactory mechanisms own
network identity, authority, replication and session lifecycle. Netfox owns
physical movement/rollback. Canonical starter vitality stays on the server;
client vital projections suppress local requests. Inventory exits before GAS
so equipment capabilities can be removed while the ASC remains live.

Resources live in `resources/`, explicitly selected by the five project settings
listed in [migration notes](../../../docs/v0.2-ownership-migration.md).
Read only affected bridge/ability/adapter sources for a starter change. Route
network, interaction or carry mechanism changes to their own scoped guides.
