using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public Transform camTrans;
    public TMP_Text interactableText;
    public TMP_Text narrativeText;

    private float textAppearTime = 2f;
    private float textDisappearTime;

    public GameObject Door1;
    public GameObject Door2;
    public GameObject MirrorMonster;
    public GameObject Mirror;
    public GameObject MirrorLights;

    private bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        interactableText.enabled = false;
        narrativeText.enabled = false;
        hasKey = false;
        Door1.SetActive(false);
        Door2.SetActive(true);
        MirrorMonster.SetActive(false);
        Mirror.SetActive(true);


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

                if (hit.collider.name == "NarrativeCube")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Need code to trigger narrative thoughts
                        narrativeText.text = "NarrativeCube Associated Text";
                        narrativeText.enabled = true;
                        textDisappearTime = 5;
                        MirrorMonster.SetActive(true);

                        
                    }
                }

                if (hit.collider.name == "NarrativeCube2")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Need code to trigger narrative thoughts
                        narrativeText.text = "NarrativeCube2 Associated Text";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        Door2.SetActive(false);
                    }
                }

                if (hit.collider.name == "Flashlight" || hit.collider.name == "FlashlightHead")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Need code to trigger narrative thoughts
                        narrativeText.text = "Flashlight Associated Text";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        Door2.SetActive(false);
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
        
        if (narrativeText.enabled)
        {
            textDisappearTime -= Time.deltaTime;

            if (textDisappearTime <= 0) 
            {
                narrativeText.enabled = false;

            }
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

        if (other.gameObject.name == "Door1Trigger") 
        {
            Door1.SetActive(true);
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
