using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        var deltax = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltay = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltax;
        var newYPos = transform.position.y + deltay;
        transform.position = new Vector2(newXPos, newYPos);
    }
}
