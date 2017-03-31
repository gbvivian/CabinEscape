using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {
	Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("PersistentCanvas").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			inventory.ToggleSelect (0);
			print ("pressed 1");
		
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			inventory.ToggleSelect (1);
			print ("pressed 2");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			inventory.ToggleSelect (2);
			print ("pressed 3");
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			inventory.ToggleSelect (3);
			print ("pressed 4");
		}
		else if (Input.GetKeyDown(KeyCode.U)) {
			inventory.CombineItems();
		}
		
	}






}
