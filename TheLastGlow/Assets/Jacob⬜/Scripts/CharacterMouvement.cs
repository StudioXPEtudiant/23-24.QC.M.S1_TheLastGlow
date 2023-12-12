using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 0.7f;
    private float defSpeed;
    public float boost = 2;
    Rigidbody rb;
    Vector3 dir;
    public Animator animator;

    public GameObject mainCamera;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defSpeed = speed;
        
    }


    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Speed", dir.sqrMagnitude);
        if (Input.GetKeyDown("left shift"))
        {
            defSpeed = speed;
            defSpeed *= boost;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            defSpeed = speed;
        }
       
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * defSpeed * Time.fixedDeltaTime);
    }
}
