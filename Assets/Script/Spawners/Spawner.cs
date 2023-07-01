using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 playerOffset;

    public Dictionary<int, GameObject> players;
    public Dictionary<int, GameObject> enemies;

    
    private void Awake()
    {
        Instance = this;
    }
 
    public void SpawnPlayer(int row,int col)
    {
        int playerNum = 1;
        players = new Dictionary<int, GameObject>();
        List<Vector3> playerList = new List<Vector3>();
        for(int i = 0; i < 3; i++)
        {
            if (GridManager.Instance.tiles.TryGetValue(new Vector3(row, 0f, col), out GameObject tile))
            {
                GameObject player = Instantiate(playerPrefab, tile.transform.position + playerOffset, Quaternion.identity);

                players[playerNum] = player;
                
            }
            playerNum++;
            col++;
        }
        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
        for(int i = 0; i < playerList.Count; i++)
        {
            Debug.Log(playerList[i]);
        }
    }
    public void SpawnEnemy()
    {
        enemies = new Dictionary<int, GameObject>();
        for(int i = 0; i <3; i++)
        {
            int col = Random.Range(0, 10);
            Vector3 enemyPosition = new Vector3(4f, 0f, col);

            while (enemies.ContainsKey(i))
            {
                col = Random.Range(0, 10);
                enemyPosition = new Vector3(4f, 0f, col);
            }

            if (GridManager.Instance.tiles.TryGetValue(enemyPosition, out GameObject tile))
            {
                GameObject enemy = Instantiate(enemyPrefab, tile.transform.position + playerOffset, Quaternion.identity);
                enemy.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                enemies[i] = enemy;
            }
        }
        GameManager.Instance.ChangeState(GameState.PlayerTurn);

    }

   /* public GameObject GetPlayer(Vector3 position)
    {
        if (players.TryGetValue(position, out GameObject player))
        {
            return player;
        }

        return null;
    }*/
}


