using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoldScript : MonoBehaviour
{
    public AudioClip collectSound;
    private const int GOLD_BONUS = 50;


    void OnTriggerEnter(Collider other)
    {
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        ScoringSystemScript.score += GOLD_BONUS;
        Destroy(gameObject);
    }
}
