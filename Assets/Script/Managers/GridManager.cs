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

        for(float row = 0; row < numOfRows; row++)
        {
            for(float col = 0; col < numOfColums; col++)
            {
                float xPos = col * tileWidth;
                float zPos = row* tileHeight;
                GameObject tile = Instantiate(tilePrefab, new Vector3(xPos, 0f, zPos), Quaternion.identity);
                tile.name = $"Tile {col} {row}";
                bool isOffset = (row % 2 == 0 && col % 2 != 0) || (row % 2 != 0 && col % 2 == 0);
                Tile tileScript = tile.GetComponent<Tile>();
                
                if (tileScript != null)
                {
                    tileScript.TileColor(isOffset);
                }
                tiles[new Vector3(row*10, 0f, col*10)] = tile;
            }
            foreach(Vector3 key in tiles.Keys)
            {
                Debug.Log("tilekey: " + key);
            }
        }
        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
    }

    public GameObject GetRandomTile()
    {
        int randomRow = Random.Range(0, numOfRows);
        int randomCol = Random.Range(0, numOfColums);

        float xPos = randomRow * tileHeight;
        float zPos =  randomCol* tileWidth;

        Vector3 tilePosition = new Vector3(xPos, 0f, zPos);
        GameObject selecedTile = tiles[tilePosition];
        return selecedTile;
    }
}
