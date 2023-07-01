using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public static PlayerMovements Instance;

    private GameObject currentPlayer;

    private void Awake()
    {
        Instance = this;
    }
    
    public void MovePlayer(Vector3 tilePosition)
    {
        if (GameData.playerTurn)
        {
            if (GameData.playerNum<4)
            {
                currentPlayer = Spawner.Instance.players[GameData.playerNum];
                Vector3 currentPlayerPosition = currentPlayer.transform.position;
                if (currentPlayer != null)
                {
                   
                    float distance = Vector3.Distance(currentPlayerPosition, tilePosition);
                    if (IsAdjacentAndCardinal(tilePosition, currentPlayerPosition))
                    {
                        
                        currentPlayer.transform.position = tilePosition;
                        GameData.playerNum++;
                    }

                }

                if (GameData.playerNum == 4)
                {
                    GameData.playerTurn = false;
                    GameManager.Instance.ChangeState(GameState.EnemiesTurn);
                }
            }
           
        }
    }

    public bool IsAdjacentAndCardinal(Vector3 tilePosition, Vector3 playerPosition)
    {
        
        Debug.Log(tilePosition.x + " " + playerPosition.x);
        Debug.Log(tilePosition.z + " " + playerPosition.z);
        int rowDiff = Mathf.Abs((int)tilePosition.x - (int)playerPosition.x);
        int colDiff = Mathf.Abs((int)tilePosition.z - (int)playerPosition.z);

        return (rowDiff == 10 && colDiff == 0) || (rowDiff == 0 && colDiff == 10);
    }
}
