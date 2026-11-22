# UI / UX — VANO: Last Ride

## 1. Design principle: NO GENERIC AI DESIGN

The UI must not look like a generic AI-generated template. It must have an original, recognizable identity consistent with the game's cartoon-3D world.

Avoid:
- Generic interfaces and templates.
- Repetitive/generic logos.
- Default-looking buttons, panels, and HUDs.
- Unnecessary visual effects.

Every screen must be reviewed against this rule.

## 2. General UX principles

- Mobile-first: large touch targets, thumb-friendly zones.
- Readable at a glance while moving (HUD).
- Minimal friction to start a run.
- Clear feedback for collect, crash, transform, level-up.
- Consistent iconography and color meaning.
- Accessibility: colorblind-friendly cues, scalable text where feasible, reduced-motion option (**OPEN DECISION** on scope).

## 3. Screens (high level)

| Screen | Purpose |
|---|---|
| Splash / Logo | Brand identity moment (not generic). |
| Main Menu | Entry point: Play, Challenges, Leaderboards, Shop, Settings. |
| Character Select | Choose Mikiy/Lina and cosmetics. |
| Vehicle Select | Choose starting vehicle cosmetic. |
| Gameplay HUD | Score, distance, crystals, speed indicator, transform affordance. |
| Pause | Resume, restart, settings. |
| Crash / Results | Score, crystals earned, continue (ad) option, retry, share. |
| Shop | Characters, cosmetics, Remove Ads. |
| Leaderboards | Weekly / All-Time / Friends. |
| Challenges | Daily / Friends challenge entry. |
| Settings | Audio, controls, accessibility, account. |

## 4. HUD requirements

- Must not obstruct the play area / view of the mountain.
- Transform affordance (double-tap) must be discoverable without clutter.
- Crystal count and score readable at speed.

## 5. Visual identity notes

- Distinct character silhouettes for Mikiy and Lina.
- Color palette and typography are **OPEN DECISIONS** (must be defined in a style guide before production).
- Logo must be original and recognizable (not a generic template logo).

## 6. Interaction notes

- Control scheme (tilt vs. touch vs. hybrid) is an **OPEN DECISION** — affects all UI layout.
- Rewarded ad prompts must be opt-in and clearly labeled (value proposition shown).
- Remove Ads purchase must be clearly discoverable and not aggressive.

## 7. Performance constraints on UI

- UI must not cause frame drops.
- Avoid heavy effects/blur on low-end devices.