using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f; // Tiempo para desactivar la bomba
    private bool isDefused = false; // Estado de la bomba
    private bool isDefusing = false; // Para verificar si se está desactivando

    // Método que se llama para iniciar la desactivación
    public void StartDefuse()
    {
        if (!isDefused && !isDefusing)
        {
            StartCoroutine(DefuseBomb());
        }
    }

    private IEnumerator DefuseBomb()
    {
        isDefusing = true;
        Debug.Log("Desactivando bomba...");
        
        // Espera el tiempo necesario para desactivarla
        yield return new WaitForSeconds(defuseTime);
        
        isDefused = true;
        Debug.Log("¡Bomba desactivada!");
        EndGame(); // Finaliza el juego
    }

    // Método para finalizar el juego
    private void EndGame()
    {
        // Aquí puedes mostrar una pantalla de fin de juego o cargar otra escena
        Debug.Log("Fin del juego. ¡Nivel completado!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena
        // O carga otra escena si es necesario
    }
}
