using UnityEngine;

public class CoinRigidbody : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out LevelEdge levelEdge) && levelEdge.Type == EdgeType.Bottom)
        {
            rb2D.bodyType = RigidbodyType2D.Static;
        }
    }
}
