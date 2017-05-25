/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour {



    // easy dropDown for editing in inspector
    [Header("Dungeon")]
    //Design 1
    public GameObject floor1; //0
    public GameObject wall1; //1
    public GameObject torchLeft1; //3
    public GameObject torchRight1; //4
    public GameObject spikedFloor1; //5

    //Design 2
    public GameObject floor2;
    public GameObject wall2;
    public GameObject torchLeft2;
    public GameObject torchRight2;
    public GameObject spikedFloor2;

    //Constants
    public GameObject exit; //2

    public GameObject shopChest;

    [Header("Enemies")]
    public GameObject AI1;
    public GameObject AI2;

    [Header("Misc")]
    bool spawnedShop = false;
    public int dungeonSize = 50;
    int iterationLoops = 1000;
    int[,] maze;
    public GameObject statsTextObj;
    public StatsText statsTextCon;

    public LevelController levelCon;
    GameObject player;
    PlayerController playerCon;
    
    // Use this for initialization
	void Start ()
    {
        player = GameObject.Find("_player");
        playerCon = player.GetComponent<PlayerController>();
        levelCon = GetComponent<LevelController>();

        maze = new int[dungeonSize, dungeonSize];
        generateDungeon();
	}

    public void destroyDungeon()
    {
        GameObject[] dungeonArray = GameObject.FindGameObjectsWithTag("dungeon");
        for (int i = 0; i < dungeonArray.Length; i++)
        {
            Destroy(dungeonArray[i]);
        }
    }

    public void generateDungeon()
    {
        int currentX;
        int currentY;
        currentX = currentY = dungeonSize / 2;

        spawnedShop = false;

        //Level / Floor ++
        levelCon.dungeonLevel++;

        //Make the dugneon all bricks
        for (int i = 0; i < dungeonSize; i++)
        {
            for (int j = 0; j < dungeonSize; j++)
            {
                maze[i, j] = 1;
            }
        }

        //Make stating point floor
        maze[currentX, currentY] = 0;

        //Generate the dungeon
        for (int i = 0; i < iterationLoops; i++)
        {
            int tempRand = Random.Range(1, 5);

            //go up
            if (tempRand == 1)
            {
                if (currentY < dungeonSize -2)
                {
                    currentY += 1;
                }
            }
            //go right   
            else if (tempRand == 2)
            {
                if (currentX < dungeonSize -2)
                {
                    currentX += 1;
                }
            }
            //go down
            else if (tempRand == 3)
            {
                if (currentY > 2)
                {
                    currentY -= 1;
                }
            }
            //go left
            else if (tempRand == 4)
            {
                if (currentX > 2)
                {
                    currentX -= 1;
                }
            }

            //set position to floor
            maze[currentX, currentY] = 0;

            //make the exit
            if (i == iterationLoops - 1)
                maze[currentX, currentY] = 2;
        }

        //Fill dungeon
        for (int i = 1; i < dungeonSize - 1; i++)
        {
            for (int j = 1; j < dungeonSize - 1; j++)
            {
                //torchRight
                if (maze[i, j] == 1 && maze[i, j + 1] == 0)
                {
                    if (Random.Range(1, 20) == 10)
                        maze[i, j + 1] = 3;
                }
                //torchLeft
                if (maze[i, j] == 1 && maze[i, j - 1] == 0)
                {
                    if (Random.Range(1, 20) == 10)
                        maze[i, j - 1] = 4;
                }
                //spikedFloor
                if (maze[i, j] == 0 && maze[i + 1, j] != 1 || maze[i - 1, j] != 1 || maze[i, j - 1] != 1 || maze[i, j + 1] != 1)
                {
                    if (Random.Range(1, 100) == 1)
                        maze[i, j] = 5;
                }
            }
        }

        //Spawn the dungeon
        for (int i = 0; i < dungeonSize; i++)
        {
            for (int j = 0; j < dungeonSize; j++)
            {
                if (maze[i, j] == 0) //floor
                {
                    //Floor tile
                    if (levelCon.dungeonLevel <= 2)
                        Instantiate(floor1, new Vector3(j, i, 0), Quaternion.identity);
                    else if (levelCon.dungeonLevel > 2)
                        Instantiate(floor2, new Vector3(j, i, 0), Quaternion.identity);
                    //Shop
                    if (i > dungeonSize / 2 && !spawnedShop)
                    {
                        Instantiate(shopChest, new Vector3(j, i, -1), Quaternion.identity);
                        spawnedShop = true;
                        continue; //Exit current loop, continue onwards with
                                  //the rest of the for loop
                    }
                    //Enemies
                    if (levelCon.dungeonLevel <= 2)
                    {
                        if (Random.Range(1, 100) < 5)
                        {
                            levelCon.enemiesLeft += 1;
                            Instantiate(AI1, new Vector3(j, i, -1), Quaternion.identity);
                        }
                    }
                    else if (levelCon.dungeonLevel > 2 && levelCon.dungeonLevel <= 15)
                    {
                        if (Random.Range(1, 100) < 5)
                        {
                            levelCon.enemiesLeft += 1;
                            Instantiate(AI2, new Vector3(j, i, -1), Quaternion.identity);
                        }
                    }
                }
                else if (maze[i, j] == 1) //wall
                {
                    if (levelCon.dungeonLevel <= 2)
                        Instantiate(wall1, new Vector3(j, i, 0), Quaternion.identity);
                    else if (levelCon.dungeonLevel > 2)
                        Instantiate(wall2, new Vector3(j, i, 0), Quaternion.identity);
                }
                else if (maze[i, j] == 2) //exit
                    Instantiate(exit, new Vector3(j, i, 0), Quaternion.identity);
                else if (maze[i, j] == 3) //torch left
                {
                    if (levelCon.dungeonLevel <= 2)
                        Instantiate(torchLeft1, new Vector3(j, i, 0), Quaternion.identity);
                    else if (levelCon.dungeonLevel > 2)
                        Instantiate(torchLeft2, new Vector3(j, i, 0), Quaternion.identity);
                }
                else if (maze[i, j] == 4) //torch right
                {
                    if (levelCon.dungeonLevel <= 2)
                        Instantiate(torchRight1, new Vector3(j, i, 0), Quaternion.identity);
                    else if (levelCon.dungeonLevel > 2)
                        Instantiate(torchRight2, new Vector3(j, i, 0), Quaternion.identity);
                }
                else if (maze[i, j] == 5) //spiked floor
                {
                    if (levelCon.dungeonLevel <= 2)
                        Instantiate(spikedFloor1, new Vector3(j, i, 0), Quaternion.identity);
                    else if (levelCon.dungeonLevel > 2)
                        Instantiate(spikedFloor2, new Vector3(j, i, 0), Quaternion.identity);
                }
                    
                
            }
        }

        //Relocate player
        playerCon.relocatePlayer();
        //Update Enemies Left
        statsTextCon.updateEnemiesLeft();
        //Update dungeon level
        statsTextCon.updateDungeonLevel();

    }//end of void generateDungeon
}//end of class