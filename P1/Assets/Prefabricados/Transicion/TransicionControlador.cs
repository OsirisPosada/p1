using UnityEngine;
using UnityEngine.UI;

public class TransicionControlador : MonoBehaviour
{
    //public Animator _animator;
    public float VelocidadTransicion = 1;
    public Color ColorTransicion; 
    Animator _animator;

    private void Start()
    {
        GetComponent<Animator>().speed = VelocidadTransicion;
        transform.GetChild(0).GetComponent<Image>().color = ColorTransicion;
    }

    public void IniciarTransicion(string tipo_transicion)
    {
        if (tipo_transicion == "apertura")
        {
            _animator.SetBool("abrir",true);
        }
        else if(tipo_transicion == "cierre")
        {
            _animator.SetBool("abrir", false);
        }
    }
}
