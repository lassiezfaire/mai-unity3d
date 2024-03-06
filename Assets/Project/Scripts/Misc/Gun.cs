using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;

    public float bigDamage = 2f;
    public float smallDamage = 1f;

    public float fireRate = 1f;
    private float nextTimeToFire;

    public int maxAmmo;
    private int ammo;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;
    
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        CanvasManager.Instace.UpdateAmmo(ammo);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        if(ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }
        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        CanvasManager.Instace.UpdateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

    private void Fire()
    {
        // симул€ци€ радиуса выстрела
        
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        // предупредить всех врагов в радиусе слышимости

        foreach(var enemyCollider in enemyColliders) 
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAgro = true;
        }
        
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        
        foreach(var enemy in  enemyManager.enemiesInTrigger)
        {
            if (enemy != null)
            {
                var dir = enemy.transform.position - transform.position;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
                {
                    if (hit.transform == enemy.transform)
                    {
                        float dist = Vector3.Distance(enemy.transform.position, transform.position);

                        if (dist > range * 0.5f)
                        {
                            enemy.TakeDamage(smallDamage);
                        }
                        else
                        {
                            enemy.TakeDamage(bigDamage);
                        }
                    }
                }
            }         
        }

        nextTimeToFire = Time.time + fireRate;

        ammo--;

        CanvasManager.Instace.UpdateAmmo(ammo);
    }
}
