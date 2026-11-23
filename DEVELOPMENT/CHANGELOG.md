# Changelog — VANO: Last Ride

All notable changes to the project are recorded here. Format: [version] — date — summary.

## [0.1.0] — 2026-11-23

### Added
- Project documentation and management system under `VANO/`.
- `GAME_DOCUMENTATION/`: vision, design, gameplay systems, UI/UX, economy, technical architecture.
- `DEVELOPMENT/`: roadmap, current status, completed tasks, known issues, next task, changelog.
- `AI_INSTRUCTIONS/`: project rules, model handoff protocol.
- `README.md`.
- Language/communication rules (Egyptian Arabic) in `PROJECT_RULES.md`.

### Notes
- No gameplay implemented. Documentation stage only.

## [0.2.0] — 2026-11-23

### Added
- Unity project skeleton at `VANO/UnityProject/`.
- Milestone 1 prototype scripts (movement, input, camera, vehicles, transform, crystals, obstacles, spawner, game manager).
- Minimal `Prototype.unity` scene + `SCENE_SETUP.md`.

### Notes
- Code was not yet compiled or tested (no Unity Editor available at that time).

## [0.3.0] — 2026-11-23

### Added
- Unity Editor 2022.3.20f1 + Android modules installed on D:.
- Full playable scene assembled via `Editor/SceneAssembler.cs`.
- Editor/BuildScript.cs (Android APK build).
- UI scripts (HUDController, RestartButton).
- `.gitignore` for Unity.
- Android APK: `Builds/VANO.apk` (21 MB).

### Changed
- Manifest updated with all built-in modules (incl. Physics).
- Scripts fixed (removed trailing garbage; component-based tags).
- `CURRENT_STATUS.md`, `KNOWN_ISSUES.md`, `COMPLETED_TASKS.md`, `NEXT_TASK.md` updated.

### Fixed
- Compiler errors (Physics module missing, trailing garbage in files).

### Notes
- Compilation verified via batch mode. Android build succeeded. Gameplay feel requires manual Play in Editor.