using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement Instance;

    private GameObject currentEnemy;

    private List<Vector3> adjacentTiles;

    private void Awake()
    {
        Instance = this;
    }
    
    public void MoveEnemy()
    {
        for(int i = 0; i < 3; i++)
        {
            
            currentEnemy = Spawner.Instance.enemies[i];
            Vector3 currentEnemyPosition = currentEnemy.transform.position;
            if (currentEnemy != null)
            {
                
                currentEnemy.transform.position = GetRandomAdjacentTile(currentEnemyPosition);
            }
        }
    }

    private Vector3 GetRandomAdjacentTile(Vector3 currentEnemyPosition)
    {
        List<Vector3> adjacentTiles = GetAdjacentTiles(currentEnemyPosition);

        if (adjacentTiles.Count > 0)
        {
            int randomIndex = Random.Range(0, adjacentTiles.Count);
            return adjacentTiles[randomIndex];
        }

        
        return currentEnemyPosition;
    }

    private List<Vector3> GetAdjacentTiles(Vector3 currentEnemyPosition)
    {
        List<Vector3> adjacentTiles = new List<Vector3>();

        Vector3 upTile = currentEnemyPosition + (Vector3.forward*10);
        if (GridManager.Instance.tiles.ContainsKey(upTile))
        {
            adjacentTiles.Add(upTile);
        }

        Vector3 downTile = currentEnemyPosition + (Vector3.back*10);
        if (GridManager.Instance.tiles.ContainsKey(downTile))
        {
            adjacentTiles.Add(downTile);
        }

        Vector3 leftTile = currentEnemyPosition + (Vector3.left*10);
        if (GridManager.Instance.tiles.ContainsKey(leftTile))
        {
            adjacentTiles.Add(leftTile);
        }

        Vector3 rightTile = currentEnemyPosition + (Vector3.right*10);
        if (GridManager.Instance.tiles.ContainsKey(rightTile))
        {
            adjacentTiles.Add(rightTile);
        }

        return(adjacentTiles);
    }
}
