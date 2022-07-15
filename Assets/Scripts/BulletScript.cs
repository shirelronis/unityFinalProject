using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static int BULLET_HIT = 20;
    public int bulletSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = bulletSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * amountToMove);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayerScript.killedGhostlers++;
            ScoringSystemScript.score += BULLET_HIT;
            other.transform.position = new Vector3(Random.Range(-8f, 8), 6, 0);
            Destroy(other);
        }
    }
}
