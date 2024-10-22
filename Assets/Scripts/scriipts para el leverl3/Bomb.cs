using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public float defuseTime = 5f; // Tiempo para desactivar la bomba
    public float explosionTime = 30f; // Tiempo antes de que la bomba explote
    public float explosionSoundLength = 1f; // Tiempo antes de que la bomba explote
    private bool isDefused = false; // Estado de la bomba
    private bool isDefusing = false; // Para verificar si se está desactivando

    public TextMeshProUGUI timerText; // Referencia al objeto de texto en la UI
    private float currentTime; // Tiempo restante

    public AudioSource explosionSound; // Referencia al componente AudioSource para el sonido de explosión

    void Start()
    {
        currentTime = explosionTime; // Inicializa el tiempo con el tiempo total de explosión
        StartCoroutine(BombCountdown());
    }

    void Update()
    {
        // Actualiza el temporizador en la pantalla
        if (!isDefused)
        {
            currentTime -= Time.deltaTime; // Resta el tiempo
            UpdateTimerUI();
        }
    }

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

        if (!isDefused)
        {
            isDefused = true;
            Debug.Log("¡Bomba desactivada!");
            EndGame(true); // Finaliza el juego con la bomba desactivada
        }
    }

    private IEnumerator BombCountdown()
    {
        // Espera el tiempo antes de que explote la bomba
        yield return new WaitForSeconds(explosionTime);

        // Si la bomba no ha sido desactivada, explota
        if (!isDefused)
        {
            Explode();
        }
        yield return new WaitForSeconds(explosionSoundLength);
        EndGame(false); // Finaliza el juego con la explosión
    }

    // Método para actualizar el temporizador en pantalla
    private void UpdateTimerUI()
    {
        // Convierte el tiempo a formato de minutos y segundos
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime % 60F);

        // Actualiza el texto de la UI con el formato mm:ss
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Si el tiempo llega a cero, muestra "00:00"
        if (currentTime <= 0)
        {
            timerText.text = "00:00";
        }
    }

    // Método para explotar la bomba
    private void Explode()
    {
        Debug.Log("¡La bomba ha explotado!");

        // Reproduce el sonido de la explosión
        explosionSound.Play();

        // Aquí puedes añadir otros efectos visuales si lo deseas
        
    }

    // Método para finalizar el juego
    private void EndGame(bool isDefusedSuccessfully)
    {
        if (isDefusedSuccessfully)
        {
            Debug.Log("¡Nivel completado! La bomba fue desactivada.");
        }
        else
        {
            Debug.Log("Fin del juego. La bomba explotó.");
        }

        // Reinicia la escena o carga una escena de Game Over
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena
    }
}

