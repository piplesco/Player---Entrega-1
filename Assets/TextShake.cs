using UnityEngine;

public class TextShake : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float shakeAmount = 2f; // Intensidad del temblor

    private Vector3 originalPosition;

    void Start()
    {
        // Guardamos la posición original del texto
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Si el jugador está en movimiento, aplica el temblor
        if (IsPlayerWalking())
        {
            Vector3 shakePosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
            transform.localPosition = shakePosition;
        }
        else
        {
            // Si el jugador está quieto, restaura la posición original
            transform.localPosition = originalPosition;
        }
    }

    private bool IsPlayerWalking()
    {
        // Reemplaza esto con la lógica de movimiento de tu personaje
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }
}
