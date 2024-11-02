using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpgradeButtons : MonoBehaviour
{
    public int currentCost;
    public playerMovement player;
    public playerShoot playerShoot;
    public PlayerHealth playerHealth;
    public TextMeshProUGUI text;
    public float healAmount;
    public ButtonType buttonType;
    public enum ButtonType
    {
        damage,
        heal
    }

    private void Start()
    {
        switch(buttonType)
        {
            case ButtonType.damage:
                text.text = "Current Damage - " + playerShoot.damage + "\nCost - " + currentCost;
                break;
            case ButtonType.heal:
                text.text = "Heal Amount - " + healAmount + "\nCost - " + currentCost;
                break;
        }


        

    }
    public void TryUpgradeDamage()
    {
        if (player.points >= currentCost)
        {
            player.points -= currentCost;
            playerShoot.damage++;
            currentCost++;
            text.text = "Current Damage - " + playerShoot.damage + "\nCost - " + currentCost;
        }
    }

    public void TryHeal()
    {
        if (player.points >= currentCost && playerHealth.currentHealth != playerHealth.maxHealth)
        {
            player.points -= currentCost;
            playerHealth.Heal(healAmount);
            text.text = "Heal Amount - " + healAmount + "\nCost - " + currentCost;
        }
    }
}
