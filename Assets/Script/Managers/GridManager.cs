using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private int numOfRows;
    [SerializeField] private int numOfColums;
    [SerializeField] private float tileWidth=1f;
    [SerializeField] private float tileHeight=1f;
    [SerializeField] private GameObject tilePrefab;

    public Dictionary<Vector3, GameObject> tiles;

    private void Awake()
    {
        Instance = this;
    }
 
    public void SpawnTiles()
    {
        tiles = new Dictionary<Vector3, GameObject>();
        for(int row = 0; row < numOfRows; row++)
        {
            for(int col = 0; col < numOfColums; col++)
            {
                float xPos = col * tileWidth;
                float yPos = row * tileHeight;
                GameObject tile = Instantiate(tilePrefab, new Vector3(xPos, 0f, yPos), Quaternion.identity);
                tile.name = $"Tile {row} {col}";
                bool isOffset = (row % 2 == 0 && col % 2 != 0) || (row % 2 != 0 && col % 2 == 0);
                Tile tileScript = tile.GetComponent<Tile>();
                if (tileScript != null)
                {
                    tileScript.TileColor(isOffset);
                }

                tiles[new Vector3(row, 0f, col)] = tile;
            }

        }

        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
    }
}
