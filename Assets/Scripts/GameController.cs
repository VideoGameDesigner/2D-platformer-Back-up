using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI LiveDisplay;
    

    private int lives;
    private int tokensfound;
    public static int alltokensfound;

    private int Lorediscfound;
    public static int all_lorefound;

    private int treasurefound;
    public static int alltreasurefound;



    // Start is called before the first frame update
    void Start()
    {
        
        tokensfound = 0;
        Lorediscfound = 0;
        treasurefound = 0;
        lives = 3;
    }

    public void addlife()

    {
        lives += 1;

    }

    public void minuslife ()
    {

        lives -= 1;
    }

    public void Tokencount()
    {

        tokensfound += 1;
    }

    public void Lorecount()
    {
        Lorediscfound += 1;
    }

    public void treasurecount()

    {
        treasurefound += 1;
    }


    // Update is called once per frame
    void Update()
    {
        LiveDisplay.text = "Lives:" + (lives.ToString("0"));

        if(lives == 0)

        {
            
            SceneManager.LoadScene("Gameover");
        }

        if(tokensfound >= 0)

        {
            alltokensfound = tokensfound;
        }

        if(Lorediscfound >= 0)

        {
            all_lorefound = Lorediscfound;
        }

        if(treasurefound >=0)

        {
            alltreasurefound = treasurefound;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit(); 
        }

    }

    
}
