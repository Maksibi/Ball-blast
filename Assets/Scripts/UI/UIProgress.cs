using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgress : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentLevelText, nextLevelText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private LevelState levelState;
    [SerializeField] private StoneSpawner spawner;

    private PlayerData playerData;
    
    private void Start()
    {
        playerData = GameManagers.Instance.playerData;

        currentLevelText.text = playerData.CurrentLevel.ToString();
        nextLevelText.text = (playerData.CurrentLevel + 1).ToString();
        progressBar.value = 0;
    }
    private void OnEnable()
    {
        levelState.levelStatus += UpdateProgressBar;
        levelState.Defeat.AddListener(HideProgressSlider);
        levelState.Passed.AddListener(HideProgressSlider);
    }
    private void OnDisable()
    {
        levelState.levelStatus -= UpdateProgressBar;
        levelState.Defeat.RemoveListener(HideProgressSlider);
        levelState.Passed.RemoveListener(HideProgressSlider);
    }
    private void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }
    private void HideProgressSlider()
    {
        progressBar.transform.gameObject.SetActive(false);
    }
}
