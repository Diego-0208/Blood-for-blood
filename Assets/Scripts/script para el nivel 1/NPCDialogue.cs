using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string dialogueText = "¡Hola! ¡Habla conmigo para avanzar!";
    private bool isPlayerInRange = false;

    private void Update()
    {
        // Verificar si el jugador está dentro del rango y presiona la tecla 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Mostrar el diálogo
            Debug.Log(dialogueText);

            // Llamar al método para que el jugador pueda avanzar
            LevelExit levelExit = FindObjectOfType<LevelExit>();
            if (levelExit != null)
            {
                levelExit.TalkedToNPC();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Presiona 'E' para hablar con el NPC.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Has salido del rango del NPC.");
        }
    }
}
