using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DraggableBaggie : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public ItemBaggie itemBaggie;

    private RectTransform rectTransform;
    public Image image;
    public int score;
    public TMP_Text scoreText;

    void Start(){
        canvas = GameObject.FindGameObjectWithTag("SpaceShipCanvas").GetComponent<Canvas>();
    }

    public void InitialiseItem(ItemBaggie newItemBaggie){
        // Debug.Log("this is image" + image.sprite);
        // Debug.Log("this is newItemBaggie.image" + newItemBaggie.image);

        itemBaggie = newItemBaggie;
        image.sprite = newItemBaggie.image;
        score = newItemBaggie.score;
        RefreshScore();
    } 

    public int GetItemValue(ItemBaggie itemBaggie){
        return (int)itemBaggie.score;
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

    public void RefreshScore(){
        scoreText.text = score.ToString();
    }
}

