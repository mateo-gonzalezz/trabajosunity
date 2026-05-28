using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public void IrAMusicaDisponible()
    {
        SceneManager.LoadScene("musica disponible");
    }

    public void IrAQuienSoy()
    {
        SceneManager.LoadScene("quien soy");
    }

    public void IrAFuturosProyectos()
    {
        SceneManager.LoadScene("futuros proyectos");
    }

    public void IrAMasSobreMi()
    {
        SceneManager.LoadScene("mas sobre mi");
    }

    public void VolverAlInicio()
    {
        Debug.Log("boton presionado");
        SceneManager.LoadScene("pagina principal");
    }
}