/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    // easy dropDown to edit in UnityEditor inspector window
    [Header("Hotbar GameOjects")]
    public GameObject inner1;
    public GameObject inner2;
    public GameObject inner3;
    public GameObject inner4;

    [Header("Hotbar Sprites")]
    public Sprite inner1Unequipt;
    public Sprite inner1Equipt;
    public Sprite inner2Unequipt;
    public Sprite inner2Equipt;
    public Sprite inner3Unequipt;
    public Sprite inner3Equipt;
    public Sprite inner4Unequipt;
    public Sprite inner4Equipt;

    [Header("Inventory GameObjects")]
    public GameObject inventoryBack;
    public GameObject inv1;
    public GameObject inv2;
    public GameObject inv3;
    public GameObject inv4;
    public GameObject inv5;
    public GameObject inv6;
    public GameObject inv7;
    public GameObject inv8;
    public GameObject inv9;
    public GameObject inv10;
    public GameObject inv11;
    public GameObject inv12;
    public GameObject inv13;
    public GameObject inv14;
    public GameObject inv15;
    public GameObject inv16;
    public GameObject inv17;
    public GameObject inv18;
    public GameObject inv19;
    public GameObject inv20;
    public GameObject inv21;
    public GameObject inv22;
    public GameObject inv23;
    public GameObject inv24;
    public GameObject inv25;
    public GameObject inv26;
    public GameObject inv27;
    public GameObject inv28;
    public GameObject inv29;
    public GameObject inv30;
    public GameObject inv31;
    public GameObject inv32;
    public GameObject[] invGameObjectArray;

    [Header("InventoryButtons")]
    public GameObject invButton1;
    public GameObject invButton2;
    public GameObject invButton3;
    public GameObject invButton4;
    public GameObject invButton5;
    public GameObject invButton6;
    public GameObject invButton7;
    public GameObject invButton8;
    public GameObject invButton9;
    public GameObject invButton10;
    public GameObject invButton11;
    public GameObject invButton12;
    public GameObject invButton13;
    public GameObject invButton14;
    public GameObject invButton15;
    public GameObject invButton16;
    public GameObject invButton17;
    public GameObject invButton18;
    public GameObject invButton19;
    public GameObject invButton20;
    public GameObject invButton21;
    public GameObject invButton22;
    public GameObject invButton23;
    public GameObject invButton24;
    public GameObject invButton25;
    public GameObject invButton26;
    public GameObject invButton27;
    public GameObject invButton28;
    public GameObject invButton29;
    public GameObject invButton30;
    public GameObject invButton31;
    public GameObject invButton32;
    public GameObject[] invButtonsArray;
    public GameObject equButton1;
    public GameObject equButton2;
    public GameObject equButton3;
    public GameObject equButton4;
    public GameObject equButton5;
    public GameObject equButton6;
    public GameObject equButton7;
    public GameObject equButton8;
    public GameObject[] equButtonsArray;

    [Header("Equipment GameObjects")]
    public GameObject equipHelmet;
    public GameObject equipBody;
    public GameObject equipLegs;
    public GameObject equipBoots;
    public GameObject equipSword;
    public GameObject equipBow;
    public GameObject equipStaff;
    public GameObject equipShield;
    public GameObject[] equipArray;

    [Header("Inventory text")]
    public GameObject inventoryTextBack;
    public GameObject inventoryTitleTextObj;
    public GameObject inventoryDescTextObj;

    public Text inventoryTitleText;
    public Text inventoryDescText;

    [Header("Alert message")]
    public GameObject alertTextBack;
    public GameObject alertTextObj;

    public Text alertText;

    [Header("Inventory Action Buttons")]
    public GameObject invUse;
    public GameObject invEquip;
    public GameObject invDrop;
    public GameObject invCancel;

    [Header("Shop GameObjects")]
    //bg
    public GameObject shopBack;
    //inv
    public GameObject shopInv1;
    public GameObject shopInv2;
    public GameObject shopInv3;
    public GameObject shopInv4;
    public GameObject shopInv5;
    public GameObject shopInv6;
    public GameObject shopInv7;
    public GameObject shopInv8;
    public GameObject shopInv9;
    public GameObject shopInv10;
    public GameObject shopInv11;
    public GameObject shopInv12;
    public GameObject shopInv13;
    public GameObject shopInv14;
    public GameObject shopInv15;
    public GameObject shopInv16;
    public GameObject shopInv17;
    public GameObject shopInv18;
    public GameObject shopInv19;
    public GameObject shopInv20;
    public GameObject shopInv21;
    public GameObject shopInv22;
    public GameObject shopInv23;
    public GameObject shopInv24;
    public GameObject shopInv25;
    public GameObject shopInv26;
    public GameObject shopInv27;
    public GameObject shopInv28;
    public GameObject shopInv29;
    public GameObject shopInv30;
    public GameObject shopInv31;
    public GameObject shopInv32;
    GameObject[] shopInvArray;
    //shop
    public GameObject shop1;
    public GameObject shop2;
    public GameObject shop3;
    public GameObject shop4;
    public GameObject shop5;
    public GameObject shop6;
    public GameObject shop7;
    public GameObject shop8;
    public GameObject shop9;
    public GameObject shop10;
    public GameObject shop11;
    public GameObject shop12;
    public GameObject shop13;
    public GameObject shop14;
    public GameObject shop15;
    GameObject[] shopArray;

    [Header("Shop Select buttons")]
    public GameObject shopSelect1;
    public GameObject shopSelect2;
    public GameObject shopSelect3;
    public GameObject shopSelect4;

    [Header("Shop Action Buttons")]
    public GameObject invShopSell;
    public GameObject invShopBuy;
    public GameObject invShopCancel;

    [Header("Shop Inv/Shop Buttons")]
    //inv
    public GameObject shopInvButton1;
    public GameObject shopInvButton2;
    public GameObject shopInvButton3;
    public GameObject shopInvButton4;
    public GameObject shopInvButton5;
    public GameObject shopInvButton6;
    public GameObject shopInvButton7;
    public GameObject shopInvButton8;
    public GameObject shopInvButton9;
    public GameObject shopInvButton10;
    public GameObject shopInvButton11;
    public GameObject shopInvButton12;
    public GameObject shopInvButton13;
    public GameObject shopInvButton14;
    public GameObject shopInvButton15;
    public GameObject shopInvButton16;
    public GameObject shopInvButton17;
    public GameObject shopInvButton18;
    public GameObject shopInvButton19;
    public GameObject shopInvButton20;
    public GameObject shopInvButton21;
    public GameObject shopInvButton22;
    public GameObject shopInvButton23;
    public GameObject shopInvButton24;
    public GameObject shopInvButton25;
    public GameObject shopInvButton26;
    public GameObject shopInvButton27;
    public GameObject shopInvButton28;
    public GameObject shopInvButton29;
    public GameObject shopInvButton30;
    public GameObject shopInvButton31;
    public GameObject shopInvButton32;
    //shop
    public GameObject shopButton1;
    public GameObject shopButton2;
    public GameObject shopButton3;
    public GameObject shopButton4;
    public GameObject shopButton5;
    public GameObject shopButton6;
    public GameObject shopButton7;
    public GameObject shopButton8;
    public GameObject shopButton9;
    public GameObject shopButton10;
    public GameObject shopButton11;
    public GameObject shopButton12;
    public GameObject shopButton13;
    public GameObject shopButton14;
    public GameObject shopButton15;
    public GameObject[] shopInvShopButtonsArray;

    [Header("Display Information")]
    public GameObject displayBack;
    public GameObject displaySprite;
    public GameObject displayNameText;
    public GameObject displayHealthText;

    [Header("Sprites")]
    //Enemy sprites
    public Sprite spriteEnemyAi1;
    public Sprite spriteEnemyAi2;
    //Drops
    public Sprite spriteSlime;
    public Sprite snakeSkin;
    public Sprite spriteSmallHP;
    public Sprite spriteSmallMana;
    //Armor and weapons
    //Empty
    public Sprite spriteEmpty;
    public Sprite spriteEmptyBoots;
    public Sprite spriteEmptyLegs;
    public Sprite spriteEmptyBody;
    public Sprite spriteEmptyHelmet;
    public Sprite spriteEmptySword;
    public Sprite spriteEmptyBow;
    public Sprite spriteEmptyStaff;
    public Sprite spriteEmptyShield;
    //Leather
    public Sprite spriteLeatherBoots;
    public Sprite spriteLeatherLegs;
    public Sprite spriteLeatherBody;
    public Sprite spriteLeatherHelmet;
    public Sprite spriteWoodSword;
    public Sprite spriteWoodBow;
    public Sprite spriteWoodStaff;
    public Sprite spriteWoodShield;
    //Steel
    public Sprite spriteSteelBoots;
    public Sprite spriteSteelLegs;
    public Sprite spriteSteelBody;
    public Sprite spriteSteelHelmet;
    public Sprite spriteSteelSword;
    public Sprite spriteSteelBow;
    public Sprite spriteSteelStaff;
    public Sprite spriteSteelShield;
    //mystic
    public Sprite spriteMysticBoots;
    public Sprite spriteMysticLegs;
    public Sprite spriteMysticBody;
    public Sprite spriteMysticHelmet;
    public Sprite spriteMysticStaff;
    public Sprite spriteMysticBook;
    //warrior
    public Sprite spriteWarriorBoots;
    public Sprite spriteWarriorLegs;
    public Sprite spriteWarriorBody;
    public Sprite spriteWarriorHelmet;
    public Sprite spriteWarriorSword;
    public Sprite spriteWarriorShield;
    //ranged
    public Sprite spriteRangedBoots;
    public Sprite spriteRangedLegs;
    public Sprite spriteRangedBody;
    public Sprite spriteRangedHelmet;
    public Sprite spriteRangedBow;

    [Header("Shop")]
    int shopStatus = 1;
    public string[] shopStock = new string[15];
    public string shopSelected = "";

    [Header("Misc")]
    public GameObject player;
    public PlayerController pc;
    

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //pc = player.GetComponent<PlayerController>();
        invGameObjectArray = new GameObject[32] { inv1, inv2, inv3, inv4, inv5, inv6, inv7, inv8, inv9, inv10, inv11, inv12, inv13, inv14, inv15, inv16, inv17, inv18, inv19, inv20, inv21, inv22, inv23, inv24, inv25, inv26, inv27, inv28, inv29, inv30, inv31, inv32 };
        invButtonsArray = new GameObject[32] { invButton1, invButton2, invButton3, invButton4, invButton5, invButton6, invButton7, invButton8, invButton9, invButton10, invButton11, invButton12, invButton13, invButton14, invButton15, invButton16, invButton17, invButton18, invButton19, invButton20, invButton21, invButton22, invButton23, invButton24, invButton25, invButton26, invButton27, invButton28, invButton29, invButton30, invButton31, invButton32 };
        equipArray = new GameObject[8] { equipHelmet, equipBody, equipLegs, equipBoots, equipSword, equipBow, equipStaff, equipShield };
        equButtonsArray = new GameObject[8] { equButton1, equButton2, equButton3, equButton4, equButton5, equButton6, equButton7, equButton8 };
        shopInvArray = new GameObject[32] { shopInv1, shopInv2, shopInv3, shopInv4, shopInv5, shopInv6, shopInv7, shopInv8, shopInv9, shopInv10, shopInv11, shopInv12, shopInv13, shopInv14, shopInv15, shopInv16, shopInv17, shopInv18, shopInv19, shopInv20, shopInv21, shopInv22, shopInv23, shopInv24, shopInv25, shopInv26, shopInv27, shopInv28, shopInv29, shopInv30, shopInv31, shopInv32 };
        shopArray = new GameObject[15] { shop1, shop2, shop3, shop4, shop5, shop6, shop7, shop8, shop9, shop10, shop11, shop12, shop13, shop14, shop15 };
        shopInvShopButtonsArray = new GameObject[47] { shopInvButton1, shopInvButton2, shopInvButton3, shopInvButton4, shopInvButton5, shopInvButton6, shopInvButton7, shopInvButton8, shopInvButton9, shopInvButton10, shopInvButton11, shopInvButton12, shopInvButton13, shopInvButton14, shopInvButton15, shopInvButton16, shopInvButton17, shopInvButton18, shopInvButton19, shopInvButton20, shopInvButton21, shopInvButton22, shopInvButton23, shopInvButton24, shopInvButton25, shopInvButton26, shopInvButton27, shopInvButton28, shopInvButton29, shopInvButton30, shopInvButton31, shopInvButton32, shopButton1, shopButton2, shopButton3, shopButton4, shopButton5, shopButton6, shopButton7, shopButton8, shopButton9, shopButton10, shopButton11, shopButton12, shopButton13, shopButton14, shopButton15, };

        hotbarController();
        inventoryTitleText = inventoryTitleTextObj.GetComponent<Text>();
        inventoryDescText = inventoryDescTextObj.GetComponent<Text>();
        alertText = alertTextObj.GetComponent<Text>();
    }

    public void inventoryController()
    {
        //Open / close inventory
        if (pc.invOpen)
        {
            inventoryBack.SetActive(true);
            for (int i = 0; i < invGameObjectArray.Length; i++)
            {
                invGameObjectArray[i].SetActive(true);
                invButtonsArray[i].SetActive(true);
                if (i < 8)
                {
                    equipArray[i].SetActive(true);
                    equButtonsArray[i].SetActive(true);
                }
            }
            updateInv(1);
        }
        else if (!pc.invOpen)
        {
            inventoryBack.SetActive(false);
            for (int i = 0; i < invGameObjectArray.Length; i++)
            {
                invGameObjectArray[i].SetActive(false);
                invButtonsArray[i].SetActive(false);
                if (i < 8)
                {
                    equipArray[i].SetActive(false);
                    equButtonsArray[i].SetActive(false);
                }
            }
            showActionButtons(false);
            closeAlertText();
        }
        }//end void inventoryController

    public void updateInv(int num)
    {

        GameObject[] tempArray = new GameObject[32];

        if (num == 1)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = invGameObjectArray[i];
            }
        }
        else if (num == 2)
        {
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = shopInvArray[i];
            }
        }

        //update inventory
        for (int i = 0; i < invGameObjectArray.Length; i++)
        {
            tempArray[i].GetComponent<Image>().sprite = returnSprite(pc.inventory[i]);
        }

        //update equipment
        string[] equipment = new string[8] { pc.equHelmet, pc.equBody, pc.equLegs, pc.equBoots, pc.equSword, pc.equBow, pc.equStaff, pc.equShield };
        for (int i = 0; i < equipArray.Length; i++)
        {
            switch (equipment[i])
            {
                case "empty":
                    if (i == 0)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyHelmet;
                    else if (i == 1)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyBody;
                    else if (i == 2)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyLegs;
                    else if (i == 3)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyBoots;
                    else if (i == 4)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptySword;
                    else if (i == 5)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyBow;
                    else if (i == 6)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyStaff;
                    else if (i == 7)
                        equipArray[i].GetComponent<Image>().sprite = spriteEmptyShield;
                    break;
                default:
                    equipArray[i].GetComponent<Image>().sprite = returnSprite(equipment[i]);
                    break;
            }
        }
    }

    public void showActionButtons(bool tasty)
    {
        if (tasty)
        {
            invUse.SetActive(true);
            invEquip.SetActive(true);
            invDrop.SetActive(true);
            invCancel.SetActive(true);
        }
        else if (!tasty)
        {
            invUse.SetActive(false);
            invEquip.SetActive(false);
            invDrop.SetActive(false);
            invCancel.SetActive(false);
        }
        
    }

    public void hotbarController()
    {
        if (pc.currentWeapon == 1)
            inner1.GetComponent<Image>().sprite = inner1Equipt;
        else
            inner1.GetComponent<Image>().sprite = inner1Unequipt;

        if (pc.currentWeapon == 2)
            inner2.GetComponent<Image>().sprite = inner2Equipt;
        else
            inner2.GetComponent<Image>().sprite = inner2Unequipt;

        if (pc.currentWeapon == 3)
            inner3.GetComponent<Image>().sprite = inner3Equipt;
        else
            inner3.GetComponent<Image>().sprite = inner3Unequipt;

        if (pc.currentWeapon == 4)
            inner4.GetComponent<Image>().sprite = inner4Equipt;
        else
            inner4.GetComponent<Image>().sprite = inner4Unequipt;
    }

    public void callAlertWithInventory(int num)
    {
        openAlertText(pc.inventory[num]);
    }

    public void callAlertWithEquip(int num)
    {
        if (num == 1)
            openAlertText(pc.equHelmet);
        else if (num == 2)
            openAlertText(pc.equBody);
        else if (num == 3)
            openAlertText(pc.equLegs);
        else if (num == 4)
            openAlertText(pc.equBoots);
        else if (num == 5)
            openAlertText(pc.equSword);
        else if (num == 6)
            openAlertText(pc.equBow);
        else if (num == 7)
            openAlertText(pc.equStaff);
        else if (num == 8)
            openAlertText(pc.equShield);
    }

    public void callAlertWithShop(int num)
    {
        openAlertText(shopStock[num]);
    }

    public void openAlertText(string item)
    {
        inventoryTextBack.SetActive(true);
        inventoryTitleTextObj.SetActive(true);
        inventoryDescTextObj.SetActive(true);

        switch (item)
        {
            case "slime":
                inventoryTitleText.text = "Slime.";
                if (pc.invOpen)
                    inventoryDescText.text = "It feels slimey.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Sale price: 1 gold.";    
                break;
            case "smallHp":
                inventoryTitleText.text = "Health potion.";
                if (pc.invOpen)
                    inventoryDescText.text = "Heals: 20 hp.\nHeals some health, probably. I'd imagine so, atleast.";
                else if (pc.shopOpen)   
                    inventoryDescText.text = "Heal: 20 hp.\nSale price: 3 gold. Buy price: 10gp";
                break;
            case "smallMana":
                inventoryTitleText.text = "Mana potion.";
                if (pc.invOpen)
                    inventoryDescText.text = "Replenishes: 20 mana.\nAdd two teaspoons for extra flavour.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Replenishes: 20 mana.\nSale price: 3 gold. Buy price: 10gp";
                break;
            case "leatherBoots":
                inventoryTitleText.text = "Leather boots.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nThey'll keep your feet nice and warm.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "leatherLegs":
                inventoryTitleText.text = "Leather trousers";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nWhy was a slime carrying these?";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "leatherBody":
                inventoryTitleText.text = "Leather jacket.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nIt's got a ton of cool pockets, too.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "leatherHelmet":
                inventoryTitleText.text = "Leather helmet.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nI dont think it'll help much, but it's better than nothing.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "woodSword":
                inventoryTitleText.text = "Wooden sword.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: Sword +1.\nIt's not very sharp but it'd probably give you a headache.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Sword.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "woodStaff":
                inventoryTitleText.text = "Wooden staff.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Magic.\nI wonder what the orb is made out of.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Magic.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "woodBow":
                inventoryTitleText.text = "Wooden bow.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Bow.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Ranged.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "woodShield":
                inventoryTitleText.text = "Wooden shield.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nJust don't fight any fire creatures.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor.\nSale price: 5 gold. Buy price: 15 gold.";
                break;
            case "steelBoots":
                inventoryTitleText.text = "Steel boots.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nThey're pretty darn heavy.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelLegs":
                inventoryTitleText.text = "Steel legs.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nI'm not sure how well you could move around in these.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelBody":
                inventoryTitleText.text = "Steel body.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nJust don't get hit on your arms.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\n Sale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelHelmet":
                inventoryTitleText.text = "Steel helmet";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nBasically a Steel med helm.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelSword":
                inventoryTitleText.text = "Steel sword.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Sword.\nAlright, now we're talking.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Sword.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelStaff":
                inventoryTitleText.text = "Steel staff.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Magic.\nWow, I've never seen one of these before.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Magic.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelBow":
                inventoryTitleText.text = "Steel bow.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Ranged.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "steelShield":
                inventoryTitleText.text = "Steel shield.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nSteel kite shield.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +2 Armor.\nSale price: 10 gold. Buy price: 25 gold.";
                break;
            case "mysticBoots":
                inventoryTitleText.text = "Mystic Helmet.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.\nSell: 15gp. Buy: 60gp.";
                break;
            case "mysticLegs":
                inventoryTitleText.text = "Mystic Legs";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.\nSell: 15gp. Buy: 60gp.";
                break;
            case "mysticBody":
                inventoryTitleText.text = "Mystic Body";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.\nSell: 15gp. Buy: 60gp.";
                break;
            case "mysticHelmet":
                inventoryTitleText.text = "Mystic Helmet";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.\nSell: 15gp. Buy: 60gp.";
                break;
            case "mysticStaff":
                inventoryTitleText.text = "Mystic Staff";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +3 Magic.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +3 Magic.\nSell: 15gp. Buy: 60gp.";
                break;
            case "mysticBook":
                inventoryTitleText.text = "Mystic Book";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Magic.\nSell: 15gp. Buy: 60gp.";
                break;
            case "warriorBoots":
                inventoryTitleText.text = "Warrior boots.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.\nSell: 15gp. Buy: 60gp.";
                break;
            case "warriorLegs":
                inventoryTitleText.text = "Warrior legs.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.\nSell: 15gp. Buy: 60gp.";
                break;
            case "warriorBody":
                inventoryTitleText.text = "Warrior Body.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.\nSell: 15gp. Buy: 60gp.";
                break;
            case "warriorHelmet":
                inventoryTitleText.text = "Warropr Helmet.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Sword.\nSell: 15gp. Buy: 60gp.";
                break;
            case "warriorSword":
                inventoryTitleText.text = "Warrior Sword.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +3 Sword.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +3 Sword.\nSell: 15gp. Buy 60gp.";
                break;
            case "warriorShield":
                inventoryTitleText.text = "Warrior Shield.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +3 Armor, -1 Magic, -1 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +3 Armor, -1 Magic, -1 Ranged.\nSell: 15gp. Buy: 60gp.";
                break;
            case "rangedBoots":
                inventoryTitleText.text = "Ranged Boots.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.\nSell: 15gp. Buy: 60gp.";
                break;
            case "rangedLegs":
                inventoryTitleText.text = "Ranged Legs.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.\nSell: 15gp. Buy: 60gp.";
                break;
            case "rangedBody":
                inventoryTitleText.text = "Ranged Body.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.\nSell: 15gp. Buy: 60gp.";
                break;
            case "rangedHelmet":
                inventoryTitleText.text = "Ranged Helmet.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +1 Armor, +1 Ranged.\nSell: 15gp. Buy: 60gp.";
                break;
            case "rangedBow":
                inventoryTitleText.text = "Ranged Bow.";
                if (pc.invOpen)
                    inventoryDescText.text = "Stats: +3 Ranged.";
                else if (pc.shopOpen)
                    inventoryDescText.text = "Stats: +3 Ranged.\nSell: 15gp. Buy: 60gp.";
                break;

            //default
            default:
                inventoryTitleText.text = "Empty.";
                inventoryDescText.text = "Yep that's either invisible or there's nothing there.";
                break;
        }
    }

    public void closeAlertText()
    {
        inventoryTextBack.SetActive(false);
        inventoryTitleTextObj.SetActive(false);
        inventoryDescTextObj.SetActive(false);
    }

    public void shopController()
    {
        if (pc.shopOpen)
        {
            //Open game objects
            shopBack.SetActive(true);
            shopSelect1.SetActive(true);
            shopSelect2.SetActive(true);
            shopSelect3.SetActive(true);
            shopSelect4.SetActive(true);
            for (int i = 0; i < shopInvShopButtonsArray.Length; i++)
            {
                shopInvShopButtonsArray[i].SetActive(true);
                if (i < shopInvArray.Length)
                {
                    shopInvArray[i].SetActive(true);
                }
                if (i < shopArray.Length)
                {
                    shopArray[i].SetActive(true);
                }
            }
            updateInv(2);
            updateShop();
        }
        else if (!pc.shopOpen)
        {
            //Close game objects
            shopBack.SetActive(false);
            shopSelect1.SetActive(false);
            shopSelect2.SetActive(false);
            shopSelect3.SetActive(false);
            shopSelect4.SetActive(false);
            for (int i = 0; i < shopInvShopButtonsArray.Length; i++)
            {
                shopInvShopButtonsArray[i].SetActive(false);
                if (i < shopInvArray.Length)
                {
                    shopInvArray[i].SetActive(false);
                }
                if (i < shopArray.Length)
                {
                    shopArray[i].SetActive(false);
                }
            }
            showShopActionButtons(false);
            showShopInvActionButtons(false);
            closeAlertText();
        }
    }//end shopController

    void updateShop()
    {
        //Armor weapons
        if (shopStatus == 1)
        {
            shopStock = new string[15] { "mysticBoots", "mysticLegs", "mysticBody", "mysticHelmet", "empty",
                                        "warriorBoots", "warriorLegs", "warriorBody", "warriorHelmet", "empty",
                                        "rangedBoots", "rangedLegs", "rangedBody", "rangedHelmet", "empty" };
            for (int i = 0; i < shopArray.Length; i++)
            {
                shopArray[i].GetComponent<Image>().sprite = returnSprite(shopStock[i]);
            }
        }
        //Potions
        else if (shopStatus == 2)
        {
            shopStock = new string[15] { "smallHp", "smallMana", "smallHp", "smallMana", "smallHp",
                                        "smallMana", "smallHp", "smallMana", "smallHp", "smallMana",
                                        "smallHp", "smallMana", "smallHp", "smallMana", "smallHp" };
            for(int i = 0; i < shopArray.Length; i++)
            {
                shopArray[i].GetComponent<Image>().sprite = returnSprite(shopStock[i]);
            }
        }
        //Misc1
        else if (shopStatus == 3)
        {
            shopStock = new string[15] { "mysticStaff", "mysticBook", "empty", "empty", "empty",
                                        "warriorSword", "warriorShield", "empty", "empty", "empty",
                                        "rangedBow", "empty", "empty", "empty", "empty" };
            for (int i = 0; i < shopArray.Length; i++)
            {
                shopArray[i].GetComponent<Image>().sprite = returnSprite(shopStock[i]);
            }
        }
        //Misc2
        else if (shopStatus == 4)
        {
            shopStock = new string[15] { "empty", "empty", "empty", "empty", "empty",
                                        "empty", "empty", "empty", "empty", "empty",
                                        "empty", "empty", "empty", "empty", "empty" };
            for (int i = 0; i < shopArray.Length; i++)
            {
                shopArray[i].GetComponent<Image>().sprite = returnSprite(shopStock[i]);
            }
        }
    }

    public void setShopSelected(int num)
    {
        shopSelected = shopStock[num];
    }

    public void setShopStatus(int num)
    {
        shopStatus = num;
        updateShop();
    }

    public void showShopInvActionButtons(bool meme)
    {
        if (meme)
        {
            invShopSell.SetActive(true);
            invShopCancel.SetActive(true);
        }
        else if (!meme)
        {
            invShopSell.SetActive(false);
            invShopCancel.SetActive(false);
        }
    }

    public void showShopActionButtons(bool desu)
    {
        if (desu)
        {
            invShopBuy.SetActive(true);
            invShopCancel.SetActive(true);
        }
        else if (!desu)
        {
            invShopBuy.SetActive(false);
            invShopCancel.SetActive(false);
        }
    }

    public IEnumerator displayAlert(int time, string message)
    {
        alertTextBack.SetActive(true);
        alertTextObj.SetActive(true);
        alertText.text = message;
        yield return new WaitForSeconds(time);
        alertTextBack.SetActive(false);
        alertTextObj.SetActive(false);
    }

    public void enemyDisplayController(bool open, string enemy, int health, int maxHealth)
    {
        if (open)
        {
            //open display
            displayBack.SetActive(true);
            displaySprite.SetActive(true);
            displayNameText.SetActive(true);
            displayHealthText.SetActive(true);


            //set sprite
            if (enemy == "AI1")
            {
                displaySprite.GetComponent<Image>().sprite = spriteEnemyAi1;
                displayNameText.GetComponent<Text>().text = "Blob";               
            }
            else if (enemy == "AI2")
            {
                displaySprite.GetComponent<Image>().sprite = spriteEnemyAi2;
                displayNameText.GetComponent<Text>().text = "Snake";
            }
            displayHealthText.GetComponent<Text>().text = health + "/" + maxHealth;
        }
        else if (!open)
        {
            //close display
            displayBack.SetActive(false);
            displaySprite.SetActive(false);
            displayNameText.SetActive(false);
            displayHealthText.SetActive(false);
        }
    }

    Sprite returnSprite(string item)
    {

        switch (item)
        {
            case "empty":
               return spriteEmpty;
            case "slime":
                return spriteSlime;
            case "smallHp":
                return spriteSmallHP;
            case "smallMana":
                return spriteSmallMana;
            case "leatherBoots":
                return spriteLeatherBoots;
            case "leatherLegs":
                return spriteLeatherLegs;
            case "leatherBody":
                return spriteLeatherBody;
            case "leatherHelmet":
                return spriteLeatherHelmet;
            case "woodSword":
                return spriteWoodSword;
            case "woodStaff":
                return spriteWoodStaff;
            case "woodBow":
                return spriteWoodBow;
            case "woodShield":
                return spriteWoodShield;
            case "steelBoots":
                return spriteSteelBoots;
            case "steelLegs":
                return spriteSteelLegs;
            case "steelBody":
                return spriteSteelBody;
            case "steelHelmet":
                return spriteSteelHelmet;
            case "steelSword":
                return spriteSteelSword;
            case "steelBow":
                return spriteSteelBow;
            case "steelStaff":
                return spriteSteelStaff;
            case "steelShield":
                return spriteSteelShield;
            case "mysticBoots":
                return spriteMysticBoots;
            case "mysticLegs":
                return spriteMysticLegs;
            case "mysticBody":
                return spriteMysticBody;
            case "mysticHelmet":
                return spriteMysticHelmet;
            case "mysticStaff":
                return spriteMysticStaff;
            case "mysticBook":
                return spriteMysticBook;
            case "warriorBoots":
                return spriteWarriorBoots;
            case "warriorLegs":
                return spriteWarriorLegs;
            case "warriorBody":
                return spriteWarriorBody;
            case "warriorHelmet":
                return spriteWarriorHelmet;
            case "warriorSword":
                return spriteWarriorSword;
            case "warriorShield":
                return spriteWarriorShield;
            case "rangedBoots":
                return spriteRangedBoots;
            case "rangedLegs":
                return spriteRangedLegs;
            case "rangedBody":
                return spriteRangedBody;
            case "rangedHelmet":
                return spriteRangedHelmet;
            case "rangedBow":
                return spriteRangedBow;
            default:
                return spriteEmpty;
        }
    }

}//end class
