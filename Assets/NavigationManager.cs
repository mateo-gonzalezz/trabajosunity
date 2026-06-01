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
    public void AbrirSoundCloud()
    {
        Application.OpenURL("https://on.soundcloud.com/2ThCdrfTrhETsR2aHK");
    }

    public void AbrirInstagram()
    {
        Application.OpenURL("https://www.instagram.com/keletto.music?igsh=NG5zZXR1NzZkaXcy&utm_source=qr");
    }

    public void AbrirTikTok()
    {
        Application.OpenURL("https://www.tiktok.com/@kelettto?_r=1&_t=ZS-96r4IO87tI8");
    }
}