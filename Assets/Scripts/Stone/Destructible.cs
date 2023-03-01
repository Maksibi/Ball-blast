using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Destructible : MonoBehaviour
{
    [HideInInspector] public UnityEvent ChangeHitPoints;

    [SerializeField] private GameObject DamageImpactEffect, DieImpactEffect;

    public delegate void OnDie(Destructible destructible);
    public event OnDie Die;

    private const float timer = 0.0f, onKillTimer = 0.0f;
    private float hitPoints;
    private bool IsDied = false;

    public int maxHitPoints;

    private IEnumerator OnDeath(float time)
    {
        hitPoints = 0;

        if (DieImpactEffect != null) Instantiate(DieImpactEffect);

        ChangeHitPoints.Invoke();

        yield return new WaitForSeconds(time);
        if(this != null & IsDied != true)
        {
            Die.Invoke(this);
        }
        
        IsDied = true;
    }
    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHitPoints.Invoke();
    }
    public void ApplyDamage(float damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();

        if (DamageImpactEffect != null) Instantiate(DamageImpactEffect);

        if (hitPoints <= 0)
        {
            StartCoroutine(OnDeath(timer));
        }
    }
    public void Kill()
    {
        if (IsDied) return;
        StartCoroutine(OnDeath(onKillTimer));
    }
    public float GetHitPoints()
    {
        return hitPoints;
    }
}
