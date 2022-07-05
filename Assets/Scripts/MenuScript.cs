using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Canvas quitMenu;
    public Button startText;  
    public Button exitText;
    void Start() {
        quitMenu.enabled = false;
    }
    public void ExitPress()    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }
   public void NoPress()  {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
    public void StartLevel(){
          SceneManager.LoadScene(1);
    }
    public void ExitGame(){
          Application.Quit();
    }
}
