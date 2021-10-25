using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = gameObject.GetComponent<Player>();
        Pistol pistol = other.gameObject.GetComponent<Pistol>();
        Shotgun shotgun = other.gameObject.GetComponent<Shotgun>();
        Sniper sniper = other.gameObject.GetComponent<Sniper>();
        AutomaticGun automatic = other.gameObject.GetComponent<AutomaticGun>();
        Knife knife = other.gameObject.GetComponent<Knife>();
        if (pistol)
        {
            player.projectileFiringPeriod = 2f;
            player.isUnarmed = false;
            Destroy(other.gameObject);
        }
        else if (shotgun)
        {
            player.projectileFiringPeriod = 2f;
            player.isUnarmed = false;
            Destroy(other.gameObject);
        }
        else if (sniper)
        {
            player.projectileFiringPeriod = 3f;
            player.isUnarmed = false;
            Destroy(other.gameObject);
        }
        else if (automatic)
        {
            player.projectileFiringPeriod = 0.1f;
            player.isUnarmed = false;
            Destroy(other.gameObject);
        }
        else if (knife)
        {
            player.projectileFiringPeriod = 0f;
            player.isUnarmed = false;
            Destroy(other.gameObject);
        }
        else { return; }
    }
}