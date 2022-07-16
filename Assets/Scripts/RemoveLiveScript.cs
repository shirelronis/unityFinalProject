using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLiveScript : MonoBehaviour
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
            PlayerScript.playerLives--;
        }
    }
}
