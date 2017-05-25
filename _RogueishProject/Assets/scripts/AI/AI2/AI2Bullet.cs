/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */



using UnityEngine;
using System.Collections;

public class AI2Bullet : MonoBehaviour {

    int speed = 2;
    Vector2 targetPos;
    Rigidbody2D rb;
    public GameObject player;
    PlayerController pc;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();   

        targetPos = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
        Debug.Log("targetPos: " + targetPos);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = targetPos.normalized * speed;
	}

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.name == "_player")
        {
            pc.takeDamage(5);
            Debug.Log("hit player");
        }

        Destroy(this.gameObject);
    }
}