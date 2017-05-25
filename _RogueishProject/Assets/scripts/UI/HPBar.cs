/*
 * Christian Barajas
 * Project_1: Rogueish
 * Spring 2017
 * CS 596
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    public Scrollbar _sb;
    public GameObject player;
    public PlayerController pc;

	// Use this for initialization
	void Start ()
    {
        //_sb = GetComponent<Scrollbar>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //pc = player.GetComponent<PlayerController>();
	}
	
    public void updateHealth()
    {
        _sb.size = (pc.playerHealth / pc.playerMaxHealth);
    }
}
