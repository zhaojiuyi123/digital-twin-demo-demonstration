using Cinemachine;
using PROJECT;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMangager : MonoBehaviour
{
    public Button RoamButton;
    public Button IkButton;
    public Button RTSButton;
    public Button FocusButton;
    public Utils utils;
    public GameObject IKObject;
    public GameObject DollyCart;
    public CinemachineVirtualCamera RoamCamera;
    public CinemachineVirtualCamera FocusCamera;
    public CinemachineVirtualCamera IKCamera;
    public Camera RTSCamera;
    public Camera MainCamera;

    public List<Camera> cameraList;
    public List<CinemachineVirtualCamera> VisualCameraList;




    private void Start()
    {
        utils = new Utils();
        cameraList = new List<Camera> { RTSCamera, MainCamera };
        VisualCameraList = new List<CinemachineVirtualCamera> { RoamCamera, FocusCamera, IKCamera };

        SetActiveCamera(RTSCamera);
        RoamButton.onClick.AddListener(OnRoamButtonClick);
        IkButton.onClick.AddListener(OnIkButtonClick);
        RTSButton.onClick.AddListener(OnRTSButtonClick);
        FocusButton.onClick.AddListener(OnFocusButtonClick);
    }

    public void OnRoamButtonClick()
    {
        Roam roam = DollyCart.GetComponent<Roam>();
        if (roam != null)
        {
            // 激活相机
            SetActiveVisualCamera(RoamCamera);
            roam.Run();
        }
    }

    public void OnFocusButtonClick()
    {
        // 激活相机
        SetActiveVisualCamera(FocusCamera);
        utils.SetComponentsActive<Move>(IKObject.transform, false);
    }

    public void OnIkButtonClick()
    {
        SetActiveVisualCamera(IKCamera);
        utils.SetComponentsActive<Move>(IKObject.transform, true);
    }

    public void OnRTSButtonClick()
    {
        SetActiveCamera(RTSCamera);
        utils.SetComponentsActive<Move>(IKObject.transform, false);

    }

    void Update()
    {
        
    }

    public void SetActiveCamera(Camera camera)
    {
        foreach (Camera c in cameraList)
        {
            if (camera == c)
            {
                c.enabled = true;
            }
            else { 
                c.enabled = false;
            }
        }
    }
    public void SetActiveVisualCamera(CinemachineVirtualCamera camera)
    {
        SetActiveCamera(MainCamera);
        foreach (CinemachineVirtualCamera c in VisualCameraList)
        {
            if (camera == c)
            {
                c.enabled = true;
            }
            else
            {
                c.enabled = false;
            }
        }
    }
}
