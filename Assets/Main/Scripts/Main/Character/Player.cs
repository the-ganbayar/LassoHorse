using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector3 mouseNewPos, mouseDelta, mouseOldPos;
    float camZDist;
    public float velocity = 10f;
    void Start()
    {
        camZDist = -A.Cam.transform.position.z;
    }
    void Update()
    {
        if (IsPlaying)
        {
            if (IsDown)
            {
                MouseButtonDown();
            }

            if (IsClick)
            {
                Controller();
            }

            if (IsUp)
            {
                animator.SetBool("Run", false);
                // isTraveling = true;
                // transform.parent = null;
                // startPos = transform.position;
            }
        }
    }

    void Controller()
    {
        mouseNewPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZDist);
        mouseDelta = A.Cam.ScreenToWorldPoint(mouseNewPos) - A.Cam.ScreenToWorldPoint(mouseOldPos);

        if (mouseDelta.sqrMagnitude > 0f)
            transform.eulerAngles += V3.Y(transform.eulerAngles, mouseDelta.x) * 20f;

        transform.position += transform.forward * Time.deltaTime * 5;
        animator.SetBool("Run", true);
        mouseOldPos = mouseNewPos;
    }
    public void MouseButtonDown()
    {
        mp = MP;
    }
}