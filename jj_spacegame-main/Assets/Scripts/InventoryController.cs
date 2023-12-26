using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public bool inventoryIsClose;

    void Update(){
        if (Input.GetKeyDown("e")){
            if (inventoryIsClose == true){
                Inventory.SetActive(true);
                inventoryIsClose = false;
            }
        
            else {
                Inventory.SetActive(false);
                inventoryIsClose = true;
            }
        }
    }
}
