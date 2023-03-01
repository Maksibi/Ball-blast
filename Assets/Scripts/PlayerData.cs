using UnityEngine;

public class PlayerData
{
    public const string PLAYER_COINS = "playerCoins", TURRET_DAMAGE = "turretDamage", TURRET_FIRERATE = "turretFirerate",
    TURRET_PROJECTILE_AMOUNT = "turretProjectileAmount", DAMAGE_UPGRADES = "damageUpgrades", 
    FIRERATE_UPGRADES = "firerateUpgrades", PROJECTILE_AMOUNT_UPGRADES = "projectileAmountUpgrades", CURRENT_LEVEL = "currentLevel";


    public const int playerDefaultCoins = 0, turretDefaultProjectileAmount = 1, defaultDamageUpgrades = 1,
                                                                        defaultFirerateUpgrades = 1, defaultProjectileAmountUpgrades = 1, defaultCurrentLevel = 1;

    public const float turretDefaultDamage = 1.0f, turretDefaultFirerate = 1.0f;


    public void SaveFloat(string parameter, float value) => PlayerPrefs.SetFloat(parameter, value);
    public float LoadFloat(string parameter, float defaultValue) => PlayerPrefs.GetFloat(parameter, defaultValue);

    public void SaveInt(string parameter, int value) => PlayerPrefs.SetInt(parameter, value);
    public int LoadInt(string parameter, int defaultValue) => PlayerPrefs.GetInt(parameter, defaultValue);


    public int PlayerCoins { set; get; }
    public int FirerateUpgrades { set; get; }
    public int DamageUpgrades { set; get; }
    public int ProjectileAmountUpgrades { set; get; }
    public int TurretProjectileAmount { set; get; }
    public int CurrentLevel { set; get; }
    public float TurretFirerate { set; get; }
    public float TurretDamage { set; get; }


    public PlayerData()
    {
        LoadPlayerData();
    }
    public void SavePlayerData()
    {
        SaveInt(PLAYER_COINS, PlayerCoins);
        SaveInt(TURRET_PROJECTILE_AMOUNT, TurretProjectileAmount);
        SaveInt(DAMAGE_UPGRADES, DamageUpgrades);
        SaveInt(FIRERATE_UPGRADES, FirerateUpgrades);
        SaveInt(PROJECTILE_AMOUNT_UPGRADES, ProjectileAmountUpgrades);
        SaveInt(CURRENT_LEVEL, CurrentLevel);

        SaveFloat(TURRET_FIRERATE, TurretFirerate);
        SaveFloat(TURRET_DAMAGE, TurretDamage);
    }
    public void LoadPlayerData()
    {
        PlayerCoins = LoadInt(PLAYER_COINS, playerDefaultCoins);
        TurretProjectileAmount = LoadInt(TURRET_PROJECTILE_AMOUNT, turretDefaultProjectileAmount);
        DamageUpgrades = LoadInt(DAMAGE_UPGRADES, defaultDamageUpgrades);
        FirerateUpgrades = LoadInt(FIRERATE_UPGRADES, defaultFirerateUpgrades);
        ProjectileAmountUpgrades = LoadInt(PROJECTILE_AMOUNT_UPGRADES, defaultProjectileAmountUpgrades);
        CurrentLevel = LoadInt(CURRENT_LEVEL, defaultCurrentLevel);

        TurretFirerate = LoadFloat(TURRET_FIRERATE, turretDefaultFirerate);
        TurretDamage = LoadFloat(TURRET_DAMAGE, turretDefaultDamage);
    }
}