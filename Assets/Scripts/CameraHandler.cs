﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform camTrans;
    public Transform pivot;
    public Transform character;
    public Transform mTransform;

    public CharacterStatus characterStatus;
    public CameraConfig cameraConfig;
    public bool leftPivot;
    public float delta;

    public float mouseX;
    public float mouseY;
    public float smoothX;
    public float smoothY;
    public float smoothXVelocity;
    public float smoothYVelocity;
    public float lookAngle;
    public float titlAngle;

    public float scrollSpeed;
    public float shiftMuliplier = 3f;
    private float normalZ;

    private void Awake()
    {
        normalZ = cameraConfig.normalZ;
    }

    private void FixedUpdate()
    {
        FixedTick();
    }

    void FixedTick()
    {
        delta = Time.deltaTime;
        if (!Input.GetKey(KeyCode.R) && !Input.GetKey(KeyCode.S))
        {
            HandleScrolling();
            if (Input.GetMouseButton(2))
            {
                HandleRotation();
            }
        }
        HandlePosition();

        Vector3 targetPosition
            = Vector3.Lerp(mTransform.position, character.position, 1);
        mTransform.position = targetPosition;
    }

    void HandleScrolling()
    {
        bool mouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        bool mouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
        bool shiftButton = Input.GetKey(KeyCode.LeftShift);
        float resultScrollSpeed = shiftButton ? scrollSpeed * shiftMuliplier
            : scrollSpeed;
        if (mouseWheelUp)
        {
            normalZ += resultScrollSpeed * delta;
            if (normalZ > 0)
            {
                normalZ = 0;
            }
        }
        if (mouseWheelDown)
        {
            normalZ -= resultScrollSpeed * delta;
        }
    }

    void HandlePosition()
    {
        float targetX = cameraConfig.normalX;
        float targetY = cameraConfig.normalY;
        float targetZ = normalZ;

        if (characterStatus.isAiming)
        {
            targetX = cameraConfig.aimX;
            targetZ = cameraConfig.aimZ;
        }

        if (leftPivot)
        {
            targetX *= -1;
        }

        Vector3 newPivotPosition = pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;

        Vector3 newCameraPosition = camTrans.localPosition;
        newCameraPosition.z = targetZ;

        float t = delta * cameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPosition, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);
    }

    void HandleRotation()
    {
        // Напрашивается input controller
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (cameraConfig.turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraConfig.turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraConfig.turnSmooth);
        }
        else
        {
            smoothX = mouseX;
            smoothY = mouseY;
        }

        lookAngle += smoothX * cameraConfig.Y_rot_speed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titlAngle -= smoothY * cameraConfig.X_rot_speed;
        titlAngle = Mathf.Clamp(titlAngle, cameraConfig.minAngle,
            cameraConfig.maxAngle);
        pivot.localRotation = Quaternion.Euler(titlAngle, 0, 0);
    }
}
