using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject stoneMat;
    [SerializeField] private Color[] stoneColors;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] private float maxHitpointsRate;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitpointsPercentage;


    [Space(10)] public UnityEvent Completed;

    

    private float timer;
    private int spawnAmount, spawnedAmount, stoneMaxHitpoint, stoneMinHitpoint;
    [HideInInspector] public int destroyedStones = 0;

    private List<Stone> stones;
    public List<Stone> Stones => stones;

    private void Start()
    {
        stones = new List<Stone>();

        int damagePerSecond = (int)((turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate));

        stoneMaxHitpoint = (int)(damagePerSecond * maxHitpointsRate);
        stoneMaxHitpoint = (int)(stoneMaxHitpoint * minHitpointsPercentage);

        timer = spawnRate;
    }
    private void Awake()
    {
        spawnAmount = GameManagers.Instance.playerData.CurrentLevel + 5;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            Spawn();

            timer = 0;

            if (spawnedAmount == spawnAmount)
            {
                enabled = false;
                Completed.Invoke();
            }
        }
    }
    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stones.Add(stone);
        stone.Die += OnStoneDie;
        stone.StoneSpawn += AddSmallStonesToList;

        int index = Random.Range(0, stoneColors.Length);
        Color color = stoneColors[index];
        stone.SetColor(color);

        int value = Random.Range(1, 4);
        stone.SetSize((Size)value);
        stone.maxHitPoints = Random.Range(stoneMinHitpoint + 1, stoneMaxHitpoint + 1);

        spawnedAmount++;
    }
    private void OnStoneDie(Destructible destructible)
    {
        destroyedStones++;
        stones.Remove((Stone)destructible);
        destructible.Die -= OnStoneDie;
    }
    public void AddSmallStonesToList(Stone stone)
    {
        stones.Add(stone);
        stone.Die += OnStoneDie;
    }
}
