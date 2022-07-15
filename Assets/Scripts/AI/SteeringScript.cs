using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringScript : MonoBehaviour
{
    public enum AIState { Idle, Seek, Flee, Arrive, Pursuit, Evade, Spawn }
    public Transform target;
    public float moveSpeed = 6;
    public float rotationSpeed = 1;
    private int minDistance = 5;
    private int safeDistance = 60;

    public AIState currentState;
   
    void Update()
    {
        if (ScoringSystemScript.score > 100)
        {
            currentState = AIState.Evade;
        }
        else if (ScoringSystemScript.score < 100 && ScoringSystemScript.score > 50)
        {
            currentState = AIState.Idle;
        }
        else
        {
            currentState = AIState.Pursuit;
        }

        switch (currentState)
        {
            case AIState.Idle:
                break;
            case AIState.Pursuit:
                Pursuit();
                break;
            case AIState.Evade:
                Evade();
                break;
        }
    }

    void Pursuit()
    {
        int iterationAhead = 30;
        Vector3 targetSpeed = target.gameObject.GetComponent<Rigidbody>().velocity;
        Vector3 targetFuturePosition = target.transform.position + (targetSpeed * iterationAhead);
        Vector3 direction = targetFuturePosition - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude > minDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }

    void Evade()
    {
        int iterationAhead = 30;
        Vector3 targetSpeed = target.gameObject.GetComponent<Rigidbody>().velocity ;
        Vector3 targetFuturePosition = target.position + (targetSpeed * iterationAhead);
        Vector3 direction = transform.position - targetFuturePosition;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        if (direction.magnitude < safeDistance)
        {
            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }
}
