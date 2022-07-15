using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{
    public int numberOfGhostlers = 4;
    public static int killedGhostlers = 0;
    public AudioClip enemyHitSound;
    public int playerSpeed = 5;
    public int playerLives = 3;
    public Rigidbody bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float amtToMove=playerSpeed*Input.GetAxis("Horizontal")*Time.deltaTime;
        // transform.Translate(Vector3.right * amtToMove);
        if(killedGhostlers >= numberOfGhostlers)
        {
            //next level
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShootBullet();
        }

        if (playerLives == 0) {
            SceneManager.LoadScene(2);
            ScoringSystemScript.isWin = false;
        }
    }


    public void OnGUI(){
        GUI.Label(new Rect(10f, 10f, 100, 20), "Lives : " + playerLives);
    }

    void ShootBullet()
    {
        if(bullet != null)
        {
            Vector3 offset = new Vector3(0, 2, 0);
            Instantiate(bullet, transform.position + offset, Quaternion.identity);
        }
    }

    void playSound()
    {
        if (enemyHitSound != null)
        {
            AudioSource.PlayClipAtPoint(enemyHitSound, transform.position);
        }
    }
}
