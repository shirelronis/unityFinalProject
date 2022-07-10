using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopGameScript : MonoBehaviour
{
    public Text winText;  
    public Text looseText;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Debug.Log(PlayerScript.isWin);
        if (PlayerScript.isWin) {
            looseText.enabled = false;
            winText.enabled=true;
        }
        else
        {
             winText.enabled=false;
            looseText.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
}
