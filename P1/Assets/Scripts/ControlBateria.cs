using UnityEngine;
using UnityEngine.UI; // Si usas la UI tradicional o TextMeshPro
using UnityEditor;

public class ControlBateria : MonoBehaviour
{
    void Update()
    {
        // 1. Obtener el nivel de batería (retorna un float entre 0.0 y 1.0)
        float nivelBateria = SystemInfo.batteryLevel;

        if (nivelBateria == -1f)
        {
            Debug.Log("El nivel de batería no está disponible en esta plataforma.");
        }
        else
        {
            // Convertir a formato de porcentaje (ej: 85%)
            float porcentaje = nivelBateria * 100f;
            Debug.Log($"Batería actual: {porcentaje}%");
        }

        // 2. Obtener el estado (Cargando, Desconectado, Lleno, etc.)
        BatteryStatus estado = SystemInfo.batteryStatus;

        switch (estado)
        {
            case BatteryStatus.Charging:
                Debug.Log("El teléfono se está cargando.");
                break;
            case BatteryStatus.Discharging:
                Debug.Log("El teléfono se está descargando.");
                break;
            case BatteryStatus.Full:
                Debug.Log("La batería está completamente llena.");
                break;
            case BatteryStatus.NotCharging:
                Debug.Log("Conectado, pero no está cargando.");
                break;
            default:
                Debug.Log("Estado desconocido.");
                break;
        }
    }
}

