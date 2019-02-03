using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {

    public CinemachineVirtualCamera overWorldCam;
    public CinemachineVirtualCamera dungeonCam;

    //CinemachineBrain mainCamBrain;
    CameraMode currentMode;
    CinemachineVirtualCamera currCamera;

    public static CameraController instance;

    void Awake()
    {
        //mainCamBrain = GetComponentInChildren<CinemachineBrain>();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        UpdateCameraSituation(CameraMode.DungeonCam);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateCameraSituation(CameraMode.OverworldCam);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateCameraSituation(CameraMode.DungeonCam);
        }
    }

    public void UpdateCameraSituation(CameraMode cm)
    {
        if (currentMode.Equals(cm)) {return;}
        currentMode = cm;
        if (cm.Equals(CameraMode.OverworldCam))
        {
            overWorldCam.gameObject.SetActive(true);
            dungeonCam.gameObject.SetActive(false);
            currCamera = overWorldCam;
        } 
        else if (cm.Equals(CameraMode.DungeonCam))
        {
            overWorldCam.gameObject.SetActive(false);
            dungeonCam.gameObject.SetActive(true);
            currCamera = dungeonCam;
        }
        if (currCamera.Follow == null)
        {
            currCamera.Follow = GameData.playerRefObj.transform;
            currCamera.LookAt = GameData.playerRefObj.transform;
        }
    }


}
