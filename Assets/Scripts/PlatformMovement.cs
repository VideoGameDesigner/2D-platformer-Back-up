using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed; // speed for the platform
    public int startingPoint; // starting index (position of the platform)
    public Transform[] points; // An array of transform points (positions where the platform needs to move)

    private int i; // index of the array

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; // Setting the position of the platform to
    }                                                        // the position of one of the points using index "startingPoint"


    // Update is called once per frame
    void Update()
    {
        // checking the distance of the platform and the point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; // increase the index
            if (i == points.Length) // check if the platform was on the last point after the index increase
            {
                i = 0; // reset the index
            }
        }

        // moving the platform to the point position with the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    // as soon as tbe player colliders with the moving platform the player then becomes a child of the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("player"))
        {
            if(transform.position.y<collision.transform.position.y)
            collision.transform.SetParent(transform);
        }
        
        
    }

    // as soon as the player stops touching the platform the player will no longer be a child of the platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("player"))
        {
            collision.transform.SetParent(null);
        }
           
       
    }

}
