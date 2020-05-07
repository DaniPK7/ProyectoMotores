using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Inputs
    public float hInput, vInput;
    private Vector3 playerInput;

    //Character Controller
    private CharacterController playerController;
    private Vector3 playerDirection;
    public float gravity = 9.8f;
    public float fallVelocity;

    //Camera
    public Camera mainCamera;
    private Vector3 cameraForward, cameraRight;
    
    //Speeds//
    public float currentSpeed;
    public float jumpForce;
    
    //Anims
    private Animator playerAnim;
    private float walkSpeed = 1.25f, sprintSpeed = 6;
    public bool sprint;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();

        playerAnim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        Sprint();   

        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        playerInput = new Vector3(hInput, 0, vInput);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);  //Para que la velocidad no sea mayor al ir en diagonal

        playerAnim.SetFloat("walkVelocity", playerInput.magnitude * currentSpeed);

        camDirection();

        playerDirection = playerInput.x * cameraRight + playerInput.z * cameraForward;      //La direccion que debe tener nuestro pj

        playerController.transform.LookAt(playerController.transform.position + playerDirection);   //Girar desde su posicion hacia la correspondiente

        SetGravity();      //Gravedad del pj
        Jump();

        playerController.Move(playerDirection * currentSpeed * Time.deltaTime);

        Vector3 a = playerDirection ;// (Mathf.Abs(playerController.velocity.x) * Mathf.Abs(playerController.velocity.y) );
        //print(cameraForward + "\nRight: " + cameraRight);
        //print("Vel: " + a);
        //print(vInput);
        //playerSpeed = Mathf.Floor(playerController.velocity.magnitude);
        playerAnim.SetBool("playerSprint", sprint);

        playerAnim.SetFloat("verticalVelocity", playerController.velocity.y);

    }

    void camDirection()
    {
        cameraForward = mainCamera.transform.forward;
        cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;      //Ambos a 0 pues no nos importa su eje y*/

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;     //Valor normalizado
    }

    void SetGravity()
    {
        if (playerController.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            playerDirection.y = fallVelocity;

        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            playerDirection.y = fallVelocity;

            //playerAnim.SetFloat("verticalVelocity", playerController.velocity.y);
        }
        playerAnim.SetBool("isGrounded", playerController.isGrounded);
    }

    void Jump()
    {
        if (playerController.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            playerDirection.y = fallVelocity;
            playerAnim.SetTrigger("playerJump");

        }
    }
    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = true;

            if (currentSpeed < sprintSpeed) 
            {
                currentSpeed += 0.05f;
            }
            else if (currentSpeed >= sprintSpeed)
            {
                currentSpeed = sprintSpeed;
            }
        }
        else {
            sprint = false;

            if (currentSpeed > walkSpeed)
            {
                currentSpeed -= 0.05f;
            }
            else if (currentSpeed <= walkSpeed)
            {
                currentSpeed = walkSpeed;
            }
            
        }
    }

    private void OnAnimatorMove()
    {
       // transform.parent.rotation = anim.rootRotation;
       // transform.parent.position += anim.deltaPosition;
    }
}
