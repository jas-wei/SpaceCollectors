using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Drag Item")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform rectTransform;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Item item;

    [Header("Item Details")]
    public TMP_Text scoreText;
    public TMP_Text nameText;
    public Image image;

    void Start(){
        canvas = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
    }

    public void InitialiseItem(Item newItem){
        // Debug.Log("this is image" + image.sprite);
        // Debug.Log("this is newItem.image" + newItem.image);

        item = newItem;
        image.sprite = newItem.image;
        RefreshName(newItem);
        RefreshScore(newItem);
    } 

    public int GetItemValue(Item item){
        return (int)item.points;
    }

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("Begin Drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    
    public void RefreshName(Item newItem){
        nameText.text = image.sprite.name.ToString();// its gonna be the name of the sprite
        // Debug.Log(image.sprite.name.ToString());
    }

    public void RefreshScore(Item newItem){
        int newItemPoints = (int)newItem.points;
        scoreText.text = newItemPoints.ToString();
    }
}
