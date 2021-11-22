/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 16,2021
 * File : UIController.cs
 * Description : This is the UI Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added controls so that the UI only appears when in android,iPhone or editor mode.
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("OnScreenControls")]
    public GameObject OnScreenControls;

    [Header("Button Control Events")]
    public static bool JumpButtonDown;
    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckPlatform()
    {
        switch(Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.WindowsEditor:
                OnScreenControls.SetActive(true);
                break;

            default:
                OnScreenControls.SetActive(false);
                break;
        }
    }


    public void OnJumpButton_Down()
    {
        JumpButtonDown = true;
    }

    public void OnJumpButton_Up()
    {
        JumpButtonDown = false;
    }
}
