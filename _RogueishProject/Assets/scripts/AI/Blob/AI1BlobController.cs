/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AI1BlobController : MonoBehaviour {

    [Header("Stats")]
    int health;

    [Header("Movement")]
    float moveSpeed = 2f;
    int moveTick = 0;
    int direction;

    [Header("Alert")]
    bool mouseOver;

    [Header("Misc")]
    GameObject player;
    PlayerController playerCon;
    Rigidbody2D rb;
    GameObject level_controller;
    LevelController lc;
    GameObject statsTextObj;
    StatsText statsTextCon;
    CanvasController cc;
    Camera cam;

    // Use this for initialization
    void Start ()
    {
        health = 3;
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = player.GetComponent<PlayerController>();
        level_controller = GameObject.Find("level_controller");
        lc = level_controller.GetComponent<LevelController>();
        statsTextObj = GameObject.Find("Canvas");
        statsTextCon = statsTextObj.GetComponent<StatsText>();
        cc = statsTextObj.GetComponent<CanvasController>();
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.current;
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementController();
	}

    void movementController()
    {
        if (moveTick <= 0)
        {
            moveTick = Random.Range(10, 60);
            direction = Random.Range(1, 7);
        }
        else if (moveTick > 0)
        {
            moveTick--;

            //Up
            if (direction == 1)
            {
                rb.velocity = new Vector2(0, moveSpeed);
            }
            //Right
            else if (direction == 2)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
            }
            //Down
            else if (direction == 3)
            {
                rb.velocity = new Vector2(0, -moveSpeed);
            }
            //Left
            else if (direction == 4)
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
            }
            //Still
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "playerMelee")
        {
            takeDamage(playerCon.swordStat);
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        //Damage
        if (target.gameObject.tag == "playerRanged")
        {
            takeDamage(playerCon.bowStat);
        }
        else if (target.gameObject.tag == "playerMagic")
        {
            takeDamage(playerCon.magicStat);
        }

        //Walking into another blob
        else if (target.gameObject.tag == "enemyBlob")
        {
            moveTick = 0;
        }

        
    }

    void deathCheck()
    {
        if (health <= 0)
        {
            dropItems();
            playerCon.giveExperience(5);
            lc.enemiesLeft--;
            statsTextCon.updateEnemiesLeft();
            Destroy(this.gameObject);
        }
    }

    void takeDamage(int dmg)
    {
        health -= dmg;
        deathCheck();
    }

    void dropItems()
    {
        //50% chance to drop coin
        //can drop up to 3 coins
        for (int i = 0; i < 3; i++)
        {
            if (Random.Range(1, 3) == 2)
            {
                Instantiate(lc.coin, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
            }
        }
        //15% chance to drop smallMana
        if (Random.Range(1, 100) <= 15)
        {
            Instantiate(lc.smallHp, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //10% chance to drop smallHP
        if (Random.Range(1, 100) <= 10)
        {
            Instantiate(lc.smallMana, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% leatherBoots
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.leatherBoots, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% leatherLegs
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.leatherLegs, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% leatherBody
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.leatherBody, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% leatherHelmet
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.leatherHelmet, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% woodSword
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.woodSword, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% woodBow
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.woodBow, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% woodStaff
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.woodStaff, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }
        //5% woodShield
        if (Random.Range(1, 100) <= 5)
        {
            Instantiate(lc.woodShield, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        }

    }//end void DropItems

    void OnMouseOver()
    {
        mouseOver = true;
        cc.enemyDisplayController(true, "AI1", health, 3);
    }

    void OnMouseExit()
    {
        mouseOver = false;
        cc.enemyDisplayController(false, "", 0, 0);
    }
}
