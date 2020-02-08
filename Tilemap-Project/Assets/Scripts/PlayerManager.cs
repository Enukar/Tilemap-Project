using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject player;
    public float moveSpeed = 5;
    public bool jump = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) 
            {
            Jump();
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            player.transform.position += movement * Time.deltaTime * moveSpeed;
            }
        if (player == null) 
        { 
            player = GameObject.Find("Player 1(Clone)");
        }
    }
    void Jump()
    {

        if (Input.GetMouseButtonDown(1) && jump) 
        {
            jump = false;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
}
