# Next Task — VANO: Last Ride

## Task

**Assemble and test Milestone 1 prototype in Unity Editor.**

Milestone 1 code is implemented under `VANO/UnityProject/`. It has NOT been compiled or tested (no Unity Editor available in this environment). Next step is Editor verification and tuning.

## Scope

1. Open `VANO/UnityProject` in Unity 2022.3 LTS.
2. Follow `VANO/UnityProject/SCENE_SETUP.md` to assemble the scene.
3. Create 4 VehicleData assets and assign to TransformationController.
4. Compile and fix any errors.
5. Play-test: downhill feel, steering, jump, slide, drift, transform, crystal collection, obstacle crash, restart.
6. Tune PlayerController values for game feel.
7. Record test results in `COMPLETED_TASKS.md` and issues in `KNOWN_ISSUES.md`.

## Acceptance criteria

- Project compiles without errors.
- Prototype runs and demonstrates downhill snowboarding feel.
- No three-lane system; free movement.
- Transform (double-tap) works without interfering with steering.
- Crash -> game over -> restart works.

## Not in scope

- Final art / production assets.
- Economy numbers.
- Leaderboards / challenges / ads.