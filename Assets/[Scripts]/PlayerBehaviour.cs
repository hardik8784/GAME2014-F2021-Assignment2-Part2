/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 15,2021
 * File : PlayerBehaviour.cs
 * Description : This is the UI Behaviour Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added function for the Movement of the Player
 *                    v0.3 > Added Jumping and movement using Raycast and Fixedupdate,Added Player Animation
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

    private Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckIfGrounded();
    }

    private void Move()
    {

        if (isGrounded)
        {
            float DeltaTime = Time.deltaTime;

            //Inputs for Keyboards
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            float Jump = Input.GetAxisRaw("Jump");

            if (x != 0)
            {
                x = FlipAnimation(x);
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
