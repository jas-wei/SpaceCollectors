using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    private Vector2 cameraPositionGoal;

    private float cameraX;
    private float cameraY;

    private void Update()
    {
        cameraPositionGoal = new Vector2((player.position.x / 2), (player.position.y / 2));

        //transform.position = new Vector2((player.position.x/2), (player.position.y / 2));

        //Debug.Log("My math.abs for x is: " + cameraPositionGoal.x);
        if (Math.Abs(cameraPositionGoal.x) <= 6.5)
        {
            cameraX = cameraPositionGoal.x;
        }

        //Debug.Log("My math.abs for y is: " + cameraPositionGoal.y);
        if (Math.Abs(cameraPositionGoal.y) <= 5.3)
        {
            cameraY = cameraPositionGoal.y;
        }

        transform.position = new Vector2((cameraX), (cameraY));
    }
}
