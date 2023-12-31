using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject spaceShipInventoryGroup;
    public Interactable interactable;
    public bool inventoryIsOpen;

    public InventorySlot spaceShipStartSlot;
    public ItemBaggie itemBaggie;
    public SpaceShipInventoryManager spaceShipInventoryManager;

    public InventoryManager inventoryManager;
    public GameObject inventoryGroupParent;

    // public int total = 0;
    

    //public InventoryController inventoryController;


    //make sure to find tag of inventory and interactable when making their prefabs


    public void PickupItem(){
        if(Input.GetKeyDown(interactable.interactKey)){
            if (inventoryIsOpen == false){
                spaceShipInventoryGroup.SetActive(true);
                inventoryIsOpen = true;

                if (inventoryManager.score != 0){
                    itemBaggie.SetScore(inventoryManager.score);
                    inventoryManager.score = 0;

                    spaceShipInventoryManager.AddItem(itemBaggie);

                    for (int i = 0; i < 9; i++) {
                        InventorySlot inventorySlot = inventoryGroupParent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(i).gameObject.GetComponent<InventorySlot>();
                        DraggableItem itemInInventorySlot = inventorySlot.GetComponentInChildren<DraggableItem>();
                        // Debug.Log("item in inventory slot " + itemInInventorySlot);

                        if (itemInInventorySlot != null){
                            Debug.Log("item in inventory slot " + itemInInventorySlot);
                            Destroy(itemInInventorySlot.gameObject);
                        }
                    }
                }

            } else {
                spaceShipInventoryGroup.SetActive(false);
                inventoryIsOpen = false;

                DraggableBaggie itemInSlot = spaceShipStartSlot.GetComponentInChildren<DraggableBaggie>();

                if (inventoryIsOpen == false && itemInSlot != null) {
                    spaceShipInventoryManager.AddTotal(-1 * spaceShipInventoryManager.GetStartSlotValue());
                    Debug.Log("total after subtracting is " + SpaceShipInventoryManager.total);
                    // inventoryManager.score = 0;

                    Destroy(itemInSlot.gameObject);
                }
            }
        }
    }
}
