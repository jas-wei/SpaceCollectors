using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public Vector3 localScale;
    private float originalScaleX;
    private float originalScaleY;
    private float originalScaleZ;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
        originalScaleX = transform.localScale.x;
        originalScaleY = transform.localScale.y;
        originalScaleZ = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
    }

    public void Outline()
    {
        if(x < 1)
        {
            x++;
        }
        else
        {
            x = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Outline();
            transform.localScale = new Vector3(originalScaleX*1.2f, originalScaleY*1.1f, originalScaleZ);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Outline();
            transform.localScale = new Vector3(originalScaleX, originalScaleY, originalScaleZ);
        }
    }
}
