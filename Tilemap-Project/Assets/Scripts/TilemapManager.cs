using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject player;
    public int range = 3;
    bool PlayerSelected = false;
    public TileBase airTile;
    void Update()
    {
        if (PlayerSelected) 
        { 

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hover = Physics2D.OverlapPoint(mousePos);
        Vector3Int mouse = Vector3Int.FloorToInt(mousePos);
        Vector3 distance = player.transform.position;
        Vector3Int Distance = Vector3Int.FloorToInt(distance);

        int x = Mathf.Abs(mouse.x - Distance.x);
        int y = Mathf.Abs(mouse.y - Distance.y);


        if (Input.GetMouseButtonDown(0) && x < range && y < range)
            {
                //TileBase target = tilemap.GetTile(mouse);
                Debug.Log("You just ran tilemap.SetTile(mouse, null); at " + mouse + ", and you're on " + distance + ", that means you're only " + x + "," + y + " tiles away from it." );
                tilemap.SetTile(mouse, null);
            }


        }
        if(player == null)
            {
                player = GameObject.Find("Player 1(Clone)");
                PlayerSelected = true;
            }

    }

}
