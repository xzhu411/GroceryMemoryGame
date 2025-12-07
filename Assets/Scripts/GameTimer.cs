using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // 
    public GameObject pauseMenu;       // 

    private float elapsedTime = 0f;
    private bool isPaused = false;

    void Update()
    {
        
        if (!isPaused)
            elapsedTime += Time.deltaTime;

        // 更新文本（格式 MM:SS）
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";

        timerText.gameObject.SetActive(pauseMenu.activeSelf);
    }

    public void SetPaused(bool value)
    {
        isPaused = value;
    }
}
