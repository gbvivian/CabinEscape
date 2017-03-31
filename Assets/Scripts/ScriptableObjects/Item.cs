using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {
	public Sprite DisplaySprite { get; set; }
	public Sprite unHighlightedSprite;
	public Sprite highlightedSprite;
	public bool isSelected = false;
	public ItemType type;

	public enum ItemType {
		CANDLE, LIGHTER, KEY

	}
}
