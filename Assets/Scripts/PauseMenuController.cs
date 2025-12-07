using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject blurVolume; // 在 Inspector 拖入你的 BlurVolume

    public GameTimer gameTimer;  // 拖入 TimerManager

    void TogglePauseMenu(bool isOpen)
    {
        pauseMenuUI.SetActive(isOpen);
        gameTimer.SetPaused(isOpen); // 通知计时器暂停/继续
    }


    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        if (blurVolume) blurVolume.SetActive(false); // 关闭模糊
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        if (blurVolume) blurVolume.SetActive(true); // 开启模糊
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        if (blurVolume) blurVolume.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        if (blurVolume) blurVolume.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
