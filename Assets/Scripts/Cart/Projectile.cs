using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed, lifeTime;
     private float damage;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent<Destructible>(out var destructible)) 
        {
            destructible.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.TryGetComponent<Destructible>(out var destructible)) destructible.ApplyDamage(damage);

        Destroy(gameObject);

        Debug.Log("paw");
    }
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
