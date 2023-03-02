using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CartInput : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Mobile
    }

    [SerializeField] private Button leftButton, rightButton, shootButton;
    [SerializeField] private Turret turret;

    [SerializeField] private ControlMode controlMode;

    private Vector2 movement;
    private PlayerInput input;

    private bool leftIsPressed, rightIsPressed, shootIsPressed;

    public Vector2 MovementDir => movement;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            controlMode = ControlMode.Mobile;
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(true);
            shootButton.gameObject.SetActive(true);
            input.SwitchCurrentControlScheme();
            ControlKeyboard();
        }
        else
        {
            controlMode = ControlMode.Keyboard;
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(false);
            shootButton.gameObject.SetActive(false);
            ControlMobile();
        }
    }
    private void Update()
    {
        if (controlMode == ControlMode.Keyboard) ControlKeyboard();
        if (controlMode == ControlMode.Mobile) ControlMobile();
    }
    private void ControlMobile()
    {
        if (leftIsPressed) movement = Vector2.left;
        if (rightIsPressed) movement = Vector2.right;
        if (!leftIsPressed & !rightIsPressed) movement = Vector2.zero;

        if (shootIsPressed) turret.Shoot();
    }
    private void ControlKeyboard()
    {
        movement = Vector2.zero;

        leftIsPressed = Keyboard.current[Key.A].isPressed;
        rightIsPressed = Keyboard.current[Key.D].isPressed;
        shootIsPressed = Keyboard.current[Key.Space].isPressed;

        if (leftIsPressed) movement = Vector2.left;
        if (rightIsPressed) movement = Vector2.right;
        if (!leftIsPressed & !rightIsPressed) movement = Vector2.zero;

        if (shootIsPressed) turret.Shoot();
    }
    private void Awake()
    {
        input = new PlayerInput();
    }
    /*private void OnEnable()
    {
        input.enabled = true;
    }
    private void OnDisable()
    {
        input.enabled = false;
    }*/
    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    public void OnShoot()
    {
        turret.Shoot();
    }
    public void LeftButtonIsDown()
    {
        leftIsPressed = true;
    }
    public void LeftButtonIsUp()
    {
        leftIsPressed = false;
    }
    public void RightButtonIsDown()
    {
        rightIsPressed = true;
    }
    public void RightButtonIsUp()
    {
        rightIsPressed = false;
    }
    public void OnShootButton()
    {
        shootIsPressed = true;
    }
}
