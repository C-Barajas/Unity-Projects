using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour {

    public float speed = 0.001f;

    // how fast fish will turn
    float rotationSpeed = 4.0f;

    // head toward average heading toward group
    Vector3 averageHeading;

    // head toward average position of group
    Vector3 averagePosition;

    // max distance fish need to be to flock; only flock if near each other
    float neighbourDistance = 3.0f;

    bool turning = false;

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
        // testing position of fish from center of tank
        if(Vector3.Distance(transform.position, Vector3.zero) >= BoidController.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        // calculates direction back toward center of tank and rotate fish around
        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }

        else
        {
            if (Random.Range(0, 5) < 1)
                ApplyRules();
        }
      
        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    // flocking rules
    void ApplyRules()
    {
        GameObject[] gos;
        gos = BoidController.allFish;

        // points to center of group
        Vector3 flockCenter = Vector3.zero;

        // avoid hitting other fish in group
        Vector3 flockAvoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = BoidController.goalPos;

        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                // checking distance to determine group
                if(dist <= neighbourDistance)
                {
                    flockCenter += go.transform.position;
                    groupSize++;
                    // if fish get to close, they need to avoid one another
                    if(dist < 1.0f)
                    {
                        flockAvoid = flockAvoid + (this.transform.position - go.transform.position);

                    }

                    Flocking anotherFlock = go.GetComponent<Flocking>();
                    gSpeed = gSpeed + anotherFlock.speed; 
                }
            }
        }
        // check if in a group
        if(groupSize > 0)
        {
            // calculates average center of group
            flockCenter = flockCenter / groupSize + (goalPos - this.transform.position);
            // calculates average speed of group
            speed = gSpeed / groupSize;

            // direction fish need to turn
            Vector3 direction = (flockCenter + flockAvoid) - transform.position;

            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
    }
}
