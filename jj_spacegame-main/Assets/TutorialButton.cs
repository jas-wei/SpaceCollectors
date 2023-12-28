using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    public GameObject info;
    private bool infoOpen = false;

    public void GetTutorial(){
        if (infoOpen== false){
            info.SetActive(true);
            infoOpen = true;
        } else{
            info.SetActive(false);
            infoOpen = false;
        }
    }
}
