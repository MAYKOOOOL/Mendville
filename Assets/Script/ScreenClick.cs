using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalClickSFX : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (AudioManager.instance == null) return;

        // Mouse click
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttonClickSound);
        }

        // Touch tap
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttonClickSound);
        }
    }
}
