using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string nextLevelName; // Nombre del siguiente nivel
    private Enemy[] enemies; // Array que contiene todos los enemigos en la escena

    void Start()
    {
        // Encuentra todos los objetos con el script Enemy en la escena
        enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        // Si todos los enemigos han sido derrotados
        if (AreAllEnemiesDefeated())
        {
            LoadNextLevel();
        }
    }

    // Verifica si todos los enemigos han sido derrotados
    bool AreAllEnemiesDefeated()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy != null && enemy.isDefeated == false) // Suponiendo que el enemigo tiene una variable isDefeated
            {
                return false;
            }
        }
        return true;
    }

    // Carga el siguiente nivel
    void LoadNextLevel()
    {
        // Aquí puedes agregar efectos visuales o temporizadores si deseas un retraso
        SceneManager.LoadScene(nextLevelName);
    }
}
