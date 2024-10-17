using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    public bool isAvalable;
    
    // Start is called before the first frame update
    void Start()
    {
        isAvalable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvalable)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

        }
        else 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "OnPath")
        {
            isAvalable = true;
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "OnPath") 
        {
            isAvalable = false;
        }
    }
}
