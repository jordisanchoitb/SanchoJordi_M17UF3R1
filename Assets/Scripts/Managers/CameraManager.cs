using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    List<CinemachineVirtualCamera> cameras;

    void Start()
    {
        cameras = new List<CinemachineVirtualCamera>(FindObjectsOfType<CinemachineVirtualCamera>());
    }

    public void SwitchCamera(string cameraName)
    {
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            if (camera.gameObject.name.Contains(cameraName))
                camera.enabled = true;
            else
                camera.enabled = false;
        }
    }
}
