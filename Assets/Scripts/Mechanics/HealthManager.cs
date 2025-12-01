using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int TakeDamage(Stats stats, int amount)
    {
        stats.curHealth -= amount;
        stats.curHealth = Mathf.Clamp(stats.curHealth, 0, stats.maxHealth);
        return stats.curHealth;
    }

    public int Heal(Stats stats, int amount)
    {
        stats.curHealth += amount;
        stats.curHealth = Mathf.Clamp(stats.curHealth, 0, stats.maxHealth);
        return stats.curHealth;
    }

    public void UpdateHearts(Stats stats, GameObject [] hearts)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < stats.curHealth);
        }
    }
}
