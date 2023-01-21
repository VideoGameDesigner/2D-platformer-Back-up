using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roommanager : MonoBehaviour
{

    public GameObject virtualCam;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")&& !other.isTrigger)

        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player") && !other.isTrigger)

        {
            virtualCam.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
