using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballD : MonoBehaviour
{
    public float cannonspeed;
    private Rigidbody2D rb;
    private Vector3 respawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, cannonspeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Tilecheck")

        {

            transform.position = respawnPoint;

        }      

    }

}
