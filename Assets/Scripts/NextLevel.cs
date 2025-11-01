using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private float delay = 0.5f;
    private bool isLoading = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLoading) return;
        if (other.CompareTag("Player"))
        {
            if (PlayerInventory.hasKey) // ✅ 直接使用靜態資料
            {
                Debug.Log("有鑰匙，開門！");
                isLoading = true;
                Invoke(nameof(LoadNextScene), delay);
            }
            else
            {
                Debug.Log("門鎖住了，還沒拿到鑰匙！");
            }
        }
    }

    private void LoadNextScene()
    {
        PlayerInventory.hasKey = false; // ✅ 進入新關後清空鑰匙
        if (!string.IsNullOrEmpty(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}