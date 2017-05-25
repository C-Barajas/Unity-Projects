/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    // easy dropDown for editing in inspector
    [Header("Game Variables")]
    public int enemiesLeft = 0;
    public int dungeonLevel = 0;

    [Header("Drops")]
    public GameObject coin;
    public GameObject slime;

    [Header("Potions")]
    public GameObject smallHp;
    public GameObject smallMana;

    [Header("Enemy bullets")]
    public GameObject ai2Bullet;

    [Header("Weapons/Armor")]
    //leather
    public GameObject leatherBoots;
    public GameObject leatherLegs;
    public GameObject leatherBody;
    public GameObject leatherHelmet;
    public GameObject woodSword;
    public GameObject woodBow;
    public GameObject woodStaff;
    public GameObject woodShield;
    //steel
    public GameObject steelBoots;
    public GameObject steelLegs;
    public GameObject steelBody;
    public GameObject steelHelmet;
    public GameObject steelSword;
    public GameObject steelBow;
    public GameObject steelStaff;
    public GameObject steelShield;
    //mystic
    public GameObject mysticBoots;
    public GameObject mysticLegs;
    public GameObject mysticBody;
    public GameObject mysticHelmet;
    public GameObject mysticStaff;
    public GameObject mysticBook;
    //warrior
    public GameObject warriorBoots;
    public GameObject warriorLegs;
    public GameObject warriorBody;
    public GameObject warriorHelmet;
    public GameObject warriorSword;
    public GameObject warriorShield;
    //ranged
    public GameObject rangedBoots;
    public GameObject rangedLegs;
    public GameObject rangedBody;
    public GameObject rangedHelmet;
    public GameObject rangedBow;

    [Header("Instantiate Text")]
    public Text healthText;
    public Text manaText;
    public Text lootText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
