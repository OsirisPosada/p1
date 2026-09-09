using UnityEngine;
using Vuforia;
using UnityEditor;

public class SimpleBarcodeScanner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;

    [Header("Configuración de Sonido")]
    public AudioSource audioSource; // Arrastra tu AudioSource aquí en el Inspector

    private BarcodeBehaviour mBarcodeBehaviour;
    private string lastBarcodeText = ""; // Guarda el último código leído para evitar repeticiones

    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            string currentBarcodeText = mBarcodeBehaviour.InstanceData.Text;
            barcodeAsText.text = currentBarcodeText;

            // Si el código actual es diferente al último que procesamos (es una lectura nueva)
            if (currentBarcodeText != lastBarcodeText)
            {
                // Actualizamos el registro del último código leído
                lastBarcodeText = currentBarcodeText;

                // Reproduce el sonido de escaneo
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.PlayOneShot(audioSource.clip);
                }
            }
        }
        else
        {
            barcodeAsText.text = "";
            lastBarcodeText = ""; // Resetea el registro cuando la cámara ya no ve ningún código
        }
    }
}
