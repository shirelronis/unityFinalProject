using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int playerSpeed = 5;
    public int playerLives = 3;
    public int score = 0;
    public static bool isWin = true;    
    // public Rigidbody bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float amtToMove=playerSpeed*Input.GetAxis("Horizontal")*Time.deltaTime;
        // transform.Translate(Vector3.right * amtToMove);

        if (playerLives == 0) {
            SceneManager.LoadScene(2);
            isWin = false;
        }
        else {
            isWin = true;
        }
    }

    public void OnGUI(){
        GUI.Label(new Rect(10f, 10f, 100, 20), "Lives : " + playerLives);
                GUI.Label(new Rect(10f, 40f, 100, 20), "Score : " + score);

    }
}
