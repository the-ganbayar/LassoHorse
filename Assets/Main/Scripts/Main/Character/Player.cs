using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector3 mouseNewPos, mouseDelta, mouseOldPos;
    Transform horseTf;
    public Transform targetTf;
    float camZDist;
    bool isTraveling = false;
    public AnimationCurve curve;
    float timeElapsed = 0.5f;
    Vector3 startPos;
    void Start()
    {
        camZDist = -A.Cam.transform.position.z;
        horseTf = transform.parent;
    }
    void Update()
    {
        if (IsPlaying)
        {
            if (IsDown)
            {
                MouseButtonDown();
            }

            if (IsClick && !isTraveling)
            {
                Controller();
            }

            if (IsUp)
            {
                isTraveling = true;
                transform.parent = null;
                startPos = transform.position;
            }

            if (isTraveling)
            {
                MoveTarget();
            }
        }
    }

    void Controller()
    {
        mouseNewPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZDist);
        mouseDelta = A.Cam.ScreenToWorldPoint(mouseNewPos) - A.Cam.ScreenToWorldPoint(mouseOldPos);
        if (mouseDelta.sqrMagnitude > 0f)
        {
            horseTf.transform.eulerAngles += V3.Y(horseTf.transform.eulerAngles, mouseDelta.x) * 20f;
        }
        mouseOldPos = mouseNewPos;
    }

    void MoveTarget()
    {
        timeElapsed += Time.deltaTime;
        float dist = V3.Dis(transform.position, targetTf.position);

        if (dist > 0.1f)
        {
            transform.position = V3.Move(transform.position, V3.Y(V3.Y(targetTf.position, startPos.y), startPos.y + curve.Evaluate(timeElapsed)), 0.3f);
        }
        else
        {
            transform.SetParent(targetTf);
            horseTf = targetTf;
        }
    }
    public void MouseButtonDown()
    {
        mp = MP;
    }
}