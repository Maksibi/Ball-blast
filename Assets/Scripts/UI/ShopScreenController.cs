using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreenController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinAmountText;
    [SerializeField] private TextMeshProUGUI damageUpgradePriceText, firerateUpgradePriceText, projectileAmountUpgradePriceText;
    [SerializeField] private TextMeshProUGUI damageUpgradesText, firerateUpgradesText, projectileAmountUpgradesText;
    [SerializeField] private Button damageButton, firerateButton, projectileAmountButton, backButton;

    private int damageUpgradePrice, firerateUpgradePrice, projectileAmountUpgradePrice;

    private PlayerData playerData;

    private void Awake()
    {
        playerData = GameManagers.Instance.playerData;

        damageUpgradePrice = 4 * playerData.DamageUpgrades / 2 + playerData.DamageUpgrades % 2;
        firerateUpgradePrice = 8 * playerData.FirerateUpgrades / 2 + playerData.FirerateUpgrades % 2;
        projectileAmountUpgradePrice = 16 * playerData.ProjectileAmountUpgrades / 2 + playerData.ProjectileAmountUpgrades % 2 ;
    }
    private void OnEnable()
    {
        damageButton.onClick.AddListener(UpgradeDamage);
        firerateButton.onClick.AddListener(UpgradeFirerate);
        projectileAmountButton.onClick.AddListener(UpgradeProjectileAmount);
        backButton.onClick.AddListener(playerData.SavePlayerData);
    }
    private void OnDisable()
    {
        damageButton.onClick.RemoveListener(UpgradeDamage);
        firerateButton.onClick.RemoveListener(UpgradeFirerate);
        projectileAmountButton.onClick.RemoveListener(UpgradeProjectileAmount);
        backButton.onClick.RemoveListener(playerData.SavePlayerData);
    }
    private void Start()
    {
        UpdateText();
    }
    private void UpgradeDamage()
    {
        if (playerData.PlayerCoins >= damageUpgradePrice)
        {
            float damageUpgradeValue = playerData.TurretDamage;

            playerData.TurretDamage += damageUpgradeValue;
            playerData.PlayerCoins -= damageUpgradePrice;
            playerData.DamageUpgrades++;
            playerData.SavePlayerData();
            UpdateText();
        }
    }
    private void UpgradeFirerate()
    {
        if (playerData.PlayerCoins >= firerateUpgradePrice)
        {
            float firerateUpgradeValue = playerData.TurretFirerate;

            playerData.TurretFirerate -= firerateUpgradeValue / 100 * 10;
            playerData.PlayerCoins -= firerateUpgradePrice;
            playerData.FirerateUpgrades++;
            playerData.SavePlayerData();
            UpdateText();
        }
    }
    private void UpgradeProjectileAmount()
    {
        if (playerData.PlayerCoins >= projectileAmountUpgradePrice)
        {
            int projectileAmountUpgradeValue = playerData.TurretProjectileAmount;

            playerData.TurretProjectileAmount += projectileAmountUpgradeValue / 2 + projectileAmountUpgradeValue % 2;
            playerData.PlayerCoins -= projectileAmountUpgradePrice;
            playerData.ProjectileAmountUpgrades++;
            playerData.SavePlayerData();
            UpdateText();
        }
    }
    private void UpdateText()
    {
        playerData.LoadPlayerData();

        coinAmountText.text = $"Coins: {playerData.PlayerCoins}";

        damageUpgradePriceText.text = $"Цена:{damageUpgradePrice}";
        firerateUpgradePriceText.text = $"Цена: {firerateUpgradePrice}";
        projectileAmountUpgradePriceText.text = $"Цена:{projectileAmountUpgradePrice}";

        damageUpgradesText.text = $"Урон: {playerData.TurretDamage}   +{playerData.DamageUpgrades}";
        firerateUpgradesText.text = $"Скорострельность: {playerData.TurretFirerate}     +{playerData.FirerateUpgrades}";
        projectileAmountUpgradesText.text = $"Кол-во снарядов: {playerData.TurretProjectileAmount}   +{playerData.ProjectileAmountUpgrades}";
    }
}
