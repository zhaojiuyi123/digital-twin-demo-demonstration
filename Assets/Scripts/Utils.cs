using UnityEngine;

namespace PROJECT
{
    public class Utils : MonoBehaviour
    {
        public void SetComponentsActive<T>(Transform obj, bool active) where T : Component
        {
            // ����ָ�����͵����
            SetComponentsActiveInChildren<T>(obj, active);
        }

        private void SetComponentsActiveInChildren<T>(Transform parent, bool active) where T : Component
        {
            // ��ȡ�������ϵ�����ָ�����͵����������������
            T[] components = parent.GetComponents<T>();
            foreach (T component in components)
            {
                component.gameObject.SetActive(active);
            }

            // �ݹ���������Ӷ��󣬲��������ǵ����
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                SetComponentsActiveInChildren<T>(child, active);
            }
        }
    }
}
