using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasso : MonoBehaviour
{
    LineRenderer lineRenderer;
    public float rendererDistance = 10f;
    public Transform targetTf;
    public bool isMoveTarget = false;
    void Start()
    {
        lineRenderer = gameObject.Gc<LineRenderer>();
        lineRenderer.positionCount += 2;
    }


    void Update()
    {
        lineRenderer.SetPosition(0, V3.Z(transform.position, transform.position.z + 0.25f));
        lineRenderer.SetPosition(1, targetTf.forward * rendererDistance + transform.position);
    }
}
