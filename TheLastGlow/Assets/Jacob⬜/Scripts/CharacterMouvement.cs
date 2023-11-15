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
        if (Input.GetKeyDown("left shift"))
        {
            defSpeed = speed;
            defSpeed *= boost;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            defSpeed = speed;
        }
        rb.MovePosition(rb.position + dir * defSpeed * Time.fixedDeltaTime);
    //    mainCamera.transform.position += dir * defSpeed * Time.fixedDeltaTime;
    }
}
