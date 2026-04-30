using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControladorUI : MonoBehaviour
{
    [SerializeField] Button botonPosicionarse;
    [SerializeField] Button botonCorrer;
    [SerializeField] Slider sliderVelocidad;
    [SerializeField] TextMeshProUGUI textoFinalizacion;

    ControladorPosta controladorPosta;

    void Awake()
    {
        controladorPosta = FindObjectOfType<ControladorPosta>();
    }

    void Start()
    {
        // Ocultar mensaje de finalización al inicio
        if (textoFinalizacion != null)
            textoFinalizacion.gameObject.SetActive(false);

        // Conectar botones con ControladorPosta
        botonPosicionarse.onClick.AddListener(OnBotonPosicionarse);
        botonCorrer.onClick.AddListener(OnBotonCorrer);

        // Conectar slider con ControladorPosta
        sliderVelocidad.minValue = 1f;
        sliderVelocidad.maxValue = 3f;
        sliderVelocidad.onValueChanged.AddListener(OnSliderVelocidadCambia);

        // Aplicar velocidad inicial
        controladorPosta.SetVelocidadCorredores(sliderVelocidad.value);
    }

    void OnBotonPosicionarse()
    {
        controladorPosta.Posicionarse();
    }

    void OnBotonCorrer()
    {
        controladorPosta.IniciarCarrera();
    }

    void OnSliderVelocidadCambia(float valor)
    {
        controladorPosta.SetVelocidadCorredores(valor);
    }

    // Llamado por ControladorPosta al finalizar la carrera
    public void MostrarFinalizacion()
    {
        if (textoFinalizacion != null)
        {
            textoFinalizacion.gameObject.SetActive(true);
            textoFinalizacion.text = "¡Carrera Finalizada!";
        }

        Debug.Log("¡Carrera Finalizada!");
    }
}
