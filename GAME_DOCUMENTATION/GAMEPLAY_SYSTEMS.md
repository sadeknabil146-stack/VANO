# Gameplay Systems — VANO: Last Ride

This document describes gameplay *systems and behaviors*, not implementation. No code.

## 1. Movement

- Free movement across an open snowy mountain (no fixed lanes).
- Snowboard downhill movement as the baseline.
- Smooth steering and drifting.
- Jumping and sliding.
- Speed and difficulty increase over time/distance.

Design goals:
- Responsive, readable, skill-based.
- Fair crashes: the player must be able to see and react to obstacles.

## 2. Steering

- Continuous steering input (touch/tilt/onscreen — **OPEN DECISION** on control scheme).
- Steering sensitivity may vary by vehicle.
- Must remain controllable at high speed.

## 3. Drifting

- Drifting is a skill mechanic: rewards control and cornering.
- Drift feel must be weighty and intentional, not slippery.
- Drift behavior may vary by vehicle.

**OPEN DECISIONS:** drift trigger (input gesture), drift boost (if any), scoring for drift.

## 4. Jumping

- Jump height/trajectory tuned per vehicle.
- Jumping used to clear obstacles and gaps.
- Landing stability matters (crash on bad landing? **OPEN DECISION**).

## 5. Sliding

- Sliding as a distinct action (e.g., speed control / obstacle avoidance).
- Interaction with terrain and obstacles TBD.

## 6. Speed and difficulty scaling

- Speed increases over time/distance.
- Difficulty increases via obstacle density/variety and terrain.
- Curve must be tuned for retention (not too punishing early, not too flat late).

**OPEN DECISIONS:** exact curve, caps, difficulty bands, rubber-banding for new players.

## 7. Transformation system

- Trigger: **double-tap** action.
- Transforms current vehicle into another snow vehicle.
- Each vehicle has different characteristics and a balanced usage duration.
- Transformation should feel impactful but not chaotic.

**OPEN DECISIONS:** which vehicle transforms to which (cycle vs. selection), cooldown, duration per vehicle, visual transition, invulnerability during transform (if any), whether transform can be used mid-air.

## 8. Endless procedural environment

- Terrain and obstacles generated ahead of the player.
- Must support deterministic generation from a seed (for friends challenges).
- Performance: avoid hitches; stream chunks.

**OPEN DECISIONS:** chunk size, generation algorithm, obstacle sets, biome rules, seed format, distance-to-generate threshold.

## 9. Collectibles

- Crystals as primary currency.
- Placement must reward skill/risk (e.g., risky lines).
- Crystal value and double-reward (ad) interaction defined in `ECONOMY.md`.

## 10. Obstacles

- Readable at speed; fair avoidance.
- Variety increases with difficulty.
- Obstacle sets per vehicle/terrain TBD.

**OPEN DECISIONS:** obstacle types, collision consequences (crash vs. slowdown), warning telegraphing.

## 11. Scoring

- Distance-based plus collectibles.
- Leaderboard submission rules TBD (validation, offline runs).

**OPEN DECISIONS:** score formula, whether offline runs count for leaderboards, anti-cheat.

## 12. Crash and continue

- Crash ends the run unless player uses rewarded ad to continue.
- Continue flow must feel like a choice, not a tax.
- Number of continues per run TBD.

## 13. Testing requirement

No gameplay system may be marked complete without playtesting. Movement feel requires hands-on validation; numbers alone are insufficient.