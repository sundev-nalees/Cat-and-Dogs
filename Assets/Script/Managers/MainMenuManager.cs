using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selection;

    private void Start()
    {
        mainMenu.SetActive(true);
        selection.SetActive(false);
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        selection.SetActive(true);
    }

    public void EXit()
    {
        Application.Quit();
    }

    public void Dog()
    {
        GameData.characterSelection = true;
        SceneManager.LoadScene(1);

    }

    public void Cat()
    {
        GameData.characterSelection = false;
        SceneManager.LoadScene(1);
    }
}
