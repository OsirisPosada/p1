using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscenas : MonoBehaviour
{
    public void CargarEscena(string que_escena)
    {
        SceneManager.LoadScene(que_escena);
    }
}
