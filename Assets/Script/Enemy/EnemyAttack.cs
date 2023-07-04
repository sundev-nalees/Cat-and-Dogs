using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static EnemyAttack Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Attack()
    {
        for(int j = 0; j < 3; j++)
        {
            GameObject selectedTile = GridManager.Instance.GetRandomTile();
            for (int i = 1; i <= 3; i++)
            {
                Debug.Log("Eda sherikum"+selectedTile.transform.position);
                if (Spawner.Instance.players.ContainsKey(i))
                {
                    GameObject player = Spawner.Instance.players[i];
                    Vector3 playerPosition = player.transform.position;
                    Vector3 tilePosition = selectedTile.transform.position;

                    if (playerPosition == tilePosition)
                    {
                        Destroy(player);
                        Spawner.Instance.players.Remove(i);
                    }
                }
                   
            }
        }
        GameManager.Instance.ChangeState(GameState.PlayerTurn);
        
    }
}
