using UnityEngine;

public class BillboardAreaTargetFijoPuro : MonoBehaviour
{
    private Transform vuforiaCameraTransform;

    void Start()
    {
        BuscarCamara();

        // Forzamos a que el Canvas use su escala original diseñada por ti
        // Asegúrate de que las posiciones locales del Texto hijo estén en (0,0,0)
        if (transform.childCount > 0)
        {
            transform.GetChild(0).localPosition = Vector3.zero;
        }
    }

    void LateUpdate()
    {
        if (vuforiaCameraTransform == null)
        {
            BuscarCamara();
            return;
        }

        // 1. OBTENER POSICIÓN FIJA EN EL MUNDO
        Vector3 posicionFija = transform.position;

        // 2. CALCULAR DIRECCIÓN HORIZONTAL HACIA LA CÁMARA
        Vector3 targetPoint = vuforiaCameraTransform.position;
        targetPoint.y = posicionFija.y; // Bloquea el eje vertical para que no se incline

        // 3. ROTAR SOBRE SU PROPIO EJE (Sin alterar la posición)
        transform.LookAt(targetPoint);
        transform.Rotate(0, 180, 0); // Corrección del efecto espejo de Vuforia
    }

    void BuscarCamara()
    {
        GameObject vuforiaCamObj = GameObject.FindWithTag("MainCamera");
        if (vuforiaCamObj != null)
        {
            vuforiaCameraTransform = vuforiaCamObj.transform;
        }
        else
        {
            Camera vuforiaCam = FindFirstObjectByType<Camera>();
            if (vuforiaCam != null) vuforiaCameraTransform = vuforiaCam.transform;
        }
    }
}
