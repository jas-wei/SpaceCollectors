using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipInventoryManager : MonoBehaviour
    {
    public InventorySlot inventorySlot; //start slot
    public GameObject inventoryBaggiePrefab;
    public DraggableBaggie draggableBaggie;

    public int total = 0;

    public void AddItem(ItemBaggie itemBaggie){
        DraggableBaggie itemInSlot = inventorySlot.GetComponentInChildren<DraggableBaggie>();
        if (itemInSlot == null){
            SpawnNewItem(itemBaggie);
            AddTotal(draggableBaggie.GetItemValue(itemBaggie));
            Debug.Log("total after adding is " + total);
        }
    }

    public void AddTotal(int baggieValue){
        total += baggieValue;
    }

    public int GetStartSlotValue (){
        DraggableBaggie itemInSlot = inventorySlot.GetComponentInChildren<DraggableBaggie>();
        int startSlotValue = 0;

        if (itemInSlot != null){
            startSlotValue = itemInSlot.score;
        } 
        
        Debug.Log("start val is " + startSlotValue);
        return startSlotValue;
    }

    void SpawnNewItem(ItemBaggie itemBaggie){
        GameObject newItemGo = Instantiate(inventoryBaggiePrefab, inventorySlot.transform);
        DraggableBaggie inventoryItem = newItemGo.GetComponent<DraggableBaggie>();
        inventoryItem.InitialiseItem(itemBaggie);
    }
}

