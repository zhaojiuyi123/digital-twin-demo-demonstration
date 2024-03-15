using RTS_Cam;
using UnityEngine;

public class ModelFocus : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    public float focusDistance = 5f; // �۽�����

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
                // �۽���ģ��
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
        // ����ԭʼ���λ�ú���ת
        originalCameraPosition = mainCamera.transform.position;
        originalCameraRotation = mainCamera.transform.rotation;

        // �����������λ�ú���ת
        Vector3 modelPosition = transform.position;
        Vector3 cameraPosition = modelPosition - mainCamera.transform.forward * focusDistance;
        Quaternion cameraRotation = Quaternion.LookRotation(modelPosition - cameraPosition, Vector3.up);

        print(mainCamera.transform.position);
        print(mainCamera.transform.rotation);

        // �������λ�ú���ת
        mainCamera.transform.position = cameraPosition;
        mainCamera.transform.rotation = cameraRotation;

        print(cameraPosition);
        print(cameraRotation);

    }

    // �ָ������ԭʼλ�ú���ת
    public void ResetCamera()
    {
        mainCamera.transform.position = originalCameraPosition;
        mainCamera.transform.rotation = originalCameraRotation;
    }
}