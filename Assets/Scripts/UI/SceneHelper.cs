using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHelper : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private bool IsOnMainMenu = false;
    [SerializeField] private Button resumeButton, exitButton, restartButton, nextLevelButton;
    [SerializeField] private LevelState levelState;

    public delegate void OnPauseController(bool isPaused);
    public event OnPauseController Paused;

    private bool isPaused;

    private PlayerData playerData;

    private void Start()
    {
        isPaused = false;
        playerData = GameManagers.Instance.playerData;
    }
    private void OnEnable()
    {
        resumeButton.onClick.AddListener(Resume);
        exitButton.onClick.AddListener(ExitToMainMenu);
        restartButton.onClick.AddListener(RestartLevel);
        nextLevelButton.onClick.AddListener(StartNextLevel);
    }
    private void OnDisable()
    {
        resumeButton.onClick.RemoveListener(Resume);
        exitButton.onClick.RemoveListener(ExitToMainMenu);
        restartButton.onClick.RemoveListener(RestartLevel);
        nextLevelButton.onClick.RemoveListener(StartNextLevel);
    }
    /*private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) & !IsOnMainMenu)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                OnPause();
            }
            Paused?.Invoke(isPaused);
        }
    }*/
    public void RestartLevel()
    {
        playerData.SavePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OnPause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        if (PauseUI != null)
        {
            PauseUI.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        if (PauseUI != null)
        {
            PauseUI.SetActive(false);
        }
    }
    private void ExitToMainMenu()
    {
        GameManagers.Instance.playerData.SavePlayerData();
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    private void StartNextLevel()
    {
        playerData.CurrentLevel++;
        playerData.SavePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
