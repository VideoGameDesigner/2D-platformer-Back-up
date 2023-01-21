using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Collectibles : MonoBehaviour
{

    public GameController myGameController;

    public AudioClip Tokensound;
    public AudioClip extralifesound;
    public AudioClip Loresound;
    public AudioClip treasuresound;
    private AudioSource myAudiosource;
    



    // Start is called before the first frame update
    void Start()
    {
        PlayerController.respawnPoint = transform.position;
        myAudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Tokens"))

        {
            myAudiosource.PlayOneShot(Tokensound);
            myGameController.Tokencount();
            Destroy(collision.gameObject);
  
        }

        if (collision.gameObject.CompareTag("Heart"))

        {
            myAudiosource.PlayOneShot(extralifesound);
            myGameController.addlife();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Lore"))
        {
            transform.position = PlayerController.respawnPoint; 
            myAudiosource.PlayOneShot(Loresound);
            myGameController.Lorecount();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Treasure"))

        {
            myAudiosource.PlayOneShot(treasuresound);
            myGameController.treasurecount();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("finish"))

        {
            SceneManager.LoadScene("Winner");
        }



    }
}
