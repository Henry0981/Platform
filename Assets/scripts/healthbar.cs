using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthbar : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] Image bar;

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        bar.fillAmount = (float)currentHealth / maxHealth;
        // Debug.Log(currentHealth / maxHealth);
    }
    public void Die()
    {
        Debug.Log("Player died");
        SceneManager.LoadScene(1);
    }
}
