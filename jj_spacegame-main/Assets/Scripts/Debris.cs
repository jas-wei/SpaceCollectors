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

        if (gameObject.CompareTag("TileDebris")){ 
            //Debug.Log("TileDebris Tag");
            id = 0;
        } else if (gameObject.CompareTag("FlowerDebris")){
            id = 1;
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
                }
                
            }
        }
    }
}
