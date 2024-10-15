using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Variable para verificar si el jugador ha hablado con el NPC
    private bool hasTalkedToNPC = false;

    // M�todo para cambiar el nivel
    public void ChangeLevel(string levelName)
    {
        if (hasTalkedToNPC)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("Necesitas hablar con el NPC para continuar.");
        }
    }

    // M�todo para marcar que se ha hablado con el NPC
    public void TalkedToNPC()
    {
        hasTalkedToNPC = true;
        Debug.Log("Has hablado con el NPC.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Suponiendo que el jugador tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Llama al m�todo para cambiar de nivel (puedes hacerlo desde un bot�n, por ejemplo)
            ChangeLevel("NombreDelSiguienteNivel"); // Cambia "NombreDelSiguienteNivel" al nombre de tu escena
        }
    }
}
