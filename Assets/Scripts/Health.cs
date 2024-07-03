using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int healthBonusAmount = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (PlayerManager.instance.player.stats.currentHealth == PlayerManager.instance.player.stats.GetMaxHealthValue())
                return;

            if (PlayerManager.instance.player.stats.currentHealth + healthBonusAmount > PlayerManager.instance.player.stats.GetMaxHealthValue())
            {
                PlayerManager.instance.player.stats.IncreaseHealthBy(PlayerManager.instance.player.stats.GetMaxHealthValue() - PlayerManager.instance.player.stats.currentHealth);
                Destroy(gameObject);
            } else
            {
                PlayerManager.instance.player.stats.IncreaseHealthBy(healthBonusAmount);
                Destroy(gameObject);
            }
        }
    }
}
