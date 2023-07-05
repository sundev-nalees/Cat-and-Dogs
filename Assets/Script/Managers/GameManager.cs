using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.SpawnTiles();
                break;
            case GameState.SpawnPlayer:
                Spawner.Instance.SpawnPlayer(0, 4); 
                break;
            case GameState.SpawnEnemies:
                Spawner.Instance.SpawnEnemy();
                break;
            case GameState.PlayerTurn:
                GameData.playerTurn=true;
                GameData.playerNum = 1;
                GameData.playerStatus = true;
                GameUiManager.Instance.PlayerStatus();
                PlayerMovements.Instance.PlayerWalkAnimation();
                break;
            case GameState.PlayerAttack:
                GameData.playerAttack = true;
                GameData.playerStatus = false;
                GameUiManager.Instance.PlayerStatus();
                break;
            case GameState.EnemiesTurn:
                EnemyMovement.Instance.MoveEnemy();
                break;
            case GameState.EnemiesAttack:
                EnemyAttack.Instance.Attack();
                    break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }
    }
}

public enum GameState
{
    GenerateGrid=0,
    SpawnPlayer=1,
    SpawnEnemies=2,
    PlayerTurn=3,
    PlayerAttack=4,
    EnemiesTurn=5,
    EnemiesAttack=6
}
