using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameScreen : MonoBehaviour
{
    [SerializeField] private LevelState levelState;
    [SerializeField] private SceneHelper sceneHelper;
    [SerializeField] private GameObject buttonsMenu, resumeButton, exitButton, restartButton, nextLevelButton;

    private PlayerData playerData;
    private void Start()
    {
        playerData = GameManagers.Instance.playerData;   
    }
    private void OnEnable()
    {
        levelState.Defeat.AddListener(OnDefeat);
        levelState.Passed.AddListener(OnPassLevel);
    }
    private void OnDisable()
    {
        levelState.Defeat.RemoveListener(OnDefeat);
        levelState.Passed.RemoveListener(OnPassLevel);
    }
    private void OnPassLevel()
    {
        buttonsMenu.SetActive(true);
        nextLevelButton.SetActive(true);
        exitButton.SetActive(true);
        restartButton.SetActive(true);
        resumeButton.SetActive(false);
    }
    private void OnDefeat()
    {
        buttonsMenu.SetActive(true);
        nextLevelButton.SetActive(false);
        exitButton.SetActive(true);
        restartButton.SetActive(true);
        resumeButton.SetActive(false);
    }

}
