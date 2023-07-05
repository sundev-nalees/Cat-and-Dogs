using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color colorA;
    [SerializeField] private Color colorB;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Renderer renderer;

    private PlayerMovements playerMovements;

    private int colorCount=0;

    private void Awake()
    {
        playerMovements = PlayerMovements.Instance;
    }

    public void TileColor(bool isOffset)
    {
        renderer.material.color = isOffset ? colorA : colorB;
        if (renderer.material.color == colorA)
        {
            colorCount = 1;
        }
    }



    private void OnMouseEnter()
    {
        renderer.material.color = highlightColor;
    }

    private void OnMouseExit()
    {
        if (colorCount == 1)
        {
            renderer.material.color = colorA;
        }
        else
        {
            renderer.material.color = colorB;
        }
    }

    private void OnMouseDown()
    {
        if (GameData.playerAttack)
        {
            PlayerAttack.Instance.PlayerAttackClick(transform.position);
        }
        else
        {
            playerMovements.MovePlayer(transform.position);
        }
        
    }
}
