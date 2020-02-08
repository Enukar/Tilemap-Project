using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;


    void Update()
    {
        if(player != null)
        {
            transform.position = player.transform.position + offset;
        }
        if(player == null)
        {
            player = GameObject.Find("Player 1(Clone)");
        }
    }
}
