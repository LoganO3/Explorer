using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (gameObject.layer == 10)
        {
            player.projectileFiringPeriod = 1f;
            player.isUnarmed = false;
        }
        else if (gameObject.layer == 11)
        {
            player.projectileFiringPeriod = .5f;
            player.isUnarmed = false;
        }
        else if (gameObject.layer == 12)
        {
            player.projectileFiringPeriod = 2.5f;
            player.isUnarmed = false;
        }
        else if (gameObject.layer == 13)
        {
            player.projectileFiringPeriod = 3f;
            player.isUnarmed = false;
        }
        else {return;}
    }
}
