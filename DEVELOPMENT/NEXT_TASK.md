# Next Task — VANO: Last Ride

## Task

**Manual Play-test and tune Milestone 1 prototype.**

Milestone 1 is built and the Android APK exists (`Builds/VANO.apk`). The remaining work is hands-on gameplay feel tuning and iteration.

## Scope

1. Open `VANO/UnityProject` in Unity Editor.
2. Press Play; test downhill feel, steering, jump, slide, drift, transform, crystals, obstacles, crash, restart.
3. Tune `PlayerController` values (acceleration, steerTorque, jumpForce, friction, driftFriction, slopeBoost, gravityMultiplier).
4. Tune `ThirdPersonCamera` (offset, smooth, FOV).
5. Tune `SpawnManager` (intervals, lane width, despawn).
6. Verify HUD and restart flow.
7. Rebuild APK after tuning (`Vano > Build Android APK`).
8. Record findings in `COMPLETED_TASKS.md` / `KNOWN_ISSUES.md`.

## Acceptance criteria

- Prototype feels like downhill snowboarding (not flat movement).
- All 4 vehicles transform correctly via double-tap.
- No three-lane system; free movement.
- Crash -> game over -> restart works.
- APK builds successfully.

## Not in scope

- Final art / production assets.
- Economy numbers, leaderboards, ads, challenges.