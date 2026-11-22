# Roadmap — VANO: Last Ride

Phases are sequential but may overlap. Each task must be small and testable.

## Phase 0 — Documentation & decisions (current)
- [x] Create documentation & project management system.
- [ ] Resolve open design decisions (see `KNOWN_ISSUES.md`).
- [ ] Produce art direction brief (style guide, palette, typography, logo direction).
- [ ] Pin Unity version and render pipeline.

Exit criteria: open decisions list reduced to "deferred to prototype" only; art direction brief approved.

## Phase 1 — Project setup
- [ ] Create Unity project with agreed structure.
- [ ] Configure version control (Git + LFS).
- [ ] Set up CI/build pipeline for Android.
- [ ] Baseline performance profiling setup.

## Phase 2 — Core movement prototype
- [ ] Minimal test scene.
- [ ] Baseline snowboard movement: steering, drifting, jumping, sliding.
- [ ] Playtest and tune feel.
- [ ] Validate control scheme.

## Phase 3 — Transformation system
- [ ] Implement vehicle switching via double-tap.
- [ ] Implement per-vehicle characteristics and durations.
- [ ] Balance and playtest.

## Phase 4 — Environment & procedural generation
- [ ] Terrain streaming.
- [ ] Obstacle sets with difficulty scaling.
- [ ] Deterministic seeded generation.
- [ ] Collectibles placement.

## Phase 5 — Scoring, economy, persistence
- [ ] Scoring formula.
- [ ] Crystal economy.
- [ ] Local persistence.
- [ ] Shop (characters, cosmetics, Remove Ads).

## Phase 6 — Modes & services
- [ ] Daily challenges.
- [ ] Friends challenges (shared seed).
- [ ] Leaderboards (weekly, all-time).
- [ ] Ad integration (rewarded).

## Phase 7 — UI/UX & identity
- [ ] All screens per `UI_UX.md`.
- [ ] Original visual identity applied.
- [ ] Accessibility options.

## Phase 8 — Polish & launch
- [ ] Performance optimization on low/mid Android.
- [ ] Bug fixing, balance.
- [ ] Store assets, listing.
- [ ] Release.

## Phase 9 — Live ops
- [ ] Content updates, new cosmetics/characters.
- [ ] Event challenges.
- [ ] Economy tuning from telemetry.

## Notes
- No gameplay has been built yet.
- Tasks must remain small and testable; split if a task cannot be validated in one session.