using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Transform gunBarrel;
    [SerializeField] public GameObject projectile;
    [SerializeField] public float projectileFiringPeriod = 1f;

    public bool canShoot = true;
    float waitTimer = .25f;
    Player player;

    Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            StartCoroutine(ResetFiring());
        }
    }

    IEnumerator ResetFiring()
    {
        yield return new WaitForSeconds(projectileFiringPeriod);
        canShoot = true;
        StopCoroutine(ResetFiring());
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            
            if (player.IsUnarmedCheck() == true) { yield return new WaitForSeconds(waitTimer); }
            else if (canShoot == true)
            {
                GameObject projectiles = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation) as GameObject;
                projectiles.GetComponent<Rigidbody2D>().velocity = gunBarrel.up * -10f;
                canShoot = false;
                yield return new WaitForSeconds(projectileFiringPeriod);
                canShoot = true;
            }
            else
            { yield return new WaitForSeconds(waitTimer); }
        }
    }
}
