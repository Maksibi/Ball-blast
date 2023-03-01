using TMPro;
using UnityEngine;

public class UICoinView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinAmountText;
    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private CoinController coinController;

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
        coinValue = coinController.GetCoinAmount();
        coinAmountText.text = $"Coins: {coinValue}";
    }
}
