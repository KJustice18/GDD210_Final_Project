using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    public GameObject MuddyTracks;
    public GameObject MirrorLights;
    public GameObject FlashlightLight;

    private bool hasKey;
    private bool BedPressed;
    private bool PicturePressed;
    private bool CigsPressed;
    private bool MirrorReady;

    private bool HallwayTriggered;
    private bool DoorwayTriggered;


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
        MuddyTracks.SetActive(false);
        MirrorLights.SetActive(true);
        FlashlightLight.SetActive(false);

        BedPressed = false;
        PicturePressed = false;
        CigsPressed = false;
        MirrorReady = false;

        HallwayTriggered = false;
        DoorwayTriggered = false;
        

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
                        narrativeText.text = "NarrativeCube Associated Text";
                        narrativeText.enabled = true;
                        textDisappearTime = 5;
                        
                    }
                }

                if (hit.collider.name == "NarrativeCube2")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "NarrativeCube2 Associated Text";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        Door2.SetActive(false);
                    }
                }

                if (hit.collider.name == "FlashlightBase" || hit.collider.name == "FlashlightHead")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the Flashlight";
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "Flashlight Associated Text";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        MirrorLights.SetActive(false);
                        FlashlightLight.SetActive(true);
                        Door2.SetActive(false);

                    }
                }

                if (hit.collider.name == "PackOfCigs")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "Oh thank god I still have a pack left ...Sorry Bea";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        CigsPressed = true;
                    }
                }

                if (hit.collider.name == "PictureFrame")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "God, why does my smile look like that?";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        PicturePressed = true;
                    }
                }

                if (hit.collider.name == "RoommatesBed")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "It’s late, Bea should be home by now. Where is she?";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        BedPressed = true;
                    }
                }

                if (hit.collider.name == "Mirror")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (MirrorReady)
                        {
                            narrativeText.text = "That isn’t me. I know that isn’t me.";
                        }
                        else 
                        {
                            narrativeText.text = "It feels like somthing is missing.";

                        }

                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;

                    }
                }

                if (hit.collider.name == "MuddyTracks")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "Is that mud? Where did that even come from?";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                    }
                }




            }
            else 
            {
                interactableText.enabled = false;
            }
        }

        //SpawntheMirrorMonster
        if (BedPressed && PicturePressed && CigsPressed) 
        {
            MirrorMonster.SetActive(true);
            MirrorReady = true;
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

        if (other.gameObject.name == "Door1Trigger" && !DoorwayTriggered) 
        {
            Door1.SetActive(true);
            MuddyTracks.SetActive(true);
            narrativeText.text = "Oh. I’m home.";
            narrativeText.enabled = true;
            textDisappearTime = textAppearTime;
            DoorwayTriggered = true;
        }

        if (other.gameObject.name == "HallwaySubtitleTrigger" && !HallwayTriggered)
        {
            narrativeText.text = "What the hell is this? Why am I here?";
            narrativeText.enabled = true;
            textDisappearTime = textAppearTime;
            HallwayTriggered = true;
        }

        if (other.gameObject.name == "FinishTrigger")
        {
            narrativeText.text = "The Demo Concludes Here. Press r to restart";
            narrativeText.enabled = true;
            textDisappearTime = textAppearTime;
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
