using UnityEngine;

namespace PROJECT
{
    public class Utils : MonoBehaviour
    {
        public void SetComponentsActive<T>(Transform obj, bool active) where T : Component
        {
            // 禁用指定类型的组件
            SetComponentsActiveInChildren<T>(obj, active);
        }

        private void SetComponentsActiveInChildren<T>(Transform parent, bool active) where T : Component
        {
            // 获取父对象上的所有指定类型的组件，并禁用它们
            T[] components = parent.GetComponents<T>();
            foreach (T component in components)
            {
                component.gameObject.SetActive(active);
            }

            // 递归遍历所有子对象，并禁用它们的组件
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                SetComponentsActiveInChildren<T>(child, active);
            }
        }
    }
}
