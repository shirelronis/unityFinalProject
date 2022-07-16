using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLiveScript : MonoBehaviour
{
    public AudioClip collectSound;


    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Player") //We hit player
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            GameObject player = collision.gameObject;
            if (PlayerScript.playerLives < 5) {
                PlayerScript.playerLives++;
                Collect();
            }
        }
    }

    public void Collect(){
        Destroy(gameObject);
    }
}