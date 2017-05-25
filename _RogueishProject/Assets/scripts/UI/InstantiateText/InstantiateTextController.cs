/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;

public class InstantiateTextController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(destroy());
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
