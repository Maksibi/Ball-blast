using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButtonsScripts : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button leftButton, rightButton, shootButton;
    [SerializeField] private CartInput input;

    void Start()
    {
        input = new CartInput();

        
    }
    private void Awake()
    {
        
    }
    private void OnDestroy()
    {
        
    }
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        leftButton.OnPointerDown(eventData);
        rightButton.OnPointerDown(eventData);
        shootButton.OnPointerDown(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        leftButton.OnPointerUp(eventData);
        rightButton.OnPointerUp(eventData);
        shootButton.OnPointerUp(eventData);
    }
}
