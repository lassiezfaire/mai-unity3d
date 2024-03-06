using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;
    
    private float enemyHealth = 2f;

    public GameObject gunHitEffect;

    void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        enemyManager = FindObjectOfType<EnemyManager>();
    }

    void Update()
    {
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);

        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }
}
