using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;

    // Check the player's current position using the reference to PlayerMovement script
    Vector3 noTerrainPosition;

    public LayerMask terrainMask;
    PlayerMovement pm;


    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
     chunkChecker();   
    }

   void chunkChecker()
    {
        // Check right side
        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }

        // Check left side
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }
        }

        // Check top side
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        // Check bottom side
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -20, 0);
                SpawnChunk();
            }
        }

        // Check top-left side
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }
        }

        // Check top-right side
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 20, 0);
                SpawnChunk();
            }
        }
        
        // Check bottom-left side
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }
        }
        // Check bottom-right side
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, -20, 0);
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
    }
}
