using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color colorA;
    [SerializeField] private Color colorB;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Renderer renderer;

    private int colorCount=0;
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
}