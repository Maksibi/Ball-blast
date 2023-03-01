using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private Cart cart;
    [SerializeField] private StoneSpawner spawner;

    [Space(5)]
    public UnityEvent Passed, Defeat;

    public delegate void LevelStatus(float value);
    public event LevelStatus levelStatus;

    private float timer;
    private bool checkPassed;

    private int requiredStonesDestroyed;
 
    private PlayerData playerData;

    private void Start()
    {
        playerData = GameManagers.Instance.playerData;

        requiredStonesDestroyed = playerData.CurrentLevel + 7;
    }
    private void OnEnable()
    {
        spawner.Completed.AddListener(OnSpawnCompleted);
        cart.CollisionStone.AddListener(OnStoneCollision);
    }
    private void OnDisable()
    {
        spawner.Completed.RemoveListener(OnSpawnCompleted);
        cart.CollisionStone.RemoveListener(OnStoneCollision);
    }
    private void OnStoneCollision()
    {
        Time.timeScale = 0.0f;
        playerData.SavePlayerData();
        Defeat.Invoke();
    }
    private void OnSpawnCompleted()
    {
        checkPassed = true;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            levelStatus?.Invoke((float)spawner.destroyedStones / (float)requiredStonesDestroyed);
            if (checkPassed == true)
            {
                if (requiredStonesDestroyed <= spawner.destroyedStones )
                {
                    Time.timeScale = 0.0f;
                    GameManagers.Instance.playerData.PlayerCoins += 5;
                    GameManagers.Instance.playerData.SavePlayerData();
                    Passed.Invoke();
                }
            }
            timer = 0;
        }
    }
}
