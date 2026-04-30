using UnityEngine;

public class Corredor : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float speed;

    float distance;

    bool corriendo = false;
    int pasos = 0;

    ControladorPosta controladorPosta;

    // Texto 3D o UI que muestra los pasos (asignar desde el inspector)
    [SerializeField] TMPro.TextMeshPro textoPasos;

    void Update()
    {
        if (!corriendo) return;

        if (target)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            distance = Vector3.Distance(transform.position, target.position);

            pasos++;
            if (textoPasos != null)
                textoPasos.text = pasos.ToString();

            Debug.Log("Distancia: " + Mathf.Round(distance));

            if (distance <= 0.1f)
            {
                corriendo = false;
                controladorPosta.CorredorLlego(this);
            }
        }
    }

    // Llamado por ControladorPosta para iniciar la carrera hacia el objetivo
    public void IniciarCarrera(Transform nuevoObjetivo, ControladorPosta posta)
    {
        target = nuevoObjetivo;
        controladorPosta = posta;
        pasos = 0;
        corriendo = true;
    }

    public void SetVelocidad(float nuevaVelocidad)
    {
        speed = nuevaVelocidad;
    }

    public void Posicionarse(Vector3 posicion)
    {
        transform.position = posicion;
        pasos = 0;
        if (textoPasos != null)
            textoPasos.text = "0";
    }
}
