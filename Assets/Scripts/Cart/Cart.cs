using UnityEngine;
using UnityEngine.Events;

public class Cart : MonoBehaviour
{
    [SerializeField] private CartInput input;

    [Header("Movement")]
    [SerializeField] private float movementSpeed, vehicleWidth;

    [Header("Wheels")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRadius;

    [HideInInspector] public UnityEvent CollisionStone;

    private float deltaMovement, lastPositionX;
    private Vector3 movementTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stone stone = collision.transform.root.GetComponent<Stone>();

        if (stone != null) CollisionStone.Invoke();
    }
    private void Start()
    {
        movementTarget = transform.position;    
    }
    private void Update()
    {
        Move();
        RotateWheel();
    }
    private void Move()
    {
        lastPositionX = transform.position.x;

        Vector3 moveTarget = ClampMovementTarget(transform.position + (Vector3)input.MovementDir);

        transform.position = Vector3.MoveTowards(transform.position, moveTarget, movementSpeed * Time.deltaTime);

        deltaMovement = transform.position.x - lastPositionX;
    }
    private void RotateWheel()
    {
        float angle = (180 * deltaMovement) / (Mathf.PI * wheelRadius * 2);

        for (int i = 0; i < wheels.Length; i++) wheels[i].Rotate(0, 0, -angle);
    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }
    private Vector2 ClampMovementTarget(Vector3 target)
    {
        float leftBound = LevelBoundary.Instance.leftBorder + vehicleWidth * 0.5f, rightBound = LevelBoundary.Instance.rightBorder - vehicleWidth * 0.5f;

        Vector3 moveTarget = target;
        moveTarget.y = transform.position.y; 

        if (moveTarget.x < leftBound) moveTarget.x = leftBound;
        if (moveTarget.x > rightBound) moveTarget.x = rightBound;

        return moveTarget;
    }
}
