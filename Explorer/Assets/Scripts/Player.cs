using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float health = 100f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 1f;
    [SerializeField] GameObject projectile;

    Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy) { HandleDamage(damageDealer); }
        else if (damageDealer) { HandleProjectileDamage(damageDealer); }
        else { return; }
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

    public Vector2 CurrentLocation()
    {
      Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);
        return playerLocation;
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

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
