using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BotRandomMoveController : MB
{
    public float velocity = 10;
    Vector3 vel;
    void Start()
    {
        rb.NoG();
        rb.Constraints(false, true, false, true, true, true);
    }
    void Update()
    {
        if (IsPlaying)
        {
            rb.velocity = transform.forward * velocity;
        }
        else
            rb.V0();
    }
}
