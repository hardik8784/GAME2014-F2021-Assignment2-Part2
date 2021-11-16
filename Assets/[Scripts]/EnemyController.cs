/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 16,2021
 * File : EnemyController.cs
 * Description : This is the Enemy Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added the Movement of Enemy
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public float RunForce;
    public Transform LookAheadPoint;
    public Transform LookInFrontPoint;
    public LayerMask GroundLayerMask;
    public LayerMask ObstacleLayerMask;
    public bool isGroundAhead;

    private Rigidbody2D RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        LookInFront();
        MoveEnemy();
    }

    private void LookAhead()
    {
        var Hit = Physics2D.Linecast(transform.position, LookAheadPoint.position,GroundLayerMask);
        if(Hit)
        {
            isGroundAhead = true;
        }
        else
        {
            isGroundAhead = false;
        }
    }

    private void LookInFront()
    {

        var Hit = Physics2D.Linecast(transform.position, LookInFrontPoint.position, ObstacleLayerMask);
        if(Hit)
        {
            Flip();
        }
    }    

    private void MoveEnemy()
    {
       if(isGroundAhead)
        {
            RigidBody.AddForce(Vector2.left * RunForce * transform.localScale.x);
            RigidBody.velocity *= 0.99f;
        }
        else
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, LookAheadPoint.position);
        Gizmos.DrawLine(transform.position, LookInFrontPoint.position);
    }

}
