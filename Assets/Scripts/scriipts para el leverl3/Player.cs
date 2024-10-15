using UnityEngine;

public class Player : MonoBehaviour
{
    public Bomb bomb; // Referencia al script Bomb
    public float interactionDistance = 3f; // Distancia para interactuar con la bomba

    void Update()
    {
        // Verifica si el jugador está cerca de la bomba y presiona la tecla 'E'
        if (Input.GetKeyDown(KeyCode.E) && IsNearBomb())
        {
            bomb.StartDefuse(); // Llama al método para desactivar la bomba
        }
    }

    private bool IsNearBomb()
    {
        // Comprueba la distancia entre el jugador y la bomba
        return Vector3.Distance(transform.position, bomb.transform.position) <= interactionDistance;
    }
}
