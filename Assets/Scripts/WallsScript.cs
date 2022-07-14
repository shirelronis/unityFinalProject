using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour
{
    Animator animator;
    bool wallDown;

    void Start()
    {
        wallDown = false;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            wallDown = true;
            WallControl("Down");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (wallDown)
        {
            wallDown = false;
            WallControl("Up");
        }

    }

    private void WallControl(string s)
    {
        animator.SetTrigger(s);
    }

    void Update()
    {
        
    }
}
