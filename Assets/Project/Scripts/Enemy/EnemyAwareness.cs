using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 8f;
    public bool isAgro;
    // public Material aggroMat;
    private Transform playersTransform;

    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        if(dist < awarenessRadius)
        {
            isAgro = true;
        }    

        if(isAgro)
        {
            // GetComponentInChildren<MeshRenderer>().material = aggroMat;
        }
    }
}
