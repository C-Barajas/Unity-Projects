/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

    // easy dropDown to edit from UnityEditor inspector window
    [Header("Input")]
    public KeyCode k_moveUp;
    public KeyCode k_moveRight;
    public KeyCode k_moveDown;
    public KeyCode k_moveLeft;
    public KeyCode k_sprint;
    public KeyCode k_hotbar1;
    public KeyCode k_hotbar2;
    public KeyCode k_hotbar3;
    public KeyCode k_hotbar4;
    public KeyCode k_attackUp;
    public KeyCode k_attackRight;
    public KeyCode k_attackDown;
    public KeyCode k_attackLeft;
    public KeyCode k_inventory;
    public KeyCode k_shop;
    public KeyCode k_hp;
    public KeyCode k_mana;

    [Header("Movement")]
    //public float playerBaseSpeed = 4f;
    public float playerSpeed = 4f;
    bool sprinting;
    public float playerStamina = 100f;
    public int shootDir;

    [Header("Stats")]
    public float playerMaxHealth = 100f;
    public float playerMaxMana = 100f;

    public int playerLevel = 1;
    public float playerExperience;

    public float playerHealth = 100f;
    public float playerMana = 100f;
    public int swordStat = 0;
    public int bowStat = 0;
    public int magicStat = 0;
    public int armorStat = 0;

    [Header("Combat")]
    public GameObject upTrigger;
    public GameObject rightTrigger;
    public GameObject downTrigger;
    public GameObject leftTrigger;

    public GameObject bullet;
    public GameObject magicShot;

    bool canMelee = true;
    bool canRanged = true;
    bool canMagic = true;

    [Header("Hotbar")]
    public int currentWeapon = 1;

    [Header("Inventory")]
    public string[] inventory;
    public int invSelected;
    public int coins = 0;
    public bool invOpen;
    public bool shopOpen;
    bool nearShop;

    [Header("Equipment")]
    public string equHelmet;
    public string equBody;
    public string equLegs;
    public string equBoots;
    public string equSword;
    public string equBow;
    public string equStaff;
    public string equShield;

    [Header("Misc")]
    GameObject level_controller;
    MazeGenerator mazeGen;
    LevelController levelCon;
    Rigidbody2D rb;
    public Animator playerAnimator;
    public GameObject canvas;
    public CanvasController cc;
    public StatsText statsTextCon;
    public string tempString;
    public HPBar hpBarCon;
    public ManaBar manaBarCon;

    [Header("Sound Effects")]
    public AudioClip swordAttack;
    public AudioClip damageTaken;
    public AudioClip coinUp;
    public AudioClip lvlUp;
    public AudioClip pickUp;
    public AudioClip healthUp;
    public AudioClip manaUp;
    public AudioClip exit;
    public AudioClip shopEnter;
    public AudioClip shopExit;
    public AudioClip hotBar;
    AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
        level_controller = GameObject.Find("level_controller");
        mazeGen = level_controller.GetComponent<MazeGenerator>();
        levelCon = level_controller.GetComponent<LevelController>();
        rb = GetComponent<Rigidbody2D>();
        inventory = new string[32];
        swordStat = 1;
        bowStat = 1;
        magicStat = 1;
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = "empty";
        }
        equHelmet = "empty";
        equBody = "empty";
        equLegs = "empty";
        equBoots = "empty";
        equSword = "empty";
        equBow = "empty";
        equStaff = "empty";
        equShield = "empty";
        statsTextCon.updateStats();
    }
	
	// Update is called once per frame
	void Update ()
    {
        attackController();
        potionController();
        inventoryHotbarController();
        movementController();
	}

    public void relocatePlayer()
    {
        transform.position = new Vector3(mazeGen.dungeonSize / 2, mazeGen.dungeonSize / 2, -2);
    }

    void potionController()
    {
        if (Input.GetKeyDown(k_hp) && inventory.Contains<string>("smallHp") && playerHealth < playerMaxHealth)
        {
            useHealthPotion();
        }
        else if (Input.GetKeyDown(k_mana) && inventory.Contains<string>("smallMana") && playerMana < playerMaxMana)
        {
            useManaPotion();
        }
    }

    void attackController()
    {

        if (currentWeapon == 1)
        {
            /*
            if (Input.GetKeyDown(k_attackUp))
            {
                takeDamage(6);
            }
            else if (Input.GetKeyDown(k_attackRight))
            {
                giveItem("smallHp");
                giveItem("smallMana");
            }
            else if (Input.GetKeyDown(k_attackDown))
            {
                giveExperience(15);
            }
            */
        }

        // sword attack
        if (currentWeapon == 2)
        {
            if (Input.GetKeyDown(k_attackUp) && canMelee)
            {
                playerAnimator.SetTrigger("meleeUp");
                StartCoroutine(meleeWaitTimer(0.6f));
                StartCoroutine(attackMeleeTrigger(0.5f, upTrigger));
                
            }
            else if (Input.GetKeyDown(k_attackRight) && canMelee)
            {
                playerAnimator.SetTrigger("meleeRight");
                StartCoroutine(meleeWaitTimer(0.6f));
                StartCoroutine(attackMeleeTrigger(0.5f, rightTrigger));
                
            }
            else if (Input.GetKeyDown(k_attackDown) && canMelee)
            {
                playerAnimator.SetTrigger("meleeDown");
                StartCoroutine(meleeWaitTimer(0.6f));
                StartCoroutine(attackMeleeTrigger(0.5f, downTrigger));
                
            }
            else if (Input.GetKeyDown(k_attackLeft) && canMelee)
            {
                playerAnimator.SetTrigger("meleeLeft");
                StartCoroutine(meleeWaitTimer(0.6f));
                StartCoroutine(attackMeleeTrigger(0.5f, leftTrigger));
                
            }
        }
        // bow
        else if (currentWeapon == 3)
        {
            if (Input.GetKeyDown(k_attackUp) && canRanged)
            {
                shootDir = 1;
                StartCoroutine(rangedWaitTimer(0.3f));
                Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(k_attackRight) && canRanged)
            {
                shootDir = 2;
                StartCoroutine(rangedWaitTimer(0.3f));
                Instantiate(bullet, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
            }
            else if (Input.GetKeyDown(k_attackDown) && canRanged)
            {
                shootDir = 3;
                StartCoroutine(rangedWaitTimer(0.3f));
                Instantiate(bullet, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(k_attackLeft) && canRanged)
            {
                shootDir = 4;
                StartCoroutine(rangedWaitTimer(0.3f));
                Instantiate(bullet, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
            }
        }
        // magic
        else if (currentWeapon == 4)
        {
            if (Input.GetKeyDown(k_attackUp) && canMagic && playerMana >= 15)
            {
                shootDir = 1;
                takeMana(15);
                StartCoroutine(magicWaitTimer(0.4f));
                Instantiate(magicShot, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(k_attackRight) && canMagic && playerMana >= 15)
            {
                shootDir = 2;
                takeMana(15);
                StartCoroutine(magicWaitTimer(0.4f));
                Instantiate(magicShot, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
            }
            else if (Input.GetKeyDown(k_attackDown) && canMagic && playerMana >= 15)
            {
                shootDir = 3;
                takeMana(15);
                StartCoroutine(magicWaitTimer(0.4f));
                Instantiate(magicShot, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
            }
            else if (Input.GetKeyDown(k_attackLeft) && canMagic && playerMana >= 15)
            {
                shootDir = 4;
                takeMana(15);
                StartCoroutine(magicWaitTimer(0.4f));
                Instantiate(magicShot, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
            }
        }
    }

    IEnumerator meleeWaitTimer(float time)
    {
        canMelee = false;
        yield return new WaitForSeconds(time);
        canMelee = true;
    }

    IEnumerator rangedWaitTimer(float time)
    {
        canRanged = false;
        yield return new WaitForSeconds(time);
        canRanged = true;
    }

    IEnumerator magicWaitTimer(float time)
    {
        canMagic = false;
        yield return new WaitForSeconds(time);
        canMagic = true;
    }

    IEnumerator attackMeleeTrigger(float time, GameObject trigger)
    {
        trigger.GetComponent<BoxCollider2D>().enabled = true;
        audio.PlayOneShot(swordAttack,2.0f);
        yield return new WaitForSeconds(time);
        trigger.GetComponent<BoxCollider2D>().enabled = false;
        
    }

    public void giveExperience(int exp)
    {
        playerExperience += exp;
        calculateLevel();
    }

    void calculateLevel()
    {
        int tempLevel = 0;

        if (playerExperience < 100)
        {
            playerLevel = 1;
        }
        else
            tempLevel = (int)(playerExperience / 100) + 1;

        /*
        oooh
        level = constant * sqrt(XP)
        or
        n * ln(x-1)
        I guess
        */

        //if level up
        if (tempLevel > playerLevel)
        {
            //set new level
            playerLevel = tempLevel;
            //calculate new max health and mana
            playerMaxHealth = 100 + playerLevel * 5;
            playerMaxMana = 100 + playerLevel * 10;
            //refill health and mana
            playerHealth = playerMaxHealth;
            playerMana = playerMaxMana;
            //update ui
            hpBarCon.updateHealth();
            manaBarCon.updateMana();
            statsTextCon.updateHealthMana();
            //Alert message
            StartCoroutine(cc.displayAlert(3, "Level up! Level: " + playerLevel));
            audio.PlayOneShot(lvlUp);
        }
        //update ui
        statsTextCon.updateLevelExperience(); 
    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
        hpBarCon.updateHealth();
        statsTextCon.updateHealthMana();
        
    }

    public void takeMana(int mana)
    {
        playerMana -= mana;
        manaBarCon.updateMana();
        statsTextCon.updateHealthMana();
    }

    public void giveHealth(int num)
    {
        if (playerHealth < playerMaxHealth - num)
        {
            playerHealth += num;
        }
        else
        {
            playerHealth = playerMaxHealth;
        }
        hpBarCon.updateHealth();
        audio.PlayOneShot(healthUp);
        statsTextCon.updateHealthMana();
        statsTextCon.updatePotions();
    }

    public void giveMana(int num)
    {
        if (playerMana < playerMaxMana - num)
        {
            playerMana += num;
        }
        else
        {
            playerMana = playerMaxMana;
        }
        manaBarCon.updateMana();
        audio.PlayOneShot(manaUp);
        statsTextCon.updateHealthMana();
        statsTextCon.updatePotions();
    }

    void inventoryHotbarController()
    {
        //hotbar
        if (Input.GetKeyDown(k_hotbar1))
        {
            currentWeapon = 1;
            cc.hotbarController();
            audio.PlayOneShot(hotBar);
        }

        else if (Input.GetKeyDown(k_hotbar2))
        {
            currentWeapon = 2;
            cc.hotbarController();
            audio.PlayOneShot(hotBar);
        }
        else if (Input.GetKeyDown(k_hotbar3))
        {
            currentWeapon = 3;
            cc.hotbarController();
            audio.PlayOneShot(hotBar);
        }
        else if (Input.GetKeyDown(k_hotbar4))
        {
            currentWeapon = 4;
            cc.hotbarController();
            audio.PlayOneShot(hotBar);
        }

        //inventory
        if (Input.GetKeyDown(k_inventory) && !shopOpen)
        {
            if (!invOpen)
            {
                invOpen = true;
                cc.inventoryController();
            }
            else if (invOpen)
            {
                invOpen = false;
                cc.inventoryController();
            }
        }

        //shop
        if (Input.GetKeyDown(k_shop) && !invOpen)
        {
            if (nearShop)
            {
                if (!shopOpen)
                {
                    shopOpen = true;
                    cc.shopController();
                    audio.PlayOneShot(shopEnter);
                }
                else if (shopOpen)
                {
                    shopOpen = false;
                    cc.shopController();
                    audio.PlayOneShot(shopExit);
                }
            }
            else if (!nearShop)
            {
                StartCoroutine(cc.displayAlert(3, "You must be near the Chest to shop"));
            }
            
        }
    }

    void movementController()
    {

        if (currentWeapon == 1)
            playerSpeed = 4f;
        else
            playerSpeed = 2.5f;

        //up-Left
        if (Input.GetKey(k_moveLeft) && Input.GetKey(k_moveUp))
        {
            rb.velocity = new Vector2(-playerSpeed, playerSpeed); // * Time.deltaTime;
        }
        //up
        else if (Input.GetKey(k_moveUp) && !Input.GetKey(k_moveRight) && !Input.GetKey(k_moveLeft)) //if up and not right or left
        {
            rb.velocity = new Vector2(0, playerSpeed);
        }
        //up-Right
        else if (Input.GetKey(k_moveUp) && Input.GetKey(k_moveRight))
        {
            rb.velocity = new Vector2(playerSpeed, playerSpeed);
        }
        //right
        else if (Input.GetKey(k_moveRight) && !Input.GetKey(k_moveUp) && !Input.GetKey(k_moveDown)) //if right and not up or down
        {
            rb.velocity = new Vector2(playerSpeed, 0);
        }
        //down-Right
        else if (Input.GetKey(k_moveDown) && Input.GetKey(k_moveRight))
        {
            rb.velocity = new Vector2(playerSpeed, -playerSpeed);
        }
        //down
        else if (Input.GetKey(k_moveDown) && !Input.GetKey(k_moveRight) && !Input.GetKey(k_moveLeft)) //if down and not right or left
        {
            rb.velocity = new Vector2(0, -playerSpeed);
        }
        //down-Left
        else if (Input.GetKey(k_moveDown) && Input.GetKey(k_moveLeft))
        {
            rb.velocity = new Vector2(-playerSpeed, -playerSpeed);
        }
        //left
        else if (Input.GetKey(k_moveLeft) && !Input.GetKey(k_moveUp) && !Input.GetKey(k_moveDown)) //if left and not up or down
        {
            rb.velocity = new Vector2(-playerSpeed, 0);
        }
        else if (!Input.GetKey(k_moveUp) && !Input.GetKey(k_moveRight) && !Input.GetKey(k_moveDown) && !Input.GetKey(k_moveLeft)) 
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        //Shop
        // made shop a trigger to avoid it blocking a path
        if (target.gameObject.tag == "chest")
        {
            nearShop = true;
            
        }
        //Exit
        if (target.gameObject.name == "_exit(Clone)")
        {
            if (levelCon.enemiesLeft < 1)
            {
                mazeGen.destroyDungeon();
                audio.PlayOneShot(exit);
                mazeGen.generateDungeon();
            }
            else
            {
                StartCoroutine(cc.displayAlert(3, "Kill all enemies to continue."));
                Debug.Log("Kill all enemies to continue");
            }
        }
        //Spiked floor
        else if (target.gameObject.name == "spike1(Clone)" || target.gameObject.name == "spike2(Clone)")
        {
            takeDamage(5);
            audio.PlayOneShot(damageTaken);
        }
        //     //
        //DROPS//
        //     //
        //Coin
        else if (target.gameObject.name == "_coin(Clone)")
        {
            coins += 1;
            statsTextCon.updateCoins();
            Destroy(target.gameObject);
            audio.PlayOneShot(coinUp);
        }
        //slime
        else if (target.gameObject.name == "_slime(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("slime");
                Destroy(target.gameObject);
            }
        }
        //smallHp
        else if (target.gameObject.name == "_smallHp(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("smallHp");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //smallMana
        else if (target.gameObject.name == "_smallMana(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("smallMana");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //leatherBoots
        else if (target.gameObject.name == "_leatherBoots(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("leatherBoots");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //leatherLegs
        else if (target.gameObject.name == "_leatherLegs(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("leatherLegs");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //leatherBody
        else if (target.gameObject.name == "_leatherBody(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("leatherBody");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //leatherHelmet
        else if (target.gameObject.name == "_leatherHelmet(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("leatherHelmet");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //woodSword
        else if (target.gameObject.name == "_woodSword(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("woodSword");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //woodStaff
        else if (target.gameObject.name == "_woodStaff(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("woodStaff");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //woodBow
        else if (target.gameObject.name == "_woodBow(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("woodBow");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }

        }
        //woodShield
        else if (target.gameObject.name == "_woodShield(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("woodShield");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelBoots
        else if (target.gameObject.name == "_steelBoots(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelBoots");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelLegs
        else if (target.gameObject.name == "_steelLegs(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelLegs");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelBody
        else if (target.gameObject.name == "_steelBody(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelBody");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelHelmet
        else if (target.gameObject.name == "_steelHelmet(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelHelmet");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelSword
        else if (target.gameObject.name == "_steelSword(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelSword");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelBow
        else if (target.gameObject.name == "_steelBow(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelBow");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelStaff
        else if (target.gameObject.name == "_steelStaff(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelStaff");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //steelShield
        else if (target.gameObject.name == "_steelShield(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("steelShield");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //mystic
        else if (target.gameObject.name == "_mysticBoots(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("mysticBoots");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_mysticLegs(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("mysticLegs");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_mysticBody(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("mysticBody");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_mysticHelmet(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("mysticHelmet");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_mysticStaff(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("mysticStaff");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_mysticBook(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("mysticBook");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //warrior
        else if (target.gameObject.name == "_warriorBoots(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("warriorBoots");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_warriorLegs(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("warriorLegs");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_warriorBody(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("warriorBody");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_warriorHelmet(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("warriorHelmet");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_warriorSword(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("warriorSword");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_warriorShield(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("warriorShield");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        //ranged
        else if (target.gameObject.name == "_rangedBoots(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("rangedBoots");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_rangedLegs(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("rangedLegs");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_rangedBody(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("rangedBody");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_rangedHelmet(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("rangedHelmet");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }
        else if (target.gameObject.name == "_rangedBow(Clone)")
        {
            if (inventory.Contains<string>("empty"))
            {
                giveItem("rangedBow");
                Destroy(target.gameObject);
                audio.PlayOneShot(pickUp);
            }
        }

    }//end onTriggerEnter2D

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "chest")
        {
            nearShop = false;

        }
    }

    void giveItem(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "empty")
            {
                inventory[i] = item;
                cc.updateInv(1);
                statsTextCon.updatePotions();
                break;
            }
        }
    }

    public void setInvSelected(int number)
    {
        invSelected = number - 1;
        Debug.Log("invSelected: " + invSelected);
    }

    //this is called by the button and then calls dropItem with invSelected
    public void callDropItem()
    {
        dropItem(invSelected);
    }

    void dropItem(int item)
    {
        switch (inventory[item])
        {
            case "slime":
                Instantiate(levelCon.slime, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "smallHp":
                Instantiate(levelCon.smallHp, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "smallMana":
                Instantiate(levelCon.smallMana, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "leatherBoots":
                Instantiate(levelCon.leatherBoots, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "leatherLegs":
                Instantiate(levelCon.leatherLegs, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "leatherBody":
                Instantiate(levelCon.leatherBody, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "leatherHelmet":
                Instantiate(levelCon.leatherHelmet, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "woodSword":
                Instantiate(levelCon.woodSword, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "woodStaff":
                Instantiate(levelCon.woodStaff, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "woodBow":
                Instantiate(levelCon.woodBow, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelBoots:":
                Instantiate(levelCon.steelBoots, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelLegs":
                Instantiate(levelCon.steelLegs, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelBody":
                Instantiate(levelCon.steelBody, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelHelmet":
                Instantiate(levelCon.steelHelmet, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelSword":
                Instantiate(levelCon.steelSword, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelBow":
                Instantiate(levelCon.steelBow, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelStaff":
                Instantiate(levelCon.steelStaff, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            case "steelShield":
                Instantiate(levelCon.steelShield, new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f, -2), Quaternion.identity);
                break;
            default:
                break;
        }
        //update inventory
        inventory[item] = "empty";
        //update canvas
        cc.updateInv(1);
    }

    public void callEquipItem()
    {
        equipItem(invSelected);
    }

    void equipItem(int item)
    {

        Debug.Log("equipItem called, inv number: " + invSelected + " // Item: " + inventory[invSelected]);

        //equHelmet
        if (inventory[item] == "leatherHelmet" || inventory[item] == "steelHelmet" || inventory[item] == "mysticHelmet" || inventory[item] == "warriorHelmet" || inventory[item] == "rangedHelmet")
        {
            tempString = equHelmet;
            equHelmet = inventory[item];
            inventory[item] = tempString;
        }
        //equBody
        else if (inventory[item] == "leatherBody" || inventory[item] == "steelBody" || inventory[item] == "mysticBody" || inventory[item] == "warriorBody" || inventory[item] == "rangedBody")
        {
            tempString = equBody;
            equBody = inventory[item];
            inventory[item] = tempString;
        }
        //equLegs
        else if (inventory[item] == "leatherLegs" || inventory[item] == "steelLegs" || inventory[item] == "mysticLegs" || inventory[item] == "warriorLegs" || inventory[item] == "rangedLegs")
        {
            tempString = equLegs;
            equLegs = inventory[item];
            inventory[item] = tempString;
        }
        //equBoots
        else if (inventory[item] == "leatherBoots" || inventory[item] == "steelBoots" || inventory[item] == "mysticBoots" || inventory[item] == "warriorBoots" || inventory[item] == "rangedBoots")
        {
            tempString = equBoots;
            equBoots = inventory[item];
            inventory[item] = tempString;
        }
        //equSword
        else if (inventory[item] == "woodSword" || inventory[item] == "steelSword" || inventory[item] == "warriorSword")
        {
            tempString = equSword;
            equSword = inventory[item];
            inventory[item] = tempString;
        }
        //equStaff
        else if (inventory[item] == "woodStaff" || inventory[item] == "steelStaff" || inventory[item] == "mysticStaff")
        {
            tempString = equStaff;
            equStaff = inventory[item];
            inventory[item] = tempString;
        }
        //equBow
        else if (inventory[item] == "woodBow" || inventory[item] == "steelBow" || inventory[item] == "rangedBow")
        {
            tempString = equBow;
            equBow = inventory[item];
            inventory[item] = tempString;
        }
        //equShield
        else if (inventory[item] == "woodShield" || inventory[item] == "steelShield" || inventory[item] == "mysticBook" || inventory[item] == "warriorShield")
        {
            tempString = equShield;
            equShield = inventory[item];
            inventory[item] = tempString;
        }

        cc.updateInv(1);
        updateStats();
    }

    public void callUseItem()
    {
        useItem(invSelected);
    }

    void useItem(int invNum)
    {
        //smallHp
        if (inventory[invNum] == "smallHp" && playerHealth < playerMaxHealth)
        {
            inventory[invNum] = "empty";
            cc.updateInv(1);
            giveHealth(20);
            audio.PlayOneShot(healthUp);
        }
        //smallMana
        if (inventory[invNum] == "smallMana" && playerMana < playerMaxMana)
        {
            inventory[invNum] = "empty";
            cc.updateInv(1);
            giveMana(20);
            audio.PlayOneShot(manaUp);
        }
    }

    void useHealthPotion()
    {
        giveHealth(20);
        audio.PlayOneShot(healthUp);
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "smallHp")
            {
                inventory[i] = "empty";
                cc.updateInv(1);
                statsTextCon.updatePotions();
                break;
            }
        }
    }

    void useManaPotion()
    {
        giveMana(20);
        audio.PlayOneShot(manaUp);
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "smallMana")
            {
                inventory[i] = "empty";
                cc.updateInv(1);
                statsTextCon.updatePotions();
                break;
            }
        }
    }

    void updateStats()
    {
        //Set stats to 0 before calculating them
        swordStat = 1;
        bowStat = 1;
        magicStat = 1;
        armorStat = 0;

        //Helmet
        switch (equHelmet)
        {
            case "leatherHelmet":
                armorStat += 1;
                break;
            case "steelHelmet":
                armorStat += 2;
                break;
            case "mysticHelmet":
                armorStat += 1;
                magicStat += 1;
                break;
            case "warriorHelmet":
                swordStat += 1;
                armorStat += 1;
                break;
            case "rangedHelmet":
                bowStat += 1;
                armorStat += 1;
                break;
            default:
                break;
        }

        //Body
        switch (equBody)
        {
            case "leatherBody":
                armorStat += 1;
                break;
            case "steelBody":
                armorStat += 2;
                break;
            case "mysticBody":
                armorStat += 1;
                magicStat += 1;
                break;
            case "warriorBody":
                swordStat += 1;
                armorStat += 1;
                break;
            case "rangedBody":
                bowStat += 1;
                armorStat += 1;
                break;
            default:
                break;
        }

        //Legs
        switch (equLegs)
        {
            case "leatherLegs":
                armorStat += 1;
                break;
            case "steelLegs":
                armorStat += 2;
                break;
            case "mysticLegs":
                armorStat += 1;
                magicStat += 1;
                break;
            case "warriorLegs":
                swordStat += 1;
                armorStat += 1;
                break;
            case "rangedLegs":
                bowStat += 1;
                armorStat += 1;
                break;
            default:
                break;
        }

        //Boots
        switch (equBoots)
        {
            case "leatherBoots":
                armorStat += 1;
                break;
            case "steelBoots":
                armorStat += 2;
                break;
            case "mysticBoots":
                armorStat += 1;
                magicStat += 1;
                break;
            case "warriorBoots":
                swordStat += 1;
                armorStat += 1;
                break;
            case "rangedBoots":
                bowStat += 1;
                armorStat += 1;
                break;
            default:
                break;
        }

        //Shield
        switch (equShield)
        {
            case "woodShield":
                armorStat += 1;
                break;
            case "steelShield":
                armorStat += 2;
                break;
            case "mysticBook":
                magicStat += 1;
                armorStat += 1;
                break;
            case "warriorShield":
                armorStat += 1;
                magicStat -= 1;
                bowStat -= 1;
                break;
            default:
                break;
        }

        //Sword
        switch (equSword)
        {
            case "woodSword":
                swordStat += 1;
                break;
            case "steelSword":
                swordStat += 2;
                break;
            case "warriorSword":
                swordStat += 3;
                break;
            default:
                break;
        }

        //Staff
        switch (equStaff)
        {
            case "woodStaff":
                magicStat += 1;
                break;
            case "steelStaff":
                magicStat += 2;
                break;
            case "mysticStaff":
                magicStat += 3;
                break;
            default:
                break;
        }

        //Bow
        switch (equBow)
        {
            case "woodBow":
                bowStat += 1;
                break;
            case "steelBow":
                bowStat += 2;
                break;
            case "rangedBow":
                bowStat += 3;
                break;
            default:
                break;
        }

        statsTextCon.updateStats();

    }//end updateStats

    public void sellItem()
    {
        string p = inventory[invSelected];

        if (p == "slime")
        {
            coins += 2;
        }
        else if (p == "smallHp" || p == "smallMana")
        {
            coins += 3;
        }
        else if (p == "leatherBoots" || p == "leatherLegs" || p == "leatherBody" || p == "leatherHelmet" || p == "woodSword" || p == "woodBow" || p == "woodStaff" || p == "woodShield")
        {
            coins += 5;
        }
        else if (p == "steelBoots" || p == "steelLegs" || p == "steelBody" || p == "steelHelmet" || p == "steelSword" || p == "steelBow" || p == "steelStaff" || p == "steelShield")
        {
            coins += 10;
        }
        else if (p == "mysticBoots" || p == "mysticLegs" || p == "mysticBody" || p == "mysticHelmet" || p == "mysticStaff" || p == "mysticBook" || p == "warriorBoots" || p == "warriorLegs" || p == "warriorBody" || p == "warriorHelmet" || p == "warriorSword" || p == "warriorShield" || p == "rangedBoots" || p == "rangedLegs" || p == "rangedBody" || p == "rangedHelmet" || p == "rangedBow")
        {
            coins += 15;
        }
       
        //Make position empty
        inventory[invSelected] = "empty";
        //Update inv sprites
        cc.updateInv(2);
        //Update coins display
        statsTextCon.updateCoins(); 
    }

    public void buyItem()
    {
        if (!inventory.Contains<string>("empty"))
            return;

        if (coins <= 0)
            //display not enough coins
            return;

        string p = cc.shopSelected;

        if (p == "smallHp" || p == "smallMana")
        {
            if (coins >= 10)
            {
                coins -= 10;
                statsTextCon.updatePotions();
            }
            else
                return;
        }
        else if (p == "leatherBoots" || p == "leatherLegs" || p == "leatherBody" || p == "leatherHelmet" || p == "woodSword" || p == "woodBow" || p == "woodStaff" || p == "woodShield")
        {
            if (coins >= 10)
                coins -= 10;
            else
                return;
        }
        else if (p == "steelBoots" || p == "steelLegs" || p == "steelBody" || p == "steelHelmet" || p == "steelSword" || p == "steelBow" || p == "steelStaff" || p == "steelShield")
        {
            if (coins >= 25)
                coins -= 25;
            else
                return;
        }
        else if (p == "mysticBoots" || p == "mysticLegs" || p == "mysticBody" || p == "mysticHelmet" || p == "mysticStaff" || p == "mysticBook" || p == "warriorBoots" || p == "warriorLegs" || p == "warriorBody" || p == "warriorHelmet" || p == "warriorSword" || p == "warriorShield" || p == "rangedBoots" || p == "rangedLegs" || p == "rangedBody" || p == "rangedHelmet" || p == "rangedBow")
        {
            if (coins >= 60)
                coins -= 60;
            else
                return;
        }

        //Give item
        giveItem(cc.shopSelected);
        //Update inventory
        cc.updateInv(2);
        //Update coins display
        statsTextCon.updateCoins();
    }

    public void buyItem(string item)
    {

    }


}//end class