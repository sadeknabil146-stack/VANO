# Next Task — VANO: Last Ride

## Task

**Phase 0 exit work: resolve open design decisions and produce an art direction brief.**

Before any gameplay is built, close the Phase 0 open decisions so implementation does not rely on assumptions.

## Scope

1. Review `KNOWN_ISSUES.md` open decisions.
2. Decide and document (in the relevant doc + mark resolved in `KNOWN_ISSUES.md`):
   - Control scheme.
   - Vehicle stats/durations table (at least qualitative targets).
   - Transformation behavior (cycle/selection, cooldown, mid-air, invulnerability).
   - Speed/difficulty curve approach.
   - Unity version + render pipeline.
   - Min spec device + target FPS.
3. Produce a one-page art direction brief: style, palette, typography, logo direction, character silhouette notes. Must satisfy the "NO GENERIC AI DESIGN" rule.

## Acceptance criteria

- Each decided item is recorded in the appropriate `GAME_DOCUMENTATION/` file and marked resolved in `KNOWN_ISSUES.md`.
- Art direction brief exists and is reviewed against the creative rule.
- `CURRENT_STATUS.md` updated.
- No gameplay code written.

## Not in scope

- Building Unity project or gameplay.
- Final economy numbers (can be deferred to prototype tuning, but approach must be decided).

## Follow-up task (after this)

Build core movement prototype in a minimal test scene (Phase 2).