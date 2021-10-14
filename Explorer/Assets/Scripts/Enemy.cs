using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float moveSpeed =10f;
    [SerializeField] float health = 3f;

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
    }

    private void Move()
   {
        var targetPosition = player.CurrentLocation();
        var movementThisFrame = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards
        (transform.position, targetPosition, movementThisFrame);
   }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy) {return; }
        else if (damageDealer) { HandleProjectileDamage(damageDealer); Debug.Log("hit"); }
        else { return; }
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
