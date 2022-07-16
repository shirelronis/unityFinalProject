using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostlerMasterScript : MonoBehaviour
{
    public int speed = 5;
    private float dist;
    DateTime lastHit = DateTime.Now;

    public AudioClip enemyHitSound;
    private const int ENEMY_HIT = 20;
    private const int ENEMY_CLOSE = 1;

    private void Start()
    {
    }

    private void Update()
    {
        ShootRay();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //We hit player
        {
            if (DateTime.Now - lastHit < TimeSpan.FromSeconds(2.5))
                return;

            lastHit = DateTime.Now;
            GameObject player = collision.gameObject;
            ScoringSystemScript.score -= ENEMY_HIT;
            StartCoroutine(Stay());
        }
    }

    IEnumerator Stay()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
        yield return new WaitForSeconds(5);
        rigid.isKinematic = false;
    }

    void ShootRay()
    {
        Vector3 offset = new Vector3(0, -3, 0);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            out RaycastHit hitInfo, 20f) && hitInfo.collider.tag == "Player")
        {
            Debug.Log("Hit Something");
            Debug.DrawRay(transform.position + offset,
                transform.TransformDirection(Vector3.forward) * hitInfo.distance,
                Color.red);

            playSound();
            ScoringSystemScript.score -= ENEMY_CLOSE;
        }
        else
        {
            Debug.Log("Oops!");
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
