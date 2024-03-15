using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 获取玩家水平轴垂直轴输入
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, v);

        transform.Translate(dir * speed * Time.deltaTime);
    }
}