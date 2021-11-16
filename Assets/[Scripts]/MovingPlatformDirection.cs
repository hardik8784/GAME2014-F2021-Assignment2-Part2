/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 16,2021
 * File : MovingPlatformDirection.cs
 * Description : This is the enum for the Direction
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    V0.2 > Added enum direction of moving Platforms 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MovingPlatformDirection 
{
  HORIZONTAL,
  VERTICAL,
  DIAGONAL_UP,
  DIAGONAL_DOWN,
  NUM_OF_DIRECTIONS
}
