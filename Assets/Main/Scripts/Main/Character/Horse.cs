using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    float moveSpeed = 4f;
    void Start()
    {

    }

    void Update()
    {
        if (A.IsPlaying)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}
