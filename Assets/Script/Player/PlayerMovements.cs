using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public static PlayerMovements Instance;

    private GameObject currentPlayer;
    private bool isWalking; 

    private void Awake()
    {
        Instance = this;
    }
    
    public void MovePlayer(Vector3 tilePosition)
    {
        if (GameData.playerTurn)
        {
            if (GameData.playerNum<=Spawner.Instance.players.Count)
            {
                if (Spawner.Instance.players.ContainsKey(GameData.playerNum))
                {
                    currentPlayer = Spawner.Instance.players[GameData.playerNum];
                    Vector3 currentPlayerPosition = currentPlayer.transform.position;
                    
                        if (IsAdjacentAndCardinal(tilePosition, currentPlayerPosition))
                        {

                            currentPlayer.transform.position = tilePosition;
                            GameData.playerNum++;
                            PlayerWalkAnimation();
                        } 
                }
                else
                {
                    GameData.playerNum++;
                    PlayerWalkAnimation();
                }
                    
                if (GameData.playerNum == Spawner.Instance.players.Count+1)
                {
                    PlayerWalkAnimation();
                    GameData.playerTurn = false;
                    GameManager.Instance.ChangeState(GameState.PlayerAttack);
                }
            }
           
        }
    }

    public bool IsAdjacentAndCardinal(Vector3 tilePosition, Vector3 playerPosition)
    {
        int rowDiff = Mathf.Abs((int)tilePosition.x - (int)playerPosition.x);
        int colDiff = Mathf.Abs((int)tilePosition.z - (int)playerPosition.z);

        return (rowDiff == 10 && colDiff == 0) || (rowDiff == 0 && colDiff == 10);
    }

    public void PlayerWalkAnimation()
    {
        if (GameData.playerNum < Spawner.Instance.players.Count+1)
        {
            if (Spawner.Instance.players.ContainsKey(GameData.playerNum))
            {
                GameObject player = Spawner.Instance.players[GameData.playerNum];
                Animator animator = player.GetComponent<Animator>();
                animator.SetBool("walk", true);
            }
        }

        if (GameData.playerNum > 1)
        {
            if (Spawner.Instance.players.ContainsKey(GameData.playerNum)||GameData.playerNum==Spawner.Instance.players.Count+1)
            {
                GameObject player = Spawner.Instance.players[GameData.playerNum - 1];
                Animator animator = player.GetComponent<Animator>();
                animator.SetBool("walk", false);
            }
        }
    }
}
