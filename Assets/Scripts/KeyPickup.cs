using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.hasKey = true;
            Debug.Log("撿到鑰匙！");
            Destroy(gameObject); // 拿到後銷毀鑰匙物件
        }
    }
}
