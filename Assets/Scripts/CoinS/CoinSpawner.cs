using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField, Range(minRange, maxRange)] private float coinDropChance = 0.5f;
    [SerializeField] private GameObject coinPrefab;

    private float result;
    private const float minRange = 0.0f, maxRange = 1.0f;

    public void DropCoin(Vector2 position)
    {
        result = Random.Range(minRange, maxRange);
        if (result <= coinDropChance)
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }
}
