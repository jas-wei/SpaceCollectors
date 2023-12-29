using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public Points points;
    public Sprite image;
}

public enum Points {
    low = 1,
    medium = 100, 
    high = 10000 
}
