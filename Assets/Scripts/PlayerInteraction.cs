using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public Transform camTrans;
    public TMP_Text interactableText;

    private bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        interactableText.enabled = false;
        hasKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit))
        {
            Debug.DrawLine(camTrans.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 5f);
            if (hit.collider.gameObject.tag == "Interactable")
            {

                if (hit.collider.name == "CubeKey") 
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to pickup the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0)) 
                    {
                        hit.collider.gameObject.SetActive(false);
                        hasKey = true;
                    }
                }

                if (hit.collider.name == "Door")
                {
                    interactableText.enabled = true;

                    if (hasKey)
                    {
                        interactableText.text = "Click to open the " + hit.collider.name;
                        if (Input.GetMouseButtonDown(0))
                        {
                            hit.collider.gameObject.SetActive(false);
                            hasKey = false;
                        }
                    }
                    else 
                    {
                        interactableText.text = "You need a key to open the " + hit.collider.name;
                    }
                    
                }

            }
            else 
            {
                interactableText.enabled = false;
            }
        }

        //Reset the scene
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("Kyle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChangeTrigger") 
        {
            if (other.gameObject.name == "ColorSphere") 
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ChangeTrigger")
        {
            if (other.gameObject.name == "ColorSphere")
            {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
