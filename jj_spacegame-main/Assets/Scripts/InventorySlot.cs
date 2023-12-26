using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData ){
        if (transform.childCount == 0){
            GameObject dropped = eventData.pointerDrag;

            if (dropped.GetComponent<DraggableItem>() != null){
                DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
                draggableItem.parentAfterDrag = transform;
            } else {
                DraggableBaggie draggableBaggie = dropped.GetComponent<DraggableBaggie>();
                draggableBaggie.parentAfterDrag = transform;
            }

        }
    }
}

