using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{
    public AudioClip enemyHitSound;
    public int playerSpeed = 5;
    public int playerLives = 3;
    // public int score = 0;
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

        if(Input.GetKey(KeyCode.S))
        {
            ShootRay();
        }

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
                // GUI.Label(new Rect(10f, 40f, 100, 20), "Score : " + score);

    }

    void ShootRay()
    {
        Vector3 offset = new Vector3(0.0f, 0.5f, 0.0f);

        if (Physics.Raycast(transform.position + offset, transform.TransformDirection(Vector3.forward),
            out RaycastHit hitInfo, 20f) && hitInfo.collider.tag == "Enemy")
        {
            Debug.Log("Player shot enemy");
            Debug.DrawRay(transform.position + offset,
                transform.TransformDirection(Vector3.forward) * hitInfo.distance,
                Color.red);

            playSound();
            Destroy(hitInfo.transform.gameObject);
        }
        else
        {
            Debug.Log("Player didn't hurt the enemy");
            Debug.DrawRay(transform.position + offset,
                transform.TransformDirection(Vector3.forward) * 20f,
                Color.green);
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
