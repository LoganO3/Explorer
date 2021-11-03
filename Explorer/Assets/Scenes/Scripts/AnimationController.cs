using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameObject playerModel;

    void Update()
    {
        if (!playerModel) { return;}
       else if (playerModel.GetComponent<Player>().currentWeapon == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerModel.GetComponent<Animator>().Play("KnifeSwing");
            }
        }
    }
}
