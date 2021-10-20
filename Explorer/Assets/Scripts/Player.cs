using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float health = 100f;
    [SerializeField] float energy = 100f;
    [SerializeField] float energyDrainPeriod = 10f;
    [Header("Shooting")]
    [SerializeField] Transform gunBarrel;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileFiringPeriod = 1f;
    [Header("Misc")]
    [SerializeField] public int accessLevel = 0;
    [SerializeField] float invisabilityDurration = 1f;

    private Vector2 lookDirection;
    private float lookAngle;
    private Rigidbody2D body;
    

    Coroutine firingCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DrainEnergy());
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.x, lookDirection.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, -lookAngle - 90f);
        Move();
        Fire();
        EnergyDamage();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            HandleDamage(damageDealer);
            StartCoroutine(DrainEnergy());
        }
        else if (damageDealer)
        {
            HandleProjectileDamage(damageDealer);
            StartCoroutine(DrainEnergy());
        }
    }

    private void HandleDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HandleProjectileDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        var deltax = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltay = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltax;
        var newYPos = transform.position.y + deltay;
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void EnergyDamage()
    {
        if (energy >= 90)
        {
            moveSpeed = 10f;
        }
        else if (energy >= 80)
        {
            moveSpeed = 9f;
        }
        else if (energy >= 70)
        {
            moveSpeed = 8f;
        }
        else if (energy >= 60)
        {
            moveSpeed = 7f;
        }
        else if (energy >= 50)
        {
            moveSpeed = 6f;
        }
        else if (energy >= 40)
        {
            moveSpeed = 5f;
        }
        else if (energy >= 30)
        {
            moveSpeed = 4f;
        }
        else if (energy >= 20)
        {
            moveSpeed = 3f;
        }
        else if (energy >= 10)
        {
            moveSpeed = 2f;
        }
        else if (energy >= 0)
        {
            moveSpeed = 1f;
        }
        else
        {
            energy = 0;
            moveSpeed = 1f;
        }
    }

    public Vector2 CurrentLocation()
    {
        Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);
        return playerLocation;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetEnergy()
    {
        return energy;
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
        }
    }

    IEnumerator DrainEnergy()
    {
        while (true)
        {
            energy--;
            yield return new WaitForSeconds(energyDrainPeriod);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject projectiles = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation) as GameObject;
            projectiles.GetComponent<Rigidbody2D>().velocity = gunBarrel.up * -10f;
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    IEnumerator Invisability()
    {
        while (true)
        {
            gameObject.layer = 9;
            yield return new WaitForSeconds(invisabilityDurration);
            gameObject.layer = 7;
            StopCoroutine(Invisability());
        }
    }
}