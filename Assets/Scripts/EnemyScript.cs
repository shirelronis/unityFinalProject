using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed = 5;
    private int waypointIndex;
    private float dist;

    public AudioClip enemyHitSound;
    private const int ENEMY_HIT = 20;
    private const int ENEMY_CLOSE = 1;

    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    private void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
        ShootRay();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }


    public void OnTriggerEnter(Collider other)
    {
        playSound();
        if (other.tag == "Player")
        {
            ScoringSystemScript.score -= ENEMY_HIT;
        }
    }

    void ShootRay()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            out RaycastHit hitInfo, 20f) && hitInfo.collider.tag == "Player")
        {
            Debug.Log("Hit Something");
            Debug.DrawRay(transform.position,
                transform.TransformDirection(Vector3.forward) * hitInfo.distance,
                Color.red);

            playSound();
            ScoringSystemScript.score -= ENEMY_CLOSE;
        }
        else
        {
            Debug.Log("Oops!");
            Debug.DrawRay(transform.position,
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