using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void OnMenuButtonClick()
    {
        bool isActive = pauseCanvas.activeSelf;
        pauseCanvas.SetActive(!isActive); 
        Time.timeScale = isActive ? 1f : 0f;
    }
}
