using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float HorizontalForce;
    public float VerticalForce;

    private Rigidbody2D RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float DeltaTime = Time.deltaTime;

        //Inputs for Keyboards
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float Jump = Input.GetAxisRaw("Jump");

        //This is for Inputs for Touch
        Vector2 WorldTouch = new Vector2();
        foreach(var Touch in Input.touches)
        {
            WorldTouch = Camera.main.ScreenToWorldPoint(Touch.position);
        }


        float HorizontalMoveForce = x * HorizontalForce * DeltaTime;

        RigidBody.AddForce(Vector2.right * HorizontalMoveForce);
        //RigidBody.velocity *= 0.99f;
    }
}
