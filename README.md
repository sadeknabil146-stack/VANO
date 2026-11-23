# VANO: Last Ride

**3D Endless Downhill Adventure** — Android first.

> This repository currently contains the **project documentation and management system** only. No gameplay code, scenes, or assets have been created yet. The project is in the documentation / planning stage.

---

## Quick facts

| Item | Value |
|---|---|
| Game name | VANO: Last Ride |
| Engine | Unity |
| Language | C# |
| Platform | Android first |
| Genre | 3D Endless Downhill Adventure |
| Visual style | Cartoon 3D (original identity, not generic AI style) |
| Camera | Third-person |
| Environment | Snowy mountains |
| Characters | Mikiy (male), Lina (female) — equal abilities |
| Vehicles | Regular Snowboard, Big Snowboard, Snow Sled, Snowmobile |

## Documentation structure

```
VANO/
├── GAME_DOCUMENTATION/   # What the game is
│   ├── GAME_VISION.md
│   ├── GAME_DESIGN.md
│   ├── GAMEPLAY_SYSTEMS.md
│   ├── UI_UX.md
│   ├── ECONOMY.md
│   └── TECHNICAL_ARCHITECTURE.md
├── DEVELOPMENT/          # Where the project is
│   ├── ROADMAP.md
│   ├── CURRENT_STATUS.md
│   ├── COMPLETED_TASKS.md
│   ├── KNOWN_ISSUES.md
│   ├── NEXT_TASK.md
│   └── CHANGELOG.md
├── AI_INSTRUCTIONS/      # How to work on it
│   ├── PROJECT_RULES.md
│   └── MODEL_HANDOFF.md
└── README.md
```

## How to continue (AI models / developers)

1. Read `AI_INSTRUCTIONS/PROJECT_RULES.md`.
2. Read `DEVELOPMENT/CURRENT_STATUS.md`.
3. Read `DEVELOPMENT/NEXT_TASK.md`.
4. Read the relevant files under `GAME_DOCUMENTATION/`.
5. Do the work in small, testable steps.
6. Update `CURRENT_STATUS.md`, `COMPLETED_TASKS.md`, `CHANGELOG.md`, `NEXT_TASK.md`, and `KNOWN_ISSUES.md` before ending a session.

## Download (Android APK)

Latest dev build: [VANO.apk (v0.3.0)](https://github.com/sadeknabil146-stack/VANO/releases/download/v0.3.0/VANO.apk)

Install: enable "Install unknown apps" on Android, then open the APK.

## Current status

Milestone 1 complete: Unity project, playable prototype scene, Android APK built and uploaded. See `DEVELOPMENT/CURRENT_STATUS.md`.

## Important rules

- No generic AI design. The game must have an original, recognizable identity.
- No Pay-to-Win. Monetization must not affect competitive fairness.
- Characters have equal gameplay abilities.
- Never claim a feature is complete without testing it.
- Never delete or overwrite existing work without permission.

See `AI_INSTRUCTIONS/PROJECT_RULES.md` for the full rule set.