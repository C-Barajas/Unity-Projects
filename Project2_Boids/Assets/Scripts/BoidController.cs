
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoidController : MonoBehaviour {

    public GameObject fishPrefab; // fish gameObject
    public GameObject goalPrefab; // waypoint gameObject for follow the leader
    public static int tankSize = 4; // area where fish can swim within scene

    static int numFish = 100;      // controls total number of fish in scene
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;   // target position of flock

    // flags to control the type of flight mode
    private int lazyFlightMode = 0;
    private int circleATree = 0;
    private int followTheLeader = 0;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < numFish; i++)
        {
            // creates position for fish in 3D space within range of tankSize
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));

            allFish[i] = (GameObject) Instantiate (fishPrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	 void Update () {

        if (lazyFlightMode == 1)
        {
            // randomly reset where goalPos is in tank
            if (Random.Range(0, 10000) < 50)
            {
                goalPos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));           
            }
        }

        if(circleATree == 1)
        {
            // method is empty because it applies the flocking rules to the group of fish without assigning a new destination
            // makes group of fish circle around the position in which the center of the group currently is when this mode is turned on
        }

        if(followTheLeader == 1)
        {
            if (Random.Range(0, 10000) < 50)
            {             
                goalPos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));

                goalPrefab.transform.position = goalPos;
            }
         }
	}

    // method to turn LazyFlight mode flag on
    public void LazyFlight()
    {
        lazyFlightMode = 1;
        circleATree = 0;
        followTheLeader = 0;
    }

    // turns CircleATree flight mode on
    public void CircleATree()
    {
        circleATree = 1;
        lazyFlightMode = 0;
        followTheLeader = 0;
    }

    // turns FollowTheLeader flight mode on
    public void FollowTheLeader()
    {
        followTheLeader = 1;
        lazyFlightMode = 0;
        circleATree = 0;
    }

   
}
