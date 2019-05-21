using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject targetObject;
    public float rotSpeed;

    Transform cameraTranform;

    private void Start()
    {
        cameraTranform = GetComponent<CameraHandler>().camTrans;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RotateTargetObject();
        }
    }

    void RotateTargetObject()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        targetObject.transform.RotateAround(cameraTranform.up, -rotX);
        targetObject.transform.RotateAround(cameraTranform.right, rotY);
    }
}
