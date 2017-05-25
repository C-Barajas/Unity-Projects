/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    float bulletSpeed = 6f;
    int bulletDir;

    Vector2 moveUp;
    Vector2 moveRight;
    Vector2 moveDown;
    Vector2 moveLeft;

    Rigidbody2D rb;

    GameObject player;
    PlayerController playerCon;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        moveUp = new Vector2(0, bulletSpeed);
        moveRight = new Vector2(bulletSpeed, 0);
        moveDown = new Vector2(0, -bulletSpeed);
        moveLeft = new Vector2(-bulletSpeed, 0);
        bulletDir = playerCon.shootDir;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bulletDir == 1)
            rb.velocity = moveUp;
        else if (bulletDir == 2)
            rb.velocity = moveRight;
        else if (bulletDir == 3)
            rb.velocity = moveDown;
        else if (bulletDir == 4)
            rb.velocity = moveLeft;
	}

    void OnCollisionEnter2D()
    {
        Destroy(this.gameObject);
    }
}
