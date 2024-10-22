using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float interactionRange = 2f; // Rango de interacción con el NPC
    public LayerMask npcLayer; // Capa asignada a los NPCs

    void Update()
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Interactuar con un NPC al presionar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithNPC();
        }
    }

    void InteractWithNPC()
    {
        // Detectar si hay un NPC dentro del rango de interacción
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange, npcLayer);

        if (hitColliders.Length > 0)
        {
            // Interactuar con el primer NPC detectado
            Debug.Log("Interacción con NPC: " + hitColliders[0].gameObject.name);
            // Aquí puedes agregar la lógica específica de la interacción (por ejemplo, abrir un diálogo)
        }
        else
        {
            Debug.Log("No hay NPCs cerca para interactuar.");
        }
    }

    // Para visualizar el rango de interacción en la escena
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
