using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController playerController;
    public Rigidbody playerRB;
    public float speed;
    public float jumpForce;
    public float gravity;
    public float turnSmoothTime;
    private float turnSmoothVelocity;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerRB = GetComponent<Rigidbody>();
        speed = 8f;
        jumpForce = 12;
        gravity = 20f;
        turnSmoothTime = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MovePlayer();
    }

    public void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        playerRB.velocity = new Vector3(h * speed, playerRB.velocity.y, v * speed);

        if (Input.GetKey(KeyCode.Space) && CheckGround())
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, jumpForce, playerRB.velocity.z);
        }
    }

    public bool CheckGround()
    {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
