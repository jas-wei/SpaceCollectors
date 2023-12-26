using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "ItemBaggie", menuName = "Scriptable object/ItemBaggie")]
public class ItemBaggie : ScriptableObject
{
    public Sprite image;
    public int score = 0;

    public void SetScore(int newScore){
        score = newScore;
    }
    // public BaggieScore baggieScore;
}
