/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : November 16,2021
 * File : LOS.cs
 * Description : This is the LOS Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PolygonCollider2D))]
[System.Serializable]
public class LOS : MonoBehaviour
{
    [Header("Detection Properties")]
    public Collider2D CollidesWith;
    public ContactFilter2D ContactFilter;
    public List<Collider2D> ColliderList;
    private PolygonCollider2D LOSCollider;

    // Start is called before the first frame update
    void Start()
    {
        LOSCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Physics2D.GetContacts(LOSCollider,ContactFilter,ColliderList);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollidesWith = collision;
    }
}
