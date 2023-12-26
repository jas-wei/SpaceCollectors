using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSlot : MonoBehaviour
{
    public GameObject inventoryGroupParent;
    public Player player; // just used to get if inventory is open
    private InventorySlot startSlot;

    void Awake() {
        startSlot = inventoryGroupParent.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<InventorySlot>();
        // Debug.Log("it is " + startSlot);
    }

    void Update() {
        //Debug.Log("it is " + startSlot);
        DraggableItem itemInSlot = startSlot.GetComponentInChildren<DraggableItem>();
        if (player.GetInventoryIsOpen() == false && itemInSlot != null) {
            Destroy(itemInSlot.gameObject);
            //total - points
        }
    }


}
