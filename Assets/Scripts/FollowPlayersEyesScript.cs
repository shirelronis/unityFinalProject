using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayersEyesScript : MonoBehaviour
{
    public Transform player;
     
    void LateUpdate()   {
        transform.rotation = player.rotation;
    }
}
