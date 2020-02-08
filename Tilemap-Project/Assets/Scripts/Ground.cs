using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject player;
    public GameObject manager;
    PlayerManager playermanager;
    private void Start()
    {
        manager = GameObject.Find("Manager");
        playermanager = manager.GetComponent<PlayerManager>();
    }

    void Update()
    {
        if(player == null)
        {
            player = GameObject.Find("Player 1(Clone)");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playermanager.jump = true;
    }
}
