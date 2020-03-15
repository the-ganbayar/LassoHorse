using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasso : MonoBehaviour
{
    LineRenderer renderer;
    void Start()
    {
        renderer = gameObject.Gc<LineRenderer>();
        renderer.positionCount += 2;
    }


    void Update()
    {
        renderer.SetPosition(0, transform.position);
        renderer.SetPosition(1, -transform.up * 10f);
    }
}
