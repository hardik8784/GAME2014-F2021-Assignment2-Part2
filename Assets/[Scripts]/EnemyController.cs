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
    [Header("Player Detection")]
    public LOS EnemyLOS;

    [Header("Movement")]
    public float RunForce;
    public Transform LookAheadPoint;
    public Transform LookInFrontPoint;
    public LayerMask GroundLayerMask;
    public LayerMask ObstacleLayerMask;
    public bool isGroundAhead;

    [Header("Animation")]
    public Animator AnimationController;

    private Rigidbody2D RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        EnemyLOS = GetComponent<LOS>();
        AnimationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        LookInFront();
        if (!HasLOS())
        {
            AnimationController.enabled = true;
            AnimationController.Play("Enemy-Clip");
            MoveEnemy();
        }
        else
        {
            AnimationController.enabled = false;
        }
    }

    private bool HasLOS()
    {
        if(EnemyLOS.ColliderList.Count > 0)
        {
            if((EnemyLOS.CollidesWith.gameObject.CompareTag("Player") && (EnemyLOS.ColliderList[0].gameObject.CompareTag("Player"))))
            {
                return true;
            }
        }
        else 
        {
            foreach(var Collider in EnemyLOS.ColliderList)
            {
                if(Collider.gameObject.CompareTag("Player"))
                {
                    var Hit = Physics2D.Raycast(LookInFrontPoint.position, Vector3.Normalize(Collider.transform.position - LookInFrontPoint.position),5.0f, EnemyLOS.ContactFilter.layerMask);
                    if((Hit)&&(Hit.collider.gameObject.CompareTag("Player")))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
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
