/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 13,2021
 * File : UIBehaviour.cs
 * Description : This is the UI Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added function to switch between the scenes
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UIBehaviour : MonoBehaviour
{
    private int nextSceneIndex;
    private int previousSceneIndex;

    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;              // This code will be use to change to next scene
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;          // This code will be used to change to previous scene
    }

    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void OnMainMenuButtonPressed()                                           // This code is to change the scene from GameOverScreen to MenuScreen
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
