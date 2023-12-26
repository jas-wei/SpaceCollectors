using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public ChangeMaterial changeMaterial { get; private set; }

    [Header("Movement")]
    private int horizontalDirection = 0;
    private int verticalDirection = 0;
    public float speed = 5f;

    private SpriteRenderer spriteRenderer;

    [Header("Inventory Controller")]
    public GameObject inventoryGroup;
    private bool inventoryIsOpen;

    void Start(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        changeMaterial = GetComponent<ChangeMaterial>();
    }

    void Update()
    {
        GetInventoryIsOpen();
        Get_Direction();
        SetSpriteDirection();
        
    }

    public bool GetInventoryIsOpen(){
        if (inventoryGroup.activeSelf == false){
            inventoryIsOpen = false;
        } else{
            inventoryIsOpen = true;
        }

        return inventoryIsOpen;
    }

    private void Get_Direction()
    {   
        if (inventoryIsOpen == false){
            //Debug.Log("inventory closed");
            //movement
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Debug.Log("Going left");
                horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("Going right");
                horizontalDirection = 1;
            }
            else
            {
                horizontalDirection = 0;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("Going up");
                verticalDirection = 1;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("Going cown");
                verticalDirection = -1;
            }
            else
            {
                verticalDirection = 0;
            }

            this.direction = new Vector2(horizontalDirection, verticalDirection);
        } 
        
        else {
            this.direction = new Vector2(0, 0);
            //Debug.Log("inventory open");
        }
    }

    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

    private void SetSpriteDirection(){
        if (horizontalDirection == -1){
            spriteRenderer.flipX = false;
        } else if (horizontalDirection == 1){
            spriteRenderer.flipX = true;
        } 
    }

}
