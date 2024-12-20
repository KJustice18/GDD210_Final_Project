using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Cam;
    public Transform camTrans;
    public CharacterController cc;
    private float camRotation = 0f;
    public float MouseSens;
    public float MoveSpeed;
    public float Grav = -9.8f;
    public float JumpSpeed;
    private float vertSpeed;

    private AudioSource FootstepSource;
    public AudioClip FootstepClip;

    private float countdown;
    public float FootstepInterval;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FootstepSource = Cam.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        float mouseInputY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;
        camRotation -= mouseInputY;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        camTrans.localRotation = Quaternion.Euler(camRotation, 0f, 0f);

        float mouseInputX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX));

        Vector3 movement = Vector3.zero;

        //Horizontal movement
        float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

        //VerticalMovement
        if (cc.isGrounded)
        {
            vertSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vertSpeed = JumpSpeed;
            }
        }

        vertSpeed += (Grav * Time.deltaTime);
        movement += (transform.up * vertSpeed * Time.deltaTime);

        cc.Move(movement);

        if (cc.velocity != Vector3.zero)
        {
            if (countdown <= FootstepInterval)
            {
                countdown += Time.deltaTime;

            }
            else
            {
                FootstepSource.clip = FootstepClip;
                FootstepSource.Play();
                countdown = 0f;
            }
        }
        else 
        {
            FootstepSource.Stop();
        }


        if (Input.GetKeyDown(KeyCode.LeftBracket)) 
        {
            if (MouseSens > 50) 
            {
                MouseSens -= 50;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        { 
            MouseSens += 50;
        }
    }
}
