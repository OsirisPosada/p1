using UnityEngine;
using UnityEngine.UI;
using TMPro; // Requerido para controlar elementos de TextMeshPro
using UnityEditor;

public class BateriaUI : MonoBehaviour
{
    [Header("Componentes de UI")]
    [SerializeField] private Image imagenBateria; // Imagen en modo 'Filled'
    [SerializeField] private TextMeshProUGUI textoPorcentaje; // Arrastra aquí el texto de TMP

    [Header("Optimización")]
    [Tooltip("Tiempo en segundos entre cada actualización.")]
    [SerializeField] private float intervaloActualizacion = 5.0f;

    private float tiempoTranscurrido;

    void Start()
    {
        ActualizarBateriaUI();
    }

    void Update()
    {
        // Control de tiempo para no saturar el rendimiento
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= intervaloActualizacion)
        {
            ActualizarBateriaUI();
            tiempoTranscurrido = 0f;
        }
    }

    void ActualizarBateriaUI()
    {
        float nivel = SystemInfo.batteryLevel;

        // Si estás en PC/Editor el valor será -1, así que simulamos un 75% para pruebas
        if (nivel < 0)
        {
            nivel = 0.75f;
        }

        // 1. Actualizar el Icono Visual (Relleno)
        if (imagenBateria != null)
        {
            imagenBateria.fillAmount = nivel;

            // Opcional: Cambia de color (Rojo -> Amarillo -> Verde)
            imagenBateria.color = Color.Lerp(Color.red, Color.green, nivel);
        }

        // 2. Actualizar el Texto de Porcentaje
        if (textoPorcentaje != null)
        {
            // Convertimos el float (0.0 a 1.0) a entero (0 a 100)
            int porcentajeEntero = Mathf.RoundToInt(nivel * 100f);

            // Asignamos el texto formateado (ej: "75%")
            textoPorcentaje.text = $"{porcentajeEntero}%";
        }
    }
}


