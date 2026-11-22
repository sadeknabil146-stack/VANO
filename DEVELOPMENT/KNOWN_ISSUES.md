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

## Resolved

_(none yet)_