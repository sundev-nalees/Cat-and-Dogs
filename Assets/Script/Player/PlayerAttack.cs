using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack :MonoBehaviour
{
    public static PlayerAttack Instance;

    private GameObject currentEnemy;
    private void Awake()
    {
        Instance = this;
        GameData.playerAttack = false;
    }

    public void PlayerAttackClick(Vector3 tileTransform)
    {
        Debug.Log(Spawner.Instance.enemies.Count);
        if (GameData.PlayerAttackCount <Spawner.Instance.enemies.Count)
        {
            for(int i = 0; i < 3; i++)
            {
                if (Spawner.Instance.enemies.ContainsKey(i))
                {
                    currentEnemy = Spawner.Instance.enemies[i];
                    Vector3 currentPlayerPosition = currentEnemy.transform.position;
                    if (tileTransform == currentPlayerPosition)
                    {
                        Destroy(currentEnemy);
                        Spawner.Instance.enemies.Remove(i);
                    }
                }
                
            }
            GameData.PlayerAttackCount++;
            if (GameData.PlayerAttackCount >= Spawner.Instance.enemies.Count)
            {
                GameData.PlayerAttackCount = 0;
                GameData.playerAttack = false;
                GameManager.Instance.ChangeState(GameState.EnemiesTurn);
            }
        }
      
        
    }
}
