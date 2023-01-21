using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Beaten : MonoBehaviour
{
    public TextMeshProUGUI Tokentotal;
    public TextMeshProUGUI Loretotal;
    public TextMeshProUGUI Treasuretotal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tokentotal.text = "Total bit tokens:" + GameController.alltokensfound.ToString("0");
        Loretotal.text = "Lore Disc Found:" + GameController.all_lorefound.ToString("0");
        Treasuretotal.text = "Treasure Chest Found:" + GameController.alltreasurefound.ToString("0");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

