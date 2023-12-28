using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text totalText;
    public Rocket rocket;
    
    void Start()
    {
        totalText.text = "Total Score is: " + rocket.total.ToString();
    }
}
