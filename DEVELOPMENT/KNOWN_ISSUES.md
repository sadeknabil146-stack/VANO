# Known Issues / Open Decisions — VANO: Last Ride

This file tracks unresolved problems and open design decisions. Do not assume answers; resolve via documented decision.

## Open design decisions

### Gameplay
- Control scheme (tilt / touch / hybrid).
- Vehicle stats and durations (Regular Snowboard, Big Snowboard, Snow Sled, Snowmobile).
- Transformation cycle vs. selection; cooldown; mid-air transform; invulnerability during transform.
- Drift trigger, drift boost (if any), drift scoring.
- Jump landing consequences (crash on bad landing?).
- Sliding exact behavior.
- Speed/difficulty curve, caps, difficulty bands.
- Obstacle types, collision consequences, telegraphing.
- Scoring formula; offline run eligibility for leaderboards.
- Number of continues per run.

### Economy
- Exact crystal earn rates, prices, ad multipliers, daily reward values.
- XP/level system (if any), unlock gates, daily rewards.
- Remove Ads: whether rewarded ads remain available after purchase.
- Economy telemetry events.

### Technical
- Unity LTS version and render pipeline (URP likely).
- Physics approach (Unity vs. custom).
- Ad SDK and analytics provider.
- Backend for leaderboards/challenges.
- Sync strategy for offline runs.
- Performance targets (FPS, min spec device, memory budget).

### Content / identity
- Art direction: style guide, color palette, typography, logo.
- Character backstories, visual design, unlock order, pricing.
- Environment: biome variety, weather, time-of-day, landmark sets, generation rules.
- Leaderboard anti-cheat approach.

### Product
- iOS support and timing.
- More characters beyond Mikiy/Lina for v1.
- Success metric numeric targets (retention, session length, ad rates).

## Risks

- Movement feel cannot be validated on paper; prototype early.
- Deterministic generation for friends challenges is a hard technical requirement; design data model early.
- Identity risk: avoid generic AI look; requires art direction before production.
- Scope creep: keep tasks small and testable.

## Resolved (Milestone 1 decisions)

- Control scheme: Hybrid (touch zones default + optional joystick/tilt).
- Physics approach: Unity Physics (Rigidbody) for prototype.
- Drift: Hybrid (auto-drift at hard steering; manual boost deferred).
- Landing consequence: slowdown on poor landing (default); crash in high bands (deferred).
- Transformation: double-tap cycle; mid-air allowed; brief invulnerability 0.5s.
- Vehicle duration: time-based 10-15s; cooldown 2s.
- Collision (prototype): lethal obstacles cause crash; slowdown-for-minor deferred.
- Unity version: 2022.3 LTS (built-in render pipeline; URP recommended later).
- Generation (prototype): simple random spawner; deterministic seeded generation deferred to production.

## Still open

(see Open design decisions above; economy numbers, art direction, backend, anti-cheat, etc.)

## Blockers (Unity)

- **Unity login/license required.** Editor 2022.3.20f1 is installed on D: but no license is active. Personal license activation requires `unity auth login` (opens browser) and user credentials. Cannot proceed with Editor testing/import until the user logs in. Terms file for 2022.3.20f1 is also missing (`UnityEditorSoftwareTerms.rtf`), so `unity terms accept` failed; may need manual acceptance in Editor.