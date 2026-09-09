using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CambioDeEscenas : MonoBehaviour
{
    [Header("Configuración de Audio")]
    public AudioSource audioSource;
    public AudioClip sonidoCambio;

    public void CargarEscena(string que_escena)
    {
        StartCoroutine(CambiarConSonido(que_escena));
    }

    private IEnumerator CambiarConSonido(string que_escena)
    {
        if (audioSource != null && sonidoCambio != null)
        {
            audioSource.PlayOneShot(sonidoCambio);
            // Espera a que termine de reproducirse el clip de audio
            yield return new WaitForSeconds(sonidoCambio.length);
        }

        SceneManager.LoadScene(que_escena);
    }
}