# Technical Architecture — VANO: Last Ride

High-level architecture only. No implementation code. Unity + C#, Android first.

## 1. Engine & platform

- Engine: Unity.
- Language: C#.
- Primary platform: Android.
- Secondary platforms: TBD (iOS later? **OPEN DECISION**).

## 2. Unity version & packages

- Unity LTS version: **OPEN DECISION** (pin a specific LTS and document it).
- Package list: **OPEN DECISION** (keep minimal; avoid unnecessary dependencies).

## 3. Project structure (proposed, to be finalized)

```
UnityProject/
├── Assets/
│   ├── _Project/          # Game code & content (underscore sorts first)
│   │   ├── Scripts/       # C# (organized by system)
│   │   ├── Scenes/
│   │   ├── Prefabs/
│   │   ├── Art/
│   │   ├── Audio/
│   │   └── Data/          # ScriptableObjects / config
│   ├── Plugins/
│   └── ...
├── Packages/
└── ProjectSettings/
```

Final structure to be decided during project setup.

## 4. Architectural principles

- Separate gameplay logic from presentation where practical.
- Data-driven configuration (ScriptableObjects) for vehicle stats, obstacle sets, economy values — enables tuning without code changes.
- Deterministic procedural generation from a seed (required for friends challenges).
- Keep systems small and testable (per AI continuity rules).

## 5. Core systems (planned)

- Input system (control scheme TBD).
- Movement / physics controller (per vehicle).
- Transformation system.
- Procedural terrain & obstacle streaming.
- Collectible system.
- Scoring system.
- Economy / persistence layer.
- Ad integration layer (abstracted behind an interface).
- Leaderboard / challenge service layer.
- UI layer.

## 6. Data persistence

- Local: player profile, settings, currency, unlocks, best scores, cached challenge seeds.
- Remote: leaderboards, friends challenges, daily challenge definitions.
- Offline Endless Mode must work fully offline; sync when online (**OPEN DECISION** on sync strategy).

## 7. Networking / services

- Leaderboards (weekly, all-time).
- Friends challenges (shared seed).
- Daily challenges (server-provided seed/config).
- Ad SDK integration.
- Analytics / telemetry (**OPEN DECISION** on provider and events).

## 8. Performance targets

- Smooth frame rate on mid-range Android devices (**OPEN DECISION**: target FPS and min spec device).
- Avoid hitches during chunk streaming.
- UI must not cause frame drops.
- Memory budget for low-end devices TBD.

## 9. Determinism requirement

Friends challenges require that a given seed produces the **same track** across devices. Generation must be deterministic and versioned; a generation version must be stored with each challenge so older challenges remain reproducible.

## 10. Testing strategy (high level)

- Unit tests for pure logic (scoring, economy, generation determinism).
- Play-mode tests for movement feel (manual + automated smoke).
- Device testing on low/mid/high Android.
- No feature marked complete without testing.

## 11. Open decisions

- Unity version, render pipeline (URP likely for mobile — **OPEN DECISION**).
- Physics approach (Unity physics vs. custom) — **OPEN DECISION**.
- Control scheme.
- Ad SDK and analytics provider.
- Backend for leaderboards/challenges (managed service vs. custom).
- Version control workflow (Git LFS for assets — recommended).