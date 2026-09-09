using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))] // Automatically adds AudioSource if missing
public class FlashlightController : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip sonidoClic;

    private AudioSource audioSource;
    private bool isFlashlightOn = false;

    void Awake()
    {
        // Automatically fetches the AudioSource on the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Configuration fallback
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f; // Forces 2D sound so it is fully audible
        }
    }

    public void ToggleFlashlight()
    {
        // Play the click sound
        if (audioSource != null && sonidoClic != null)
        {
            audioSource.PlayOneShot(sonidoClic);
        }
        else if (sonidoClic == null)
        {
            Debug.LogError("FlashlightController: 'sonidoClic' is missing in the Inspector!");
        }

        // Toggle flashlight
        isFlashlightOn = !isFlashlightOn;
        bool success = VuforiaBehaviour.Instance.CameraDevice.SetFlash(isFlashlightOn);

        if (!success)
        {
            Debug.LogWarning("Vuforia Flashlight is not supported on this device/editor.");
        }
    }
}
