using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] private GameObject dogPrefab;
    [SerializeField] private GameObject catPrefab;
    [SerializeField] private Vector3 playerOffset;

    public Dictionary<int, GameObject> players;
    public Dictionary<int, GameObject> enemies;

    private GameObject playerPrefab;
    private GameObject enemyPrefab;

    private void Awake()
    {
        Instance = this;
    }
 
    public void SpawnPlayer(int row,int col)
    {
        if (GameData.characterSelection)
        {
             playerPrefab = dogPrefab;
        }
        else
        {
            playerPrefab = catPrefab;
        }
        
        int playerNum = 1;
        players = new Dictionary<int, GameObject>();
        
        for(int i = 0; i < 3; i++)
        {
            if (GridManager.Instance.tiles.TryGetValue(new Vector3(row*10, 0f, col*10), out GameObject tile))
            {
                GameObject player = Instantiate(playerPrefab, tile.transform.position + playerOffset, Quaternion.identity);
                players[playerNum] = player;
            }
            playerNum++;
            col++;
        }
        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemy()
    {
        if (GameData.characterSelection==false)
        {
            enemyPrefab = dogPrefab;
        }
        else
        {
            enemyPrefab = catPrefab;
        }

        enemies = new Dictionary<int, GameObject>();
        for(int i = 0; i <3; i++)
        {
            int col = Random.Range(0, 10);
            Vector3 enemyPosition = new Vector3(40f, 0f, col*10);

            while (enemies.ContainsKey(i))
            {
                col = Random.Range(0, 10);
                enemyPosition = new Vector3(40f, 0f, col*10);
            }

            if (GridManager.Instance.tiles.TryGetValue(enemyPosition, out GameObject tile))
            {
                GameObject enemy = Instantiate(enemyPrefab, tile.transform.position + playerOffset, Quaternion.identity);
                enemy.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                Transform childTransform = enemy.transform.Find("Child");
                if (childTransform != null)
                {
                    GameObject childObject = childTransform.gameObject;
                    childObject.SetActive(false);
                }
                enemies[i] = enemy;
            }
        }
        GameManager.Instance.ChangeState(GameState.PlayerTurn);

    }
}


