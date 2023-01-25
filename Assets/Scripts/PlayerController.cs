using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public float speed = 10f;
    public float jumpPower = 10f;
    public float sprintingMultiplayer; //velocidad al correr
    public bool isSprinting = false; //correr
    public CharacterController controller;
    public Camera camera;
    public LayerMask groundMask; //suelo
    public Transform groundDetectionTransform; //detector del suelo
    public bool isCrouching = false; //agacharse
    public float crouchHeight = 1.25f; //altura agachado
    public float standingHeigth = 1.8f; //altura normal
    public float crouchingSpeed = -5; //velocidad agachado
    public float gravity = -9.8f; //gravedad
    public float currentVelY = 0;
    public AudioClip[] FootstepSounds;
    public float footstepLapTime = 2;
    float currentFootstepTime = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        currentFootstepTime = footstepLapTime; //Cuando inicie, al caminar empezarán los sonidos. 
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded == true) //saltar mientras estas en el suelo
        {
            currentVelY = 0;
            currentVelY = jumpPower;
        }
        //Debug.Log(currentVelY);
        currentVelY += gravity * Time.deltaTime;
        Vector3 movement = new Vector3();
        movement = x * transform.right + z * transform.forward;
        controller.Move(movement * speed * Time.deltaTime);
        controller.Move(new Vector3(0, currentVelY * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching) //correr y no poder agacharte mientras corres
        {
            controller.Move(movement * sprintingMultiplayer * Time.deltaTime); //usar la velocidad de sprint 
            isSprinting = true;

        }
        else
        {
            isSprinting = false;
        }
        if (Input.GetKey(KeyCode.LeftControl) && !isSprinting) //agacharse y no poder correr mientras te agachas
        {
            controller.Move(movement * crouchingSpeed * Time.deltaTime); //usar la velocidad de agachado
            controller.height = crouchHeight; //pasar de altura normal a agachado
            isCrouching = true;

        }
        else
        {
            controller.height = standingHeigth; //pasar de altura agachado a normal
            isCrouching = false;

        }

        if (movement.magnitude > 0) // si el personaje se mueve
        {
            currentFootstepTime += Time.deltaTime; //Esto es un contador, lo que hace que cada dos segundos, se reinicie el audio.
            if (currentFootstepTime >= footstepLapTime)
            {
                AudioManager.instance.PlayAudio(FootstepSounds[Random.Range(0, FootstepSounds.Length)]); //Aquí haces que el audio sea random.
                currentFootstepTime = 0;
            }
        }

        //float y = Input.GetAxis("Jump");  //esto lo haces  para crear una variable de salto.

        //Vector3 movement = transform.right * x + transform.forward * z;//Esto es para hacer la gravedad, para que se quede en el suelo.
        //movement.y /= playerSpeed; //la  velocidad del jugador.

        //movement *= playerSpeed;



        //if (Input.GetButtonDown("Jump") && controller.isGrounded) //Aquí le estás diciendo si está en el suelo.
        //{
        //Yvelocity = 0;
        //Yvelocity += 60f; //Usas la variable para que te detecte el salto, y le multiplicas una cantidad para conseguir la fuerza de gravedad.
        //}
        //Debug.Log(Yvelocity);
        //Yvelocity -= gravityForce * Time.deltaTime;//Aquí lo que haces es que se reste y lo multiplica, IMPORTANTE RESTARLO.
        //movement.y = Yvelocity;
        //movement *= Time.deltaTime; //Esto es la velocidad del movimiento.
    }
}
