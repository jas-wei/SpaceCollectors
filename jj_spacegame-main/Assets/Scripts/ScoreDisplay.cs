using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text totalText;
    
    void Start()
    {
        int spaceShipTotal = SpaceShipInventoryManager.total;
        totalText.text = "Total Score is: " + spaceShipTotal.ToString();
    }
}
