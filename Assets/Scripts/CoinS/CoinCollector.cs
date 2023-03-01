using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] static string coinTag = "Coin";

    public delegate void OnCoinCollect(int coinValue);
    public event OnCoinCollect OnCollectCoin;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(coinTag))
        {
            OnCollectCoin?.Invoke(1);
            GameManagers.Instance.playerData.SavePlayerData();
            Destroy(collision.gameObject);
        }
    }
}
