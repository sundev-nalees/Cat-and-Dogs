using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUiManager : MonoBehaviour
{
    public static GameUiManager Instance;

    [SerializeField] private GameObject pausePopUp;
    [SerializeField] private GameObject exitPopUP;
    [SerializeField] private GameObject mainMenuPopup;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI enemyCount;
    [SerializeField] private TextMeshProUGUI gameStatus;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pausePopUp.SetActive(false);
        exitPopUP.SetActive(false);
        mainMenuPopup.SetActive(false);
        gameOver.SetActive(false);
    }

    public void Home()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        if (GameData.playerWon==true)
        {
            gameOverText.text = "You Won!!";
        }
        else
        {
            gameOverText.text = "You Lost!!";
        }
        gameOver.SetActive(true);
    }

    public void EnemyCount()
    {
        enemyCount.text = "Enemy Count: " + Spawner.Instance.enemies.Count;
    }

    public void PlayerStatus()
    {
        if (GameData.playerStatus)
        {
            gameStatus.text = "Move Player by one Square";
        }
        else
        {
            gameStatus.text = "Guss enemy position";
        }
    }

}
