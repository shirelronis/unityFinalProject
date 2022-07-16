using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{
    public int currentSceneIndex = 1;
    public int numberOfGhostlers = 4;
    public static int killedGhostlers = 0;
    public AudioClip ShootingSound;
    public int playerSpeed = 5;
    public static int playerLives = 3;
    public Rigidbody bullet;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // float amtToMove=playerSpeed*Input.GetAxis("Horizontal")*Time.deltaTime;
        // transform.Translate(Vector3.right * amtToMove);

        if (playerLives < 0)
        {
            //losing
            SceneManager.LoadScene(5);
        }

        if (gameObject.transform.position.y < -2)
        {
            playerLives--;
            gameObject.transform.position = startPosition;
            ScoringSystemScript.score = 0;
        }

        if(killedGhostlers >= numberOfGhostlers)
        {
            NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShootBullet();
        }
    }

    public void NextLevel()
    {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
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
            playSound();
        }
    }

    void playSound()
    {
        if (ShootingSound != null)
        {
            AudioSource.PlayClipAtPoint(ShootingSound, transform.position);
        }
    }
}
