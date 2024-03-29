using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    [Header("Debris Interaction")]
    private GameObject inventoryGroupParent;
    private Interactable interactable;
    public bool inventoryIsOpen;

    [Header("Spawning Item")]
    public Item[] itemToPickup;
    private int id;
    private InventoryManager inventoryManager;
    private InventorySlot startSlot;

    SpriteRenderer spriteRenderer;
    public float fadeTimer = 3f;

    void Start () {
        inventoryGroupParent = GameObject.FindWithTag("InventoryGroup");
        interactable = gameObject.transform.GetChild(0).gameObject.GetComponent<Interactable>();
        inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
        startSlot = inventoryGroupParent.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.GetComponent<InventorySlot>();

        // fade stuff
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut(fadeTimer));

        if (gameObject.name == "Homework Debris Variant(Clone)"){ 
            id = 0;
        } else if (gameObject.name == "Flower Debris Variant(Clone)"){
            // Debug.Log("flower");
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

    IEnumerator FadeOut(float fadeTimer)
    {
        yield return new WaitForSeconds(fadeTimer);
        Color c = spriteRenderer.material.color;
        for (float alpha = 1f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.a = alpha;
            spriteRenderer.material.color = c;
            //Debug.Log("f is " + alpha);
            yield return new WaitForSeconds(0.1f);
        }
        // Destroy(gameObject);
        while (inventoryIsOpen) {
            yield return new WaitForSeconds(0.1f);
        }
        Object.Destroy(this.gameObject);
        // Debug.Log("object destroeyed");
    }
}