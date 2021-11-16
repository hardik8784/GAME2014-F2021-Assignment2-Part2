/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 15,2021
 * File : GameController.cs
 * Description : This is the Game Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Player always spawn where we set the Spawnpoint while starting the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform Player;
    public Transform PlayerSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Player.position = PlayerSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
