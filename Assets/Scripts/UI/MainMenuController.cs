using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button playButton, shopButton, exitButton;
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        playButton.onClick.AddListener(Play);
        shopButton.onClick.AddListener(LoadData);
        exitButton.onClick.AddListener(Exit);
    }
    private void OnDisable()
    {
        playButton.onClick.RemoveListener(Play);
        shopButton.onClick.RemoveListener(LoadData);
        exitButton.onClick.RemoveListener(Exit);
    }
    private void Play()
    {
        SceneManager.LoadScene(1);
        LoadData();
    }
    private void LoadData()
    {
        GameManagers.Instance.playerData.LoadPlayerData();
    }
    private void Exit()
    {
        Application.Quit();
    }
}
