using System;
using System.Collections;
using System.Collections.Generic;
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
                break;
            case GameState.EnemiesTurn:
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
    EnemiesTurn=4
}
