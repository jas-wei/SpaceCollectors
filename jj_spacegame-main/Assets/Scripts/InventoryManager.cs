using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot inventorySlot; //start slot
    public GameObject inventoryItemPrefab;
    public DraggableItem draggableItem;

    public int score = 0;

    public void AddItem(Item item){
        DraggableItem itemInSlot = inventorySlot.GetComponentInChildren<DraggableItem>();
        if (itemInSlot == null){
            SpawnNewItem(item);
            AddScore(draggableItem.GetItemValue(item));
            Debug.Log("score after adding is " + score);
        }
    }

    public void AddScore(int itemValue){
        score += itemValue;
    }

    public int GetStartSlotValue (){
        DraggableItem itemInSlot = inventorySlot.GetComponentInChildren<DraggableItem>();
        int startSlotValue = 0;

        if (itemInSlot != null){
            startSlotValue = itemInSlot.GetItemValue(itemInSlot.item);
        } 
        
        // Debug.Log("start val is " + startSlotValue);
        return startSlotValue;
    }

    void SpawnNewItem(Item item){
        GameObject newItemGo = Instantiate(inventoryItemPrefab, inventorySlot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitialiseItem(item);
    }
}
