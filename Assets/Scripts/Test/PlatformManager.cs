using TMPro;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    void Start()
    {
        text.text = Application.platform.ToString();
    }

}
