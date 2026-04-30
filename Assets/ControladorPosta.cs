using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] int cantidadVueltas;

    int vueltasCompletadas = 0;
    int corredorActualIndex = 0;
    bool carreraActiva = false;

    ControladorUI controladorUI;

    void Awake()
    {
        controladorUI = FindObjectOfType<ControladorUI>();
    }

    // Llamado por el botón "Posicionarse" via ControladorUI
    public void Posicionarse()
    {
        if (carreraActiva) return;

        // Cada corredor se posiciona en su objetivo correspondiente (posición de inicio)
        for (int i = 0; i < corredores.Count; i++)
        {
            int objetivoIndex = i % objetivos.Count;
            corredores[i].Posicionarse(objetivos[objetivoIndex].position);
        }

        corredorActualIndex = 0;
        vueltasCompletadas = 0;

        Debug.Log("Corredores posicionados.");
    }

    // Llamado por el botón "Correr" via ControladorUI
    public void IniciarCarrera()
    {
        if (carreraActiva) return;
        if (corredores.Count == 0 || objetivos.Count == 0) return;

        carreraActiva = true;
        corredorActualIndex = 0;

        LanzarCorredorActual();
    }

    void LanzarCorredorActual()
    {
        // El corredor en index i corre hacia el objetivo i+1 (siguiente en el ciclo)
        Corredor corredor = corredores[corredorActualIndex];
        int objetivoDestinoIndex = (corredorActualIndex + 1) % objetivos.Count;
        Transform objetivo = objetivos[objetivoDestinoIndex];

        corredor.IniciarCarrera(objetivo, this);
    }

    // Llamado por el Corredor cuando llega al objetivo
    public void CorredorLlego(Corredor corredorQueLlego)
    {
        // Avanzar al siguiente corredor
        corredorActualIndex++;

        // Si completó todos los corredores del ciclo → una vuelta completada
        if (corredorActualIndex >= corredores.Count)
        {
            corredorActualIndex = 0;
            vueltasCompletadas++;

            Debug.Log("Vuelta completada: " + vueltasCompletadas);

            if (vueltasCompletadas >= cantidadVueltas)
            {
                carreraActiva = false;
                controladorUI.MostrarFinalizacion();
                return;
            }
        }

        // Lanzar al siguiente corredor
        LanzarCorredorActual();
    }

    // Llamado por ControladorUI cuando el slider cambia
    public void SetVelocidadCorredores(float velocidad)
    {
        foreach (Corredor c in corredores)
        {
            c.SetVelocidad(velocidad);
        }
    }
}
