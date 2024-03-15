using UnityEngine;

public class OrbitController : MonoBehaviour
{

    public float moveSpeed = 50f;    // 相机移动速度

    private bool isDragging = false;    // 是否正在拖拽相机
    private Vector3 dragStartPosition;    // 拖拽开始时的鼠标位置

    void Update()
    {
        // 通过方向键控制相机移动
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 处理鼠标拖拽相机
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 dragDelta = currentMousePosition - dragStartPosition;
            dragStartPosition = currentMousePosition;

            transform.Translate(-dragDelta * 0.01f);
        }
    }

}