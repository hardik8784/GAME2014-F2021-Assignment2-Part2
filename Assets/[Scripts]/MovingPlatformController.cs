/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 16,2021
 * File : MovingPlatformController.cs
 * Description : This is the MovingPlatform Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added 4 switch cases with using PingpongValue to move in 4 directions
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [Header("Movement")]
    public MovingPlatformDirection Direction;

    [Range(0.1f,10.0f)]
    public float Speed;
    [Range(1,20)]
    public float Distance;
    [Range(0.05f,0.1f)]
    public float DistanceoffSet;
    public bool isLooping;

    public Vector2 StartingPosition;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();

        if(isLooping)
        {
            isMoving = true;
        }
    }

    private void MovePlatform()
    {
        float PingPongValue = (isMoving) ? Mathf.PingPong(Time.time * Speed, Distance) : Distance;
        //Debug.Log(PingPongValue);

        if((!isLooping)&&(PingPongValue >= Distance -DistanceoffSet))
        {
            isMoving = false;
        }

        switch (Direction)
        {
            case MovingPlatformDirection.HORIZONTAL:
                transform.position = new Vector2(StartingPosition.x + PingPongValue, transform.position.y);
                break;
            case MovingPlatformDirection.VERTICAL:
                transform.position = new Vector2(StartingPosition.x , StartingPosition.y + PingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_UP:
                transform.position = new Vector2(StartingPosition.x + PingPongValue, StartingPosition.y + PingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(StartingPosition.x + PingPongValue, StartingPosition.y - PingPongValue);
                break;
        }

        
    }
}
