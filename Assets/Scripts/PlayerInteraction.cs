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
    public LayerMask layerMask;

    private float textAppearTime = 2f;
    private float textDisappearTime;

    public GameObject Door1;
    public GameObject Door2;
    public GameObject Mirror;
    public GameObject MuddyTracks;
    public GameObject MirrorLights;
    public GameObject FlashlightLight;
    public GameObject Hair;
    public GameObject FrameUp;
    public GameObject FrameDown;

    private bool hasKey;
    private bool BedPressed;
    private bool PicturePressed;
    private bool CigsPressed;
    private bool BearPressed;
    private bool MirrorReady;
    private bool MirrorReady2;

    private bool HallwayTriggered;
    private bool DoorwayTriggered;

    private AudioSource PlayerAudio;
    public AudioClip FlashlightButton;
    public AudioClip FrameBreak;


    // Start is called before the first frame update
    void Start()
    {
        interactableText.enabled = false;
        narrativeText.enabled = false;
        hasKey = false;
        Door1.SetActive(false);
        Door2.SetActive(true);
        Mirror.SetActive(true);
        MuddyTracks.SetActive(false);
        MirrorLights.SetActive(true);
        FlashlightLight.SetActive(false);
        FrameDown.SetActive(false);
        FrameUp.SetActive(true);

        BedPressed = false;
        PicturePressed = false;
        CigsPressed = false;
        BearPressed = false;
        MirrorReady = false;
        MirrorReady2 = false;

        HallwayTriggered = false;
        DoorwayTriggered = false;
        
        PlayerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit))
        {
            Debug.DrawLine(camTrans.position + new Vector3(0f, -.01f, 0f), hit.point, Color.green, 5f);
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

                if (hit.collider.name == "Flashlight")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the Flashlight";
                    if (Input.GetMouseButtonDown(0))
                    {
                        //narrativeText.text = "Flashlight Associated Text";
                        //narrativeText.enabled = true;
                        //textDisappearTime = textAppearTime;
                        MirrorLights.SetActive(false);
                        FlashlightLight.SetActive(true);
                        Door2.SetActive(false);
                        PlayerAudio.clip = FlashlightButton;
                        PlayerAudio.Play();

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

                if (hit.collider.name == "MirrorQuad")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the Mirror";
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (MirrorReady)
                        {
                            narrativeText.text = "That isn’t me. I know that isn’t me.";
                            MirrorReady2 = true;
                            FrameUp.SetActive(false);
                            FrameDown.SetActive(true);
                            PlayerAudio.clip = FrameBreak;
                            PlayerAudio.Play();

                        }
                        else 
                        {
                            narrativeText.text = "It's just a mirror.";

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

                if (hit.collider.name == "TeddyBear")
                {
                    interactableText.enabled = true;
                    interactableText.text = "Click to interact with the " + hit.collider.name;
                    if (Input.GetMouseButtonDown(0))
                    {
                        narrativeText.text = "I can’t believe she still has that thing, does she not know how old she is?";
                        narrativeText.enabled = true;
                        textDisappearTime = textAppearTime;
                        BearPressed = true;
                    }
                }


            }
            else 
            {
                interactableText.enabled = false;
            }
        }

        //Checks if the player has interacted with all of the significant objects in the room
        if (BedPressed && PicturePressed && CigsPressed && BearPressed) 
        {
            MirrorReady = true;
        }

        if (MirrorReady)
        {
            Hair.GetComponent<Renderer>().material.color = Color.red;

            Vector3 forward = transform.forward;
            Vector3 toMirror = Vector3.Normalize(Mirror.transform.position - transform.position);

            if (Vector3.Dot(forward, toMirror) < 0 && MirrorReady2) 
            {
                Mirror.SetActive(false);
            }
        }
        //Reset the scene
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene("Kyle");
        }
        
        //Timer to make the subtitles dissapear
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
