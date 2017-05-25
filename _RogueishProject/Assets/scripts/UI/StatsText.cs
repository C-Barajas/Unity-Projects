/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsText : MonoBehaviour {

    // easy dropDown for editing in inspector
    [Header("Text GameObjects")]
    public GameObject swordTextObj;
    public GameObject bowTextObj;
    public GameObject staffTextObj;
    public GameObject armorTextObj;

    public GameObject coinsTextObj;

    public GameObject hpTextObj;
    public GameObject manaTextObj;
    public GameObject levelTextObj;
    public GameObject experienceTextObj;

    public GameObject enemiesLeftTextObj;
    public GameObject dungeonLevelTextObj;

    public GameObject healthPotionTextObj;
    public GameObject manaPotionTextObj;

    Text swordText;
    Text bowText;
    Text staffText;
    Text armorText;

    Text coinsText;

    Text hpText;
    Text manaText;
    Text levelText;
    Text experienceText;

    Text enemiesLeftText;
    Text dungeonLevelText;

    Text healthPotionText;
    Text manaPotionText;

    [Header("Script Ref")]
    public GameObject player;
    public PlayerController pc;
    public GameObject levelController;
    public LevelController lc;

    // Use this for initialization
    void Start ()
    {
        swordText = swordTextObj.GetComponent<Text>();
        bowText = bowTextObj.GetComponent<Text>();
        staffText = staffTextObj.GetComponent<Text>();
        armorText = armorTextObj.GetComponent<Text>();
        coinsText = coinsTextObj.GetComponent<Text>();
        hpText = hpTextObj.GetComponent<Text>();
        manaText = manaTextObj.GetComponent<Text>();
        enemiesLeftText = enemiesLeftTextObj.GetComponent<Text>();
        dungeonLevelText = dungeonLevelTextObj.GetComponent<Text>();
        healthPotionText = healthPotionTextObj.GetComponent<Text>();
        manaPotionText = manaPotionTextObj.GetComponent<Text>();
        levelText = levelTextObj.GetComponent<Text>();
        experienceText = experienceTextObj.GetComponent<Text>();

        updatePotions();
	}

    void Update()
    {

    }

    public void updateStats()
    {
        swordText.text = "Sword: " + pc.swordStat;
        bowText.text = "Ranged: " + pc.bowStat;
        staffText.text = "Magic: " + pc.magicStat;
        armorText.text = "Armor: " + pc.armorStat;
    }

    public void updateHealthMana()
    {
        hpText.text = pc.playerHealth + "/" + pc.playerMaxHealth;
        manaText.text = pc.playerMana + "/" + pc.playerMaxMana;
    }

    public void updateEnemiesLeft()
    {
        enemiesLeftText.text = "Enemies Left: " + lc.enemiesLeft;
    }

    public void updateCoins()
    {
        coinsText.text = "Coins: " + pc.coins;
    }

    public void updateDungeonLevel()
    {
        dungeonLevelText.text = "Floor: " + lc.dungeonLevel;
    }

    public void updatePotions()
    {
        int hpAmount = 0;
        int manaAmount = 0;
        for (int i = 0; i < pc.inventory.Length; i++)
        {
            if (pc.inventory[i] == "smallHp")
                hpAmount += 1;
            else if (pc.inventory[i] == "smallMana")
                manaAmount += 1;
        }

        healthPotionText.text = "x" + hpAmount;
        manaPotionText.text = "x" + manaAmount;

    }

    public void updateLevelExperience()
    {
        levelText.text = "" + pc.playerLevel;
        experienceText.text = "" + pc.playerExperience;
    }

}
