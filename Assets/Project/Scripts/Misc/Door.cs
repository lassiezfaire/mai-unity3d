using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;
    // public GameObject areaToSpawn;

    public bool requiresKey;
    public bool reqRed, reqGreen, reqBlue;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (requiresKey)
            {
                if (reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    doorAnim.SetTrigger("DoorOpen");
                    // areaToSpawn.SetActive(true);
                }
                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {
                    doorAnim.SetTrigger("DoorOpen");
                    // areaToSpawn.SetActive(true);
                }
                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("DoorOpen");
                    // areaToSpawn.SetActive(true);
                }
            }
            else
            {
                doorAnim.SetTrigger("DoorOpen");
                // areaToSpawn.SetActive(true);
            }
        }
    }
}
