# Scene Setup Guide — VANO Prototype

Unity Editor is not available in this environment, so the scene must be assembled in the Unity Editor. Follow these steps.

## 1. Open project
Open `VANO/UnityProject` in Unity 2022.3 LTS (URP recommended later).

## 2. Project Settings
- Player -> Active Input Handling: **Both** (or Input Manager (Old)).
- Tags: add "Player", "Crystal", "Obstacle".

## 3. Create ground
- Create a Plane (or Terrain) sloped ~15-25 degrees along Z. Scale to cover play area.
- Add a Collider (already on Plane).
- Material: white/light-blue snow (Standard or URP/Lit).

## 4. Player
- Create an empty GameObject "Player", tag "Player".
- Add CapsuleCollider (height 1.8, radius 0.4).
- Add Rigidbody (mass 1, freeze rotation X/Z).
- Add components: PlayerInput, PlayerController, TransformationController.
- Assign PlayerInput reference in PlayerController and TransformationController.
- Create 4 VehicleData assets (Assets/_Project/Data): Standard, Big, Snow Sled, Snowmobile. Fill stats from the table in GAME_DESIGN.md / this prototype's VehicleData defaults. Assign to TransformationController.vehicles (index 0 = Standard).

## 5. Camera
- Main Camera: add ThirdPersonCamera, assign target = Player, player = PlayerController.

## 6. Lighting & environment
- Directional Light (sun) warm white.
- Skybox: light blue.
- Add simple obstacles (cubes) tagged "Obstacle" with Obstacle component.
- Place a few crystals (spheres) tagged "Crystal" with Crystal component, or rely on SpawnManager.

## 7. Spawner
- Empty GameObject "Spawner" with SpawnManager. Assign player, crystal prefab, obstacle prefab.

## 8. Managers
- Empty GameObject "Managers" with GameManager and ScoreManager.

## 9. Prefabs
- Crystal prefab: sphere + Crystal component + trigger collider + tag "Crystal".
- Obstacle prefab: cube + Obstacle component + collider + tag "Obstacle".

## 10. Test
- Press Play. Steer with mouse (left/right halves). Space? Use mouse drag up to jump, down to slide. Double-click to transform.
- Verify: downhill acceleration, steering, jump, slide, drift, crystal collection, crash -> game over, restart via GameManager.Restart().

Notes: This prototype is code-complete but untested in Unity Editor (no Editor available in this environment).