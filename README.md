# GameFactory

A Godot co-op foundation with server-authoritative shared gameplay, Steam sessions
and Netfox movement. Reusable mechanisms and the working reference experience
are supplied under [factory/](factory/README.md).

- [Current state](factory/docs/current-state.md)
- [Ownership and placement](factory/docs/ownership.md)
- [Consuming GameFactory](factory/docs/consuming-gamefactory.md)
- [v0.2 ownership migration](factory/docs/v0.2-ownership-migration.md)
- [Agent routing](AGENTS.md)

Games own product code under `game/`; `addons/` and `third_party/` contain vendor
material. Root project, solution and export settings are shared integration.
The starter is a complete example, not a required player or gameplay model.

Build and test with `dotnet build GameFactory.sln` and `dotnet test GameFactory.sln`.
Local validation tools live in `factory/tools/`; focused runtime probes live in
`factory/sandbox/` and preserve evidence under `factory/artifacts/`.
