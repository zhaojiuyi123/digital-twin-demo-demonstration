using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventMangager : MonoBehaviour
{
    public Button RoamButton;
    public Button IkButton;
    public Button DefaultButton;

    public GameObject DollyCart;
    public Camera IkCamera;
    public Camera RoamCamera;
    public Camera MainCamera;


    private void Start()
    {
        SetActiveCamera(MainCamera);
        RoamButton.onClick.AddListener(OnRoamButtonClick);
        IkButton.onClick.AddListener(OnIkButtonClick);
        DefaultButton.onClick.AddListener(OnDefaultButtonClick);


    }
    
    public void OnRoamButtonClick()
    {
        Roam roam = DollyCart.GetComponent<Roam>();
        if (roam != null)
        {
            // ¼¤»îÏà»ú
            SetActiveCamera(RoamCamera);
            print(roam.name);
            roam.Run();
        }
    }

    public void OnIkButtonClick()
    {
        SetActiveCamera(IkCamera);
    }

    public void OnDefaultButtonClick()
    {
        SetActiveCamera(MainCamera);
    }

    void Update()
    {
        
    }

    public void SetActiveCamera(Camera camera)
    {
        List<Camera> list = new List<Camera> { MainCamera, IkCamera, RoamCamera };
        foreach (Camera c in list)
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
}
