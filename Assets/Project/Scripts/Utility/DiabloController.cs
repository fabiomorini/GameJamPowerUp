using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloController : MonoBehaviour
{
    private CameraShake shake;


    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            shake.CamShake();
        }
    }
}
