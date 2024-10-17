using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMonster : MonoBehaviour
{

    private bool beenSeen;
    private bool inView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if monster has been seen and left the players view before making it invisible
        if(beenSeen & !inView) 
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            beenSeen = false;
        }

        //Causes the Monster to reappear (For debugging)
        if (Input.GetKey(KeyCode.M)) 
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }

    private void OnBecameVisible()
    {
        beenSeen = true;
        inView = true;
    }

    private void OnBecameInvisible()
    {
        inView = false;
    }
}
