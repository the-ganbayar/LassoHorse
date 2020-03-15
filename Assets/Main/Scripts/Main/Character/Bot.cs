using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    private void Start()
    {
        Init();
    }

    void Update()
    {
        if (IsPlaying && rb.velocity.sqrMagnitude > 0)
        {
            animator.SetBool("Run", true);
        }
    }
}