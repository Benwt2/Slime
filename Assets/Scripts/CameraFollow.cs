using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 角色的 Transform
    public float smoothSpeed = 0.125f;  // 跟隨平滑度
    public Vector3 offset;  // 相機與角色的偏移量

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // 保持相機的 z 值不變（2D 遊戲常用）
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}
