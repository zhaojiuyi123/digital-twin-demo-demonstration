using UnityEngine;
using Cinemachine;
public class ModelFocus : MonoBehaviour
{
    private bool isFocused;
    private Transform oldTransform;
    public CinemachineVirtualCamera focusVisualCamera;
    public float moveSpeed = 5f;
    public float damping = 0.1f;

    private void Start()
    {
        isFocused = false;
    }

    private void OnMouseDown()
    {
        if (!isFocused)
        {
            oldTransform = focusVisualCamera.transform;
            focusVisualCamera.LookAt = transform;
            focusVisualCamera.Follow = transform;
            isFocused = true;

        } else
        {
            focusVisualCamera.Follow = null;
            focusVisualCamera.LookAt = null;
            focusVisualCamera.transform.position = oldTransform.position;
            focusVisualCamera.transform.rotation = oldTransform.rotation;
            isFocused = false;
        }
    }
}