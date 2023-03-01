using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static LevelBoundary Instance;

    [SerializeField] private Vector2 screenResolution;
    [SerializeField] GameObject leftEdge, rightEdge, bottomEdge;
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (Application.isEditor == false & Application.isPlaying == true)
        {
            screenResolution.x = Screen.width;
            screenResolution.y = Screen.height;
        }
        leftEdge.transform.position = new Vector2(leftBorder, 0);
        rightEdge.transform.position = new Vector2(rightBorder, 0);
        bottomEdge.transform.position = new Vector2(0, -3.8f);
    }
    public float leftBorder
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        }
    }
    public float rightBorder
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(screenResolution.x, 0, 0)).x;
        }
    }
}
