using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointBehavior : MonoBehaviour
{
    public bool isAvalable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAvalable)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

        }
        else if (!isAvalable)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OnPath")
        {
            isAvalable = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OnPath")
        {
            isAvalable = false;
        }
    }
}
