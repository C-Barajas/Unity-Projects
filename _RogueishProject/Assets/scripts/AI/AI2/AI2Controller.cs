/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */


using UnityEngine;
using System.Collections;

public class AI2Controller : MonoBehaviour {

    [Header("Stats")]
    int health;

    [Header("Movement")]
    float moveSpeed = 0.5f;
    int moveTick = 0;
    int direction;

    [Header("Alert")]
    bool mouseOver;

    [Header("Combat")]
    bool playerInAgro;
    Vector2 playerPosition;
    bool canAttack = true;

    [Header("Misc")]
    public GameObject player;
    PlayerController playerCon;
    Rigidbody2D rb;
    GameObject level_controller;
    LevelController lc;
    GameObject statsTextObj;
    StatsText statsTextCon;
    CanvasController cc;

    // Use this for initialization
    void Start()
    {
        health = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = player.GetComponent<PlayerController>();
        level_controller = GameObject.Find("level_controller");
        lc = level_controller.GetComponent<LevelController>();
        statsTextObj = GameObject.Find("Canvas");
        statsTextCon = statsTextObj.GetComponent<StatsText>();
        cc = statsTextObj.GetComponent<CanvasController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        playerAgroCheck();
        movementController();

    }

    void movementController()
    {
        if (playerInAgro)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) > 1)
            {
                
                rb.velocity = new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y).normalized * moveSpeed;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                if (canAttack)
                    attackController();
            }

            if (canAttack)
                attackController();
        }
        else if (!playerInAgro)
        {
            if (moveTick <= 0)
            {
                moveTick = Random.Range(10, 30);
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
    }

    void attackController()
    {
        StartCoroutine(attackWait());
        //top right
        if (player.transform.position.x >= transform.position.x && player.transform.position.y >= transform.position.y)
            Instantiate(lc.ai2Bullet, new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), Quaternion.identity);
        //bottom right
        else if (player.transform.position.x >= transform.position.x && player.transform.position.y <= transform.position.y)
            Instantiate(lc.ai2Bullet, new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), Quaternion.identity);
        //bottom left
        else if (player.transform.position.x <= transform.position.x && player.transform.position.y <= transform.position.y)
            Instantiate(lc.ai2Bullet, new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), Quaternion.identity);
        //top left
        else if (player.transform.position.x <= transform.position.x && player.transform.position.y >= transform.position.y)
            Instantiate(lc.ai2Bullet, new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f), Quaternion.identity);
    }

    IEnumerator attackWait()
    {
        canAttack = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }

    void playerAgroCheck()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) <= 4)
            playerInAgro = true;
        else
            playerInAgro = false;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "playerMelee")
        {
            health -= playerCon.swordStat;
            deathCheck();
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        //damage
        if (target.gameObject.tag == "playerRanged")
        {
            health -= playerCon.bowStat;
            deathCheck();
        }
        else if (target.gameObject.tag == "playerMagic")
        {
            health -= playerCon.magicStat;
            deathCheck();
        }
    }

    void deathCheck()
    {
        if (health <= 0)
        {
            dropItems();
            playerCon.giveExperience(15);
            lc.enemiesLeft--;
            statsTextCon.updateEnemiesLeft();
            Destroy(gameObject);
        }
    }

    void dropItems()
    {
        //Remove these later
        //Steel objects
        //Just for testing
        //steel
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelBoots, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelLegs, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelBody, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelHelmet, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelSword, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelBow, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelStaff, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.steelShield, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        //mystic
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.mysticBoots, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.mysticLegs, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.mysticBody, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.mysticHelmet, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.mysticStaff, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.mysticBook, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        //warrior
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.warriorBoots, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.warriorLegs, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.warriorBody, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.warriorHelmet, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.warriorSword, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.warriorShield, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        //ranged
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.rangedBoots, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.rangedLegs, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.rangedBody, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.rangedHelmet, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
        if (Random.Range(1, 100) <= 5)
            Instantiate(lc.rangedBow, new Vector3(transform.position.x + Random.Range(-0.2f, 0.2f), transform.position.y + Random.Range(-0.2f, 0.2f), -2), Quaternion.identity);
    }

    void OnMouseOver()
    {
        mouseOver = true;
        cc.enemyDisplayController(true, "AI2", health, 5);
    }

    void OnMouseExit()
    {
        mouseOver = false;
        cc.enemyDisplayController(false, "", 0, 0);
    }
}
