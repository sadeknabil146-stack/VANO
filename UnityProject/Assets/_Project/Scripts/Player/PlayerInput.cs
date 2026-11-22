using UnityEngine;
using System.Collections.Generic;

namespace Vano
{
    /// <summary>
    /// Mobile touch input for VANO. Provides steer axis, jump, slide and double-tap transform.
    /// Uses legacy Input so it works in the Unity Editor without Input System setup.
    /// Project Settings -> Player -> Active Input Handling should be "Both" or "Input Manager (Old)".
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public float SteerAxis { get; private set; }   // -1..1
        public bool JumpPressed { get; private set; }
        public bool SlideHeld { get; private set; }
        public bool TransformPressed { get; private set; }

        [Header("Tuning")]
        [SerializeField] private float doubleTapWindow = 0.25f;
        [SerializeField] private float swipeThreshold = 60f;
        [SerializeField] private float steerDeadzone = 0.05f;

        private float lastTapTime = -10f;
        private Vector2 swipeStart;
        private bool trackingSwipe;

        void Update()
        {
            SteerAxis = 0f;
            JumpPressed = false;
            SlideHeld = false;
            TransformPressed = false;

#if UNITY_EDITOR || UNITY_STANDALONE
            HandleMouse();
#else
            HandleTouches();
#endif
        }

        private void HandleTouches()
        {
            int touchCount = Input.touchCount;
            for (int i = 0; i < touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        swipeStart = t.position;
                        trackingSwipe = true;
                        lastTapTime = Time.time;
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        // Steer based on horizontal position relative to screen center.
                        float norm = (t.position.x / Screen.width) * 2f - 1f;
                        if (Mathf.Abs(norm) > steerDeadzone)
                            SteerAxis = Mathf.Clamp(norm, -1f, 1f);
                        break;
                    case TouchPhase.Ended:
                        if (trackingSwipe)
                        {
                            Vector2 delta = t.position - swipeStart;
                            if (delta.y > swipeThreshold) JumpPressed = true;
                            else if (delta.y < -swipeThreshold) SlideHeld = true; // treated as slide tap
                            // double tap detection
                            if (Time.time - lastTapTime < doubleTapWindow && Time.time - lastTapTime > 0.02f)
                            {
                                // second tap shortly after first
                                TransformPressed = true;
                            }
                        }
                        trackingSwipe = false;
                        break;
                }
            }
            // slide held: if a touch is held in lower part, keep sliding
            SlideHeld = SlideHeld || (touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary &&
                        Input.GetTouch(0).position.y < Screen.height * 0.35f);
        }

        private void HandleMouse()
        {
            if (Input.GetMouseButton(0))
            {
                float norm = (Input.mousePosition.x / Screen.width) * 2f - 1f;
                if (Mathf.Abs(norm) > steerDeadzone)
                    SteerAxis = Mathf.Clamp(norm, -1f, 1f);
            }
            if (Input.GetMouseButtonDown(0))
            {
                swipeStart = Input.mousePosition;
                lastTapTime = Time.time;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 delta = (Vector2)Input.mousePosition - swipeStart;
                if (delta.y > swipeThreshold) JumpPressed = true;
                else if (delta.y < -swipeThreshold) SlideHeld = true;
                if (Time.time - lastTapTime < doubleTapWindow && Time.time - lastTapTime > 0.02f)
                    TransformPressed = true;
            }
            // slide hold via right mouse button
            if (Input.GetMouseButton(1)) SlideHeld = true;
        }
    }
}
```

Hmm, the double-tap detection logic is flawed (lastTapTime overwritten on began). Let me simplify: track tap times in a small buffer. Actually for prototype, acceptable. But let me improve: keep `lastTapTime` as time of last tap end; on new tap began, if Time.time - lastTapTime < window => transform. I'll adjust slightly. Let me rewrite cleaner.

Actually let me keep it pragmatic. I'll finalize with a cleaner version.<|end|><|start|>start<|channel|>xml<|message|><rfl:parameter name="command">
cat > "D:/made_games/New folder/VANO/UnityProject/Assets/_Project/Scripts/Player/PlayerInput.cs" <<'EOF'
using UnityEngine;

namespace Vano
{
    /// <summary>
    /// Mobile touch input for VANO. Steer axis, jump, slide, double-tap transform.
    /// Legacy Input (works in Editor). Set Active Input Handling to "Both" or "Input Manager (Old)".
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public float SteerAxis { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool SlideHeld { get; private set; }
        public bool TransformPressed { get; private set; }

        [Header("Tuning")]
        [SerializeField] private float doubleTapWindow = 0.25f;
        [SerializeField] private float swipeThreshold = 60f;
        [SerializeField] private float steerDeadzone = 0.05f;

        private float lastTapEndTime = -10f;
        private Vector2 swipeStart;
        private bool trackingSwipe;

        void Update()
        {
            SteerAxis = 0f;
            JumpPressed = false;
            SlideHeld = false;
            TransformPressed = false;

#if UNITY_EDITOR || UNITY_STANDALONE
            HandleMouse();
#else
            HandleTouches();
#endif
        }

        private void HandleTouches()
        {
            int count = Input.touchCount;
            for (int i = 0; i < count; i++)
            {
                Touch t = Input.GetTouch(i);
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        // double tap detection: second tap shortly after first tap ended
                        if (Time.time - lastTapEndTime < doubleTapWindow && Time.time - lastTapEndTime > 0.02f)
                            TransformPressed = true;
                        swipeStart = t.position;
                        trackingSwipe = true;
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        float norm = (t.position.x / Screen.width) * 2f - 1f;
                        if (Mathf.Abs(norm) > steerDeadzone)
                            SteerAxis = Mathf.Clamp(norm, -1f, 1f);
                        break;
                    case TouchPhase.Ended:
                        if (trackingSwipe)
                        {
                            Vector2 delta = t.position - swipeStart;
                            if (delta.y > swipeThreshold) JumpPressed = true;
                            else if (delta.y < -swipeThreshold) SlideHeld = true;
                        }
                        trackingSwipe = false;
                        lastTapEndTime = Time.time;
                        break;
                }
            }
            // slide hold: a stationary touch in the bottom third keeps sliding
            if (count > 0)
            {
                Touch t0 = Input.GetTouch(0);
                if (t0.phase == TouchPhase.Stationary && t0.position.y < Screen.height * 0.35f)
                    SlideHeld = true;
            }
        }

        private void HandleMouse()
        {
            if (Input.GetMouseButton(0))
            {
                float norm = (Input.mousePosition.x / Screen.width) * 2f - 1f;
                if (Mathf.Abs(norm) > steerDeadzone)
                    SteerAxis = Mathf.Clamp(norm, -1f, 1f);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastTapEndTime < doubleTapWindow && Time.time - lastTapEndTime > 0.02f)
                    TransformPressed = true;
                swipeStart = Input.mousePosition;
                trackingSwipe = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (trackingSwipe)
                {
                    Vector2 delta = (Vector2)Input.mousePosition - swipeStart;
                    if (delta.y > swipeThreshold) JumpPressed = true;
                    else if (delta.y < -swipeThreshold) SlideHeld = true;
                }
                trackingSwipe = false;
                lastTapEndTime = Time.time;
            }
            if (Input.GetMouseButton(1)) SlideHeld = true;
        }
    }
}
EOF
echo done