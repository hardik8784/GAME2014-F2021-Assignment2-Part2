/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 15,2021
 * File : PlayerBehaviour.cs
 * Description : This is the UI Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    V0.2 > Added enum of States  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlayerAnimationState 
{
   IDLE,
   RUN,
   JUMP,
   NUM_OF_ANIMATION_STATES
}
