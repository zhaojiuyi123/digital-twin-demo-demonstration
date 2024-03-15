using UnityEngine;

public class OrbitController : MonoBehaviour
{

    public float moveSpeed = 50f;    // ����ƶ��ٶ�

    private bool isDragging = false;    // �Ƿ�������ק���
    private Vector3 dragStartPosition;    // ��ק��ʼʱ�����λ��

    void Update()
    {
        // ͨ���������������ƶ�
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ���������ק���
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