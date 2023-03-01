using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public static GameManagers Instance;
    public PlayerData playerData;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        playerData = new PlayerData();
    }
}
