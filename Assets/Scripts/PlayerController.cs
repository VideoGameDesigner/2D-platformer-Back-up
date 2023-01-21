using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;

    private float movement;
    private Rigidbody2D rb;
    private Animator anim;
    


    private enum MovementState {idle, running, jumping, falling,}
    public static Vector3 respawnPoint;
    private MovementState state;


    public GameController myGameController;

    public AudioClip Hurtsound;
    private AudioSource myAudiosource;


    // Start is called before the first frame update
    void Start()
    {
        myAudiosource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        

        //if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)

        //{
           // rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
       // }

        if (rb.velocity.y > .1f)

        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);

        


    }

    private void FixedUpdate()
    {
        playermovement();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.tag == "DeathDetector")

        {
            myAudiosource.PlayOneShot(Hurtsound);
            myGameController.minuslife();
            transform.position = respawnPoint;
            
            
        }

        else if (collision.tag =="respawncheck")

        {
            
            respawnPoint = transform.position;

        }


       
    }

     
    


    private void playermovement()

    {
        

        //movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;


        if (movement > 0.01f)
        {
            state = MovementState.running;
            transform.localScale = Vector3.one;
        }

        else if (movement < -0.01f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            state = MovementState.idle;
        }

       

        anim.SetInteger("state", (int)state);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

}
