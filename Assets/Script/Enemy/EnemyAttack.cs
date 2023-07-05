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
                if (Spawner.Instance.players.ContainsKey(i))
                {
                    GameObject player = Spawner.Instance.players[i];
                    Vector3 playerPosition = player.transform.position;
                    Vector3 tilePosition = selectedTile.transform.position;

                    if (playerPosition == tilePosition)
                    {
                        Destroy(player);
                        Spawner.Instance.players.Remove(i);

                        //player order rearrange
                        if (i < 3)
                        {
                            if (i == 2)
                            {
                                GameObject tempPlayer = Spawner.Instance.players[3];
                                Spawner.Instance.players.Remove(3);
                                Spawner.Instance.players.Add(2, tempPlayer);
                            }
                            else
                            {
                                for (i = 2; i <= 3; i++)
                                {
                                    if (Spawner.Instance.players.ContainsKey(i))
                                    {
                                        GameObject tempPlayer = Spawner.Instance.players[i];
                                        Spawner.Instance.players.Remove(i);
                                        Spawner.Instance.players.Add(i - 1, tempPlayer);
                                    }
                                    
                                }
                            }
                        }

                        if (Spawner.Instance.players.Count == 0)
                        {
                            GameData.playerWon = false;
                            GameUiManager.Instance.GameOver();
                        }
                    }
                }
                   
            }
        }

        GameManager.Instance.ChangeState(GameState.PlayerTurn);
    }
}
