using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    private GameObject inventoryGroupParent;
    private Interactable interactable;
    public bool inventoryIsOpen;

    private int id;
    private InventoryManager inventoryManager;
    public Item[] itemToPickup;
    // public DraggableItem draggableItem;
    // public InventoryController inventoryController;

    private InventorySlot startSlot;


    void Start () {
        inventoryGroupParent = GameObject.FindWithTag("InventoryGroup");
        interactable = gameObject.transform.GetChild(0).gameObject.GetComponent<Interactable>();
        inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
        startSlot = inventoryGroupParent.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<InventorySlot>();
        Debug.Log("Debris name is " + gameObject.name);

        if (gameObject.name == "Homework Debris Variant(Clone)"){ 
            //Debug.Log("TileDebris Tag");
            id = 0;
        } else if (gameObject.name == "Flower Debris Variant(Clone)"){
            id = 1;
        } else if (gameObject.name == "Breakfast Debris Variant(Clone)"){
            id = 2;
        } else if (gameObject.name == "Graduation Debris Variant(Clone)"){
            id = 3;
        } else if (gameObject.name == "Trophy Debris Variant(Clone)"){
            id = 4;
        } else if (gameObject.name == "Ultraman Debris Variant(Clone)"){
            id = 5;
        } else if (gameObject.name == "Wedding Debris Variant(Clone)"){
            id = 6;
        } else if (gameObject.name == "Lexi Debris Variant(Clone)"){
            id = 7;
        } else if (gameObject.name == "Grandma Debris Variant(Clone)"){
            id = 8;
        } 
    }


    public void PickupItem(){
        if(Input.GetKeyDown(interactable.interactKey)){
            if (inventoryIsOpen == false){
                inventoryGroupParent.transform.GetChild(0).gameObject.SetActive(true);
                inventoryIsOpen = true;

                inventoryManager.AddItem(itemToPickup[id]);
                //Debug.Log("point is " + (int)itemToPickup[id].points);
            }
            else {
                inventoryGroupParent.transform.GetChild(0).gameObject.SetActive(false);
                inventoryIsOpen = false;

                DraggableItem itemInSlot = startSlot.GetComponentInChildren<DraggableItem>();

                if (inventoryIsOpen == false && itemInSlot != null) {
                    inventoryManager.AddScore(-1 * inventoryManager.GetStartSlotValue());
                    Debug.Log("score after subtracting is " + inventoryManager.score);
                    
                    Destroy(itemInSlot.gameObject);
                } else{
                    Destroy(gameObject);
                }
                
            }
        }
    }
}
