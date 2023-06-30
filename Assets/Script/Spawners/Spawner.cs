using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 playerOffset;

    private Dictionary<Vector3, GameObject> players;
    private Dictionary<Vector3, GameObject> enemies;
    private void Awake()
    {
        Instance = this;
    }
 
    public void SpawnPlayer(int row,int col)
    {
        players = new Dictionary<Vector3, GameObject>();
        for(int i = 0; i < 3; i++)
        {
            if (GridManager.Instance.tiles.TryGetValue(new Vector3(row, 0f, col), out GameObject tile))
            {
                GameObject player = Instantiate(playerPrefab, tile.transform.position + playerOffset, Quaternion.identity);

                players[new Vector3(row, 0f, col)] = player;
            }
            col++;
        }
        GameManager.Instance.ChangeState(GameState.SpawnEnemies);

    }
    public void SpawnEnemy()
    {
        enemies = new Dictionary<Vector3, GameObject>();
        for(int i = 0; i <3; i++)
        {
            int col = Random.Range(0, 10);
            Vector3 enemyPosition = new Vector3(4f, 0f, col);

            while (enemies.ContainsKey(enemyPosition))
            {
                col = Random.Range(0, 10);
                enemyPosition = new Vector3(4f, 0f, col);
            }

            if (GridManager.Instance.tiles.TryGetValue(enemyPosition, out GameObject tile))
            {
                GameObject enemy = Instantiate(enemyPrefab, tile.transform.position + playerOffset, Quaternion.identity);
                enemy.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                enemies[new Vector3(4f, 0f, col)] = enemy;
            }
        }
        

    }

}


