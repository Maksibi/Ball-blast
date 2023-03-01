using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private UICoinView coinUI;
    [SerializeField] private CoinCollector coinCollector;

    private int coinAmount;

    private void OnEnable()
    {
        coinCollector.OnCollectCoin += AddCoin;
    }
    private void OnDisable()
    {
        coinCollector.OnCollectCoin -= AddCoin;
    }
    private void AddCoin(int coinValue)
    {
        coinAmount += coinValue;
        GameManagers.Instance.playerData.PlayerCoins += coinValue;
    }
    public int GetCoinAmount()
    {
        return coinAmount;
    }
}
