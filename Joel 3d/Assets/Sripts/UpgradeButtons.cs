using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpgradeButtons : MonoBehaviour
{
    public int currentCost;
    public playerMovement player;
    public playerShoot playerShoot;
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = "Current Damage - " + playerShoot.damage + "\nCost - " + currentCost;

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
}
