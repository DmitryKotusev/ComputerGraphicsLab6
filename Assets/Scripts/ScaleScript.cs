using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    public GameObject targetObject;

    Transform cameraTranform;
    Camera cameraClass;
    private Vector3 startTargetScale;
    private float startTargetToMouseDistance;
    Vector3 targetPosOnScreen;

    private void Start()
    {
        cameraTranform = GetComponent<CameraHandler>().camTrans;
        cameraClass = cameraTranform.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetStartScaleInfo();
        }
        if (Input.GetKey(KeyCode.S))
        {
            ScaleTargetObject();
        }
    }

    void GetStartScaleInfo()
    {
        Vector3 currentMousePos = Input.mousePosition;
        // currentMousePos.z = 0;
        targetPosOnScreen = cameraClass.WorldToScreenPoint(targetObject.transform.position);
        targetPosOnScreen.z = 0;
        startTargetScale = targetObject.transform.localScale;
        startTargetToMouseDistance = Vector3.Distance(currentMousePos, targetPosOnScreen);
    }

    void ScaleTargetObject()
    {
        // Vector3 normalMousePosition = Input.mousePosition;
        // normalMousePosition.z = 0;
        targetObject.transform.localScale = startTargetScale
            * Vector3.Distance(Input.mousePosition, targetPosOnScreen)
            / startTargetToMouseDistance;
    }
}
