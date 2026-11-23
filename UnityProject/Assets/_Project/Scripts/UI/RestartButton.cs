using UnityEngine;
using UnityEngine.UI;

namespace Vano
{
    /// <summary>
    /// Wire a UI Button's OnClick to Restart().
    /// </summary>
    public class RestartButton : MonoBehaviour
    {
        void Start()
        {
            var btn = GetComponent<Button>();
            if (btn != null) btn.onClick.AddListener(() => GameManager.Instance?.Restart());
        }
    }
}
EOF
echo done