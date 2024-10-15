using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;  // Vida máxima del enemigo
    private int currentHealth;   // Vida actual
    public bool isDefeated = false;  // Indica si el enemigo ha sido derrotado

    void Start()
    {
        // Inicializamos la vida del enemigo al máximo
        currentHealth = maxHealth;
    }

    // Método que recibe daño
    public void TakeDamage(int damage)
    {
        if (isDefeated)
            return; // Si ya ha sido derrotado, no hacemos nada

        // Reducimos la vida del enemigo
        currentHealth -= damage;

        // Verificamos si la vida ha llegado a 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método que se llama cuando el enemigo es derrotado
    void Die()
    {
        isDefeated = true; // Marcamos al enemigo como derrotado
        // Aquí puedes agregar efectos visuales, sonido, animaciones, etc.
        gameObject.SetActive(false); // Desactiva el enemigo (o puedes destruirlo)
    }
}
