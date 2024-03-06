using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public float maxArmor = 50f;
    public float armor;

    public static int deathCount = 0;

    void Start()
    {
        health = maxHealth;
        CanvasManager.Instace.UpdateHealth((int)health);
        CanvasManager.Instace.UpdateArmor((int)armor);
        // CanvasManager.Instace.UpdateHealthIndicator((int)health);

        if (deathCount >= 3)
        {
            Debug.Log("Game over!");
            GameOverScreen();
        }
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30f);
            Debug.Log("Player damaged!");
        }
    }

    public void DamagePlayer(float damage)
    {
        if(armor > 0)
        {
            if(armor >= damage)
            {
                armor -= damage;
            }
            else if(armor < damage)
            {
                float remainingDamage;

                remainingDamage = damage - armor;

                armor = 0;

                health -= remainingDamage;
            }

        }
        else
        {
            health -= damage;
        }
        
        if(health <= 0) 
        {
            deathCount++;
            Debug.Log("Player died!");
            Debug.Log(deathCount);

            Scene currenScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currenScene.buildIndex);
        }

        CanvasManager.Instace.UpdateHealth((int)health);
        CanvasManager.Instace.UpdateArmor((int)armor);
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health <= maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        CanvasManager.Instace.UpdateHealth((int)health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if(armor <= maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }
        if (armor > maxArmor)
        {
            armor = maxArmor;
        }

        CanvasManager.Instace.UpdateArmor((int)armor);
    }

    public void GameOverScreen()
    {
        SceneManager.LoadScene("GameOver");
    }
}
