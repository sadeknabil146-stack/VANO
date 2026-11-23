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