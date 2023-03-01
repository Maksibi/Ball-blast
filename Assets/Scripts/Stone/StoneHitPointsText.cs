using TMPro;
using UnityEngine;

[RequireComponent(typeof(Destructible))]
public class StoneHitPointsText : MonoBehaviour
{
    [SerializeField] private TextMeshPro hitpointText;
    private Destructible destructible;

    private void Start()
    {
        float hitpoints = destructible.GetHitPoints();

        if (hitpoints >= 1000) hitpointText.text = hitpoints / 1000 + "K";
        else hitpointText.text = hitpoints.ToString();
    }

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChangeHitPoints.AddListener(OnChangeHitpoint);
    }
    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitpoint);
    }
    private void OnChangeHitpoint()
    {
        float hitpoints = destructible.GetHitPoints();

        if (hitpoints >= 1000) hitpointText.text = hitpoints / 1000 + "K";
        else hitpointText.text = hitpoints.ToString();
    }
}
