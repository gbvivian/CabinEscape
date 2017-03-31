using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	public Item item;

	void OnMouseUp() {
		if (FindObjectOfType<Inventory> ().AddItemIfAbsent (item)) {
			print ("picked up " + item.type);
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<Collider> ().enabled = false;
		}
	}
}
