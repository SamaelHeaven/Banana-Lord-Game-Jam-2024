using UnityEngine;

public class Upgrades
{
    public static void Health(int healthValue)
    {
        var takeDamage = GameObject.Find("HitBox").GetComponent<TakeDamage>();
        TakeDamage.maxHealth += healthValue;
        takeDamage.Heal(healthValue);
    }

    public static void MoveSpeed(float speedBonus)
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().IncreaseSpeed(speedBonus);
    }

    public static void ShootingSpeed(float shootingSpeed)
    {
        GameObject.Find("BulletShooter").GetComponent<BulletShooter>().IncreaseSpeed(shootingSpeed);
    }
}