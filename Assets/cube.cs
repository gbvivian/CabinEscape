using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Collectable> ().item.type = Item.ItemType.KEY;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
