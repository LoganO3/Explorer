using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed =2f;
    [SerializeField] float health = 3f;

    bool hasCollided = false;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        hasCollided = false;
    }

    private void Move()
   {
        if (!player) { return; }
        else
        {
            var targetPosition = player.CurrentLocation();
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards
            (transform.position, targetPosition, movementThisFrame);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasCollided == false)
        {
            hasCollided = true;
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy) { return; }
                else if (projectile)
                {
                 HandleProjectileDamage(damageDealer);
                }
                else if (damageDealer)
                {
                HandleDamage(damageDealer);
                }
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
}
