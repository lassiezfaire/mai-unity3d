using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private bool damagingPlayer;
    private PlayerHealth playerHealth;

    public float damageAmount = 10;
    public float timeBetweenDamage = 1.5f;

    private float damageCounter;

    private void Start()
    {
        damageCounter = timeBetweenDamage;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if(damagingPlayer)
        {
            if(damageCounter >= timeBetweenDamage)
            {
                playerHealth.DamagePlayer(damageAmount);

                damageCounter = 0f;
            }

            damageCounter += Time.deltaTime;
        }
        else
        {
            damageCounter = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            damageCounter = timeBetweenDamage;
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}
