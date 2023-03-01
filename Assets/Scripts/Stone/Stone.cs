using UnityEngine;

[RequireComponent(typeof(StoneMovement))]
public class Stone : Destructible
{
    [SerializeField] private Size size;
    [SerializeField] private Stone stoneObject;
    [SerializeField] private float spawnUpForce;
    [SerializeField] private SpriteRenderer view;
    [SerializeField] private CoinSpawner coinSpawner;

    private StoneMovement movement;

    public delegate void StonesSpawned(Stone stone);
    public event StonesSpawned StoneSpawn;

    private void Awake()
    {
        movement = GetComponent<StoneMovement>();

        SetSize(size);
    }
    private void OnEnable()
    {
        Die += OnStoneDestroyed;
    }
    private void OnDisable()
    {
        Die -= OnStoneDestroyed;
    }
    public void SetColor(Color color)
    {
        view.color = color;
    }
    private void OnStoneDestroyed(Destructible destructible)
    {
        if (size != Size.Small)
        {
            SpawnStones();
        }
        coinSpawner.DropCoin(transform.position);
        Destroy(gameObject);
    }
    private void SpawnStones()
    {
        for (int i = 0; i < 2; i++)
        {
            Stone stone = Instantiate(this, transform.position, Quaternion.identity);
            stone.SetSize(size - 1);
            stone.maxHitPoints = Mathf.Clamp(maxHitPoints / 2, 1, maxHitPoints);
            stone.movement.AddVerticalVelocity(spawnUpForce);
            stone.movement.SetHorizontalDirection((i % 2 * 2) - 1);

            StoneSpawn?.Invoke(stone);
        }
    }
    public void SetSize(Size size)
    {
        if (size < 0) return;

        transform.localScale = GetVectorFromSize(size);
        this.size = size;
    }
    private Vector3 GetVectorFromSize(Size size)
    {
        if (size == Size.Small) return new Vector3(0.35f, 0.35f, 0.35f);
        if (size == Size.Medium) return new Vector3(0.5f, 0.5f, 0.5f);
        if (size == Size.Large) return new Vector3(0.75f, 0.75f, 0.75f);
        if (size == Size.Giant) return new Vector3(1, 1, 1);

        return Vector3.one;
    }

}
