using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Roam : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void Run()
    {
        CinemachineDollyCart dollyCart = GetComponent<CinemachineDollyCart>();
        // ����С����λ��
        dollyCart.m_Position = 0;
        dollyCart.gameObject.SetActive(true);
    }

}
