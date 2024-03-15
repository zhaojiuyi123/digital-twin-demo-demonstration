using RTS_Cam;
using UnityEngine;

public class ModelFocus : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    public float focusDistance = 5f; // 聚焦距离

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                // 聚焦到模型
                FocusOnModel();
            }
        }
    }

    private void FocusOnModel()
    {
        RTS_Camera RTSCamera = mainCamera.GetComponent<RTS_Camera>();
        if (RTSCamera != null )
        {
            RTSCamera.enabled = false;
        }
        // 保存原始相机位置和旋转
        originalCameraPosition = mainCamera.transform.position;
        originalCameraRotation = mainCamera.transform.rotation;

        // 计算相机的新位置和旋转
        Vector3 modelPosition = transform.position;
        Vector3 cameraPosition = modelPosition - mainCamera.transform.forward * focusDistance;
        Quaternion cameraRotation = Quaternion.LookRotation(modelPosition - cameraPosition, Vector3.up);

        print(mainCamera.transform.position);
        print(mainCamera.transform.rotation);

        // 调整相机位置和旋转
        mainCamera.transform.position = cameraPosition;
        mainCamera.transform.rotation = cameraRotation;

        print(cameraPosition);
        print(cameraRotation);

    }

    // 恢复相机到原始位置和旋转
    public void ResetCamera()
    {
        mainCamera.transform.position = originalCameraPosition;
        mainCamera.transform.rotation = originalCameraRotation;
    }
}