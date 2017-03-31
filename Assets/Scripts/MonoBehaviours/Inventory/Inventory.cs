using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public Image[] itemImages = new Image[numItemSlots];
	public Item[] items = new Item[numItemSlots];

	public const int numItemSlots = 4;

	public void ToggleSelect(int itemIndex) {
		Item item = items [itemIndex];
		if (item != null) {
			item.isSelected = !item.isSelected;
			item.DisplaySprite = item.isSelected ? item.highlightedSprite : item.unHighlightedSprite;
			itemImages [itemIndex].sprite = item.DisplaySprite;
			Debug.Log (item.type + " isSelected: " + item.isSelected);
		}
	}

	public bool AddItemIfAbsent(Item item) {
		if (!Contains (item)) {
			AddItem (item);
			return true;
		}
		return false;
	}

	public void AddItem (Item itemToAdd)
	{
		for (int i = 0; i < items.Length; i++) 
		{
			if (items [i] == null) 
			{
				items [i] = itemToAdd;
				itemImages [i].sprite = itemToAdd.unHighlightedSprite;
				itemImages [i].enabled = true;
				return;
			}
		}
	}

	public void RemoveItem (Item itemToRemove)
	{
		for (int i = 0; i < items.Length; i++) 
		{
			if (items[i] == itemToRemove) 
			{
				items [i] = null;
				itemImages [i].sprite = null;
				itemImages [i].enabled = false;
				return;
			}
		}
	}

	public bool Contains (Item item) {
		for (int i = 0; i < items.Length; i++) {
			if (items [i] == item)
				return true;
		}
		return false;
	}

	public void CombineItems() {
		List<Item> selectedItems = new List<Item>();
		for (int i = 0; i < items.Length; i++) {
			if (items[i] != null && items [i].isSelected) {
				ToggleSelect (i);
				selectedItems.Add (items [i]);
			}
		}

		// So far can only combine 2 items
		if (selectedItems.Count == 2) {
			Item candle = GameObject.Find ("candle").GetComponent<Collectable> ().item;
			Item lighter = GameObject.Find ("lighter").GetComponent<Collectable> ().item;
			if (selectedItems.Contains (candle) && selectedItems.Contains (lighter)) {
				RemoveItem (candle);
				RemoveItem (lighter);
				// TODO: add the lit lit lit
				// AddItem(litCandle);
			}
		}
	}

	/*
	void CombineItems(params Item[] items) {
		// Need at least 2 items to combine!
		if (items.Length < 2) {
			return;
		}

		switch (items[0].type) {
		case Item.ItemType.CANDLE:
			if (items[1].type == Item.ItemType.LIGHTER) {
				RemoveItem (items[1]);
				// delete item/sprite from wherever the lighter is
				// change the first item/sprite into the combined sprite
			}
			break;

		case Item.ItemType.LIGHTER:
			if (items[1].type == Item.ItemType.CANDLE) {
				RemoveItem (items[1]);
				// delete item/sprite from wherever the lighter is
				// change the first item/sprite into the combined sprite
			}
			break;

		default:
			break;
		}
	}
	*/
}
