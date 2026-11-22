# Game Design — VANO: Last Ride

## 1. Characters

| Character | Role | Notes |
|---|---|---|
| Mikiy | First male character | Equal gameplay abilities |
| Lina | Female character | Equal gameplay abilities |

Rules:
- Characters have **equal gameplay abilities**. Differences are cosmetic/identity only.
- No character may have a gameplay advantage (speed, handling, crash tolerance, reward multipliers tied to power).
- Character purchases are a monetization sink; they must not be Pay-to-Win.

**OPEN DECISIONS:** backstories, visual design specifics, unlock order, pricing, whether more characters are planned for v1.

## 2. Vehicles (transformation system)

The player starts with a regular snowboard. Via a **double-tap** action, the player transforms into another snow vehicle.

| Vehicle | Intended feel | Status |
|---|---|---|
| Regular Snowboard | Baseline handling, balanced | Starting vehicle |
| Big Snowboard | More stability / different drift profile | Planned |
| Snow Sled | Different control feel (e.g., slide-heavy) | Planned |
| Snowmobile | Higher speed / different handling | Planned |

Rules:
- Each vehicle has **different characteristics** and a **balanced usage duration**.
- Transformation is not a permanent upgrade; durations are balanced so no single vehicle dominates.
- Vehicle stats and durations are **OPEN DECISIONS** — to be defined and validated in prototype (see `KNOWN_ISSUES.md`).

## 3. Environment

- Snowy mountains, open terrain (no fixed three-lane system).
- Free movement across the mountain.
- Procedural, endless generation.
- Visual identity: cartoon 3D, original, recognizable. Avoid generic snow templates.

**OPEN DECISIONS:** biome variety, weather, time-of-day, landmark sets, generation rules (chunk size, seed handling for friends challenges).

## 4. Core gameplay loop

1. Start run (select character/vehicle cosmetic).
2. Descend, steer, drift, jump, slide.
3. Collect crystals, avoid obstacles.
4. Speed and difficulty increase.
5. Transform vehicles as needed (double-tap).
6. Crash or finish segment → score + crystals.
7. Optional: continue after crash via rewarded ad.
8. Spend crystals on characters/cosmetics; chase leaderboards; complete daily/friends challenges.

## 5. Game modes

| Mode | Description |
|---|---|
| Offline Endless Mode | Single-player endless run, offline-capable scoring. |
| Daily Challenges | A generated track/challenge refreshed daily. |
| Friends Challenges | Same generated track shared among friends for fair comparison. |
| Weekly Leaderboards | Reset weekly. |
| All-Time Leaderboards | Persistent. |

Notes:
- Friends challenges rely on **deterministic track generation from a shared seed** (technical requirement — see `TECHNICAL_ARCHITECTURE.md`).
- Leaderboard anti-cheat and validation approach is an **OPEN DECISION**.

## 6. Progression

- Crystal currency earned in runs.
- Purchasable: characters, cosmetic vehicle customization.
- No gameplay power progression for money.
- Skill-based mastery via leaderboards and challenges.

**OPEN DECISIONS:** XP/level system (if any), unlock gates, daily reward structure.

## 7. Monetization (summary)

- Optional rewarded ads: continue after crash; double crystal rewards.
- Character purchases.
- Cosmetic vehicle customization.
- Remove Ads purchase.
- Avoid Pay-to-Win.

Details in `ECONOMY.md`.

## 8. Identity / art direction (high level)

- Cartoon 3D, original and recognizable.
- Distinct character silhouettes (Mikiy, Lina).
- Readable gameplay: obstacles and collectibles clearly distinguishable at speed.
- Avoid visual clutter and unnecessary effects (also a performance requirement).

**OPEN DECISIONS:** style guide, color palette, reference mood board, naming/branding of UI. These must be resolved before production art.