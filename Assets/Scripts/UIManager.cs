using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject targetRotationObject;
    public GameObject targetScaleObject;
    Quaternion targetObjectDefaultRotation;
    Vector3 targetObjectDefaultScale;

    private void Start()
    {
        targetObjectDefaultRotation = targetRotationObject.transform.rotation;
        targetObjectDefaultScale = targetScaleObject.transform.localScale;
    }

    public void ResetRotation()
    {
        targetRotationObject.transform.rotation = targetObjectDefaultRotation;
    }

    public void ResetScale()
    {
        targetScaleObject.transform.localScale = targetObjectDefaultScale;
    }

    public void ExitApp()
    {
        Debug.Log("Exiting app");
        Application.Quit();
    }
}
