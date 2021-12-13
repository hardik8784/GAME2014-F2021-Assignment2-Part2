/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : December 12,2021
 * File : DeathPlaneController.cs
 * Description : This is the Death PlaneController Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > If Player collides with the deathplane, it respawns to PlayerSpawnPoint
 *                    v0.3 > Added Game ovver functionality
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneController : MonoBehaviour
{
    public Transform PlayerSpawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collision.transform.position = PlayerSpawnPoint.position;
                SceneManager.LoadScene("GameOver");           
        }
        else
        {
            collision.gameObject.SetActive(false);
        }
    }
}
