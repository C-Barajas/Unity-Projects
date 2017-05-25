/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;

public class PlayerStrongMagic : MonoBehaviour {

    float magicSpeed = 8f;
    int magicDir;

    Vector2 moveUp;
    Vector2 moveRight;
    Vector2 moveDown;
    Vector2 moveLeft;

    Rigidbody2D rb;

    GameObject player;
    PlayerController pc;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        moveUp = new Vector2(0, magicSpeed);
        moveRight = new Vector2(magicSpeed, 0);
        moveDown = new Vector2(0, -magicSpeed);
        moveLeft = new Vector2(-magicSpeed, 0);
        magicDir = pc.shootDir;
    }

    // Update is called once per frame
    void Update()
    {
        if (magicDir == 1)
        {
            rb.velocity = moveUp;
        }

        else if (magicDir == 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            rb.velocity = moveRight;
        }
        else if (magicDir == 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            rb.velocity = moveDown;
        }
        else if (magicDir == 4)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            rb.velocity = moveLeft;
        }
    }

    void OnCollisionEnter2D()
    {
        spawnSmallShots();
        Destroy(this.gameObject);
    }

    void spawnSmallShots()
    {

    }
}
