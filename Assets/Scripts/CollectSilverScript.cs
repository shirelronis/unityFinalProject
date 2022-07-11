using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSilverScript : MonoBehaviour
{
    public AudioClip collectSound;
    private const int SILVER_BONUS = 10;


    void OnTriggerEnter(Collider other)
    {
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        ScoringSystemScript.score += SILVER_BONUS;
        Destroy(gameObject);
    }
}
