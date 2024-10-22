using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public string dialogueText = "¡Hola! ¡Habla conmigo para avanzar!";
    private bool isPlayerInRange = false;

    // Referencia al panel de diálogo y al texto
    public GameObject dialoguePanel; // Arrastra el panel aquí en el Inspector
    public TextMeshProUGUI dialogueTextMesh; // Arrastra el TextMeshPro aquí en el Inspector

    private void Start()
    {
        // Asegúrate de que el panel de diálogo esté desactivado al inicio
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        // Cerrar el diálogo si se presiona la tecla 'E' de nuevo
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            dialoguePanel.SetActive(false); // Desactiva el panel
        }

        // Verificar si el jugador está dentro del rango y presiona la tecla 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Mostrar el diálogo
            dialogueTextMesh.text = dialogueText;
            dialoguePanel.SetActive(true); // Activa el panel

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
            dialoguePanel.SetActive(false); // Desactiva el panel al salir del rango
            Debug.Log("Has salido del rango del NPC.");
        }
    }
}
