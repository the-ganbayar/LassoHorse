using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Vector3 mouseNewPos, mouseDelta, mouseOldPos;
    float camZDist;
    public float velocity = 10f;
    [HideInInspector] public bool isLasso = false;
    bool isLassoOutScreen = false;
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
                isLasso = true;
            }

            if (isLasso)
            {
                lasso.transform.position += transform.forward * Time.deltaTime * 20f;
                Vector3 vPort = A.Cam.WorldToScreenPoint(lasso.transform.position);
                if (vPort.y < 0 || vPort.y > A.Cam.pixelHeight || vPort.x < 0 || vPort.x > A.Cam.pixelWidth)
                {
                    isLassoOutScreen = true;
                }

                if (isLassoOutScreen)
                {
                    if (V3.Dis(lasso.transform.position, lassoStartTf.position) > 0.5f)
                    {
                        lasso.transform.position = V3.Move(lasso.transform.position, lassoStartTf.position, 0.5f);
                    }else
                    {
                        isLasso = false;
                        isLassoOutScreen = false;
                    }
                }
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