using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject targetRotationObject;
    public GameObject targetScaleObject;
    public GameObject axis;
    public GameObject planes;

    public GameObject targetVertices;
    public GameObject targetLines;
    public MeshRenderer targetMeshRenderer;

    public GameObject xVertices;
    public GameObject xLines;
    public GameObject xMeshContainer;

    public GameObject yVertices;
    public GameObject yLines;
    public GameObject yMeshContainer;

    public GameObject zVertices;
    public GameObject zLines;
    public GameObject zMeshContainer;

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

    public void SwitchAxisMode()
    {
        axis.SetActive(!axis.activeSelf);
    }

    public void SwitchPlanesMode()
    {
        planes.SetActive(!planes.activeSelf);
        // Вкл/выкл проекций
    }

    public void SwitchVerticesMode()
    {
        targetVertices.SetActive(!targetVertices.activeSelf);
        targetLines.SetActive(!targetLines.activeSelf);

        xVertices.SetActive(!xVertices.activeSelf);
        xLines.SetActive(!xLines.activeSelf);

        yVertices.SetActive(!yVertices.activeSelf);
        yLines.SetActive(!yLines.activeSelf);

        zVertices.SetActive(!zVertices.activeSelf);
        zLines.SetActive(!zLines.activeSelf);
    }

    public void SwitchMeshMode()
    {
        targetMeshRenderer.enabled = !targetMeshRenderer.enabled;
        xMeshContainer.SetActive(!xMeshContainer.activeSelf);
        yMeshContainer.SetActive(!yMeshContainer.activeSelf);
        zMeshContainer.SetActive(!zMeshContainer.activeSelf);

    }

    public void ExitApp()
    {
        Debug.Log("Exiting app");
        Application.Quit();
    }
}
