using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] GameObject playerModel;

    Player player;

    void Update()
    {
        if (player.currentWeapon == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerModel.GetComponent<Animation>().Play("KnifeSwing");
            }

        }
    }
}
