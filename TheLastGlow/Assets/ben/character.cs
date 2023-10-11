using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 0.7f;
    public float boost = 2;
    Rigidbody rb;
    Vector3 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("left shift"))
        {
            speed *= boost;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            speed = 0.7f;
        }
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }
}
