using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float projectileInterval;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;

    private float fireRate, damage;
    [SerializeField]private int projectileAmount;

    public float Damage => damage;
    public int ProjectileAmount => projectileAmount;
    public float FireRate => fireRate;

    private float timer;
    private void Start()
    {
        PlayerData playerData = GameManagers.Instance.playerData;
        playerData.LoadPlayerData();
        damage = playerData.TurretDamage;
        fireRate = playerData.TurretFirerate;
        projectileAmount = playerData.TurretProjectileAmount;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    private void SpawnProjectile()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;
        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), transform.rotation);
            projectile.SetDamage(damage);
        }
    }
    public void Shoot()
    {
        if(timer >= fireRate)
        {
            SpawnProjectile();
            timer = 0;
        }
    }
    public int GetTurretProjectileAmount() => GameManagers.Instance.playerData.TurretProjectileAmount;
}
