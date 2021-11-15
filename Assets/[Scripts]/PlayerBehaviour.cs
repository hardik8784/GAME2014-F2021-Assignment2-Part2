/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 15,2021
 * File : PlayerBehaviour.cs
 * Description : This is the UI Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added function for the Movement of the Player
 *                    v0.3 > Added Jumping and movement using Raycast and Fixedupdate,Added Player Animation
 *                    v0.4 > Added Animation and AirControl 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float HorizontalForce;
    public float VerticalForce;
    public bool isGrounded;
    public Transform GroundOrigin;
    public float GroundRadius;
    public LayerMask GroundLayerMask;

    [Range(0.1f,0.9f)]
    public float AirControlFactor;

    private Rigidbody2D RigidBody;

    private Animator AnimatorController;

    [Header("Animation")]
    public PlayerAnimationState State;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        AnimatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckIfGrounded();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (isGrounded)
        {
            float DeltaTime = Time.deltaTime;

            //Inputs for Keyboards
           
            float y = Input.GetAxisRaw("Vertical");
            float Jump = Input.GetAxisRaw("Jump");

            if (x != 0)
            {
                x = FlipAnimation(x);
                AnimatorController.SetInteger("AnimationState", 1);     //RUN State
                State = PlayerAnimationState.RUN;
            }
            else
            {
                AnimatorController.SetInteger("AnimationState", 0);     //IDLE State
                State = PlayerAnimationState.IDLE;
            }
            //This is for Inputs for Touch
            Vector2 WorldTouch = new Vector2();
            foreach (var Touch in Input.touches)
            {
                WorldTouch = Camera.main.ScreenToWorldPoint(Touch.position);
            }


            float HorizontalMoveForce = x * HorizontalForce;// * DeltaTime;
            float JumpMoveForce = Jump * VerticalForce;// * DeltaTime;

            float Mass = RigidBody.mass * RigidBody.gravityScale;

            RigidBody.AddForce(new Vector2(HorizontalMoveForce, JumpMoveForce) * Mass);
            RigidBody.velocity *= 0.99f;
        }
        else
        {
            AnimatorController.SetInteger("AnimationState", 2);     //JUMP State
            State = PlayerAnimationState.JUMP;

            if (x != 0)
            {
                x = FlipAnimation(x);

                float HorizontalMoveForce = x * HorizontalForce * AirControlFactor;

                float Mass = RigidBody.mass * RigidBody.gravityScale;

                RigidBody.AddForce(new Vector2(HorizontalMoveForce, 0.0f) * Mass);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isGrounded = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isGrounded = false;
    //}

    private void CheckIfGrounded()
    {
        RaycastHit2D Hit = Physics2D.CircleCast(GroundOrigin.position, GroundRadius, Vector2.down, GroundRadius, GroundLayerMask);

        isGrounded = (Hit) ? true : false;
    }

    private float FlipAnimation(float x)
    {
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(GroundOrigin.position,GroundRadius);
    }
}
