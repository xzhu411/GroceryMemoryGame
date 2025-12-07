using System.Collections;
using UnityEngine;
using TMPro;

public class GameStartManager : MonoBehaviour
{
    public GameObject startPanel;     // UI Panel
    public TMP_Text startText;        // Text
    public GameTimer gameTimer;       

    public float countdownTime = 10f;

    [System.Serializable]
    public class FoodItem
    {
        public string name;
        public int count;
    }
    public FoodItem[] itemsToRemember;

    void Start()
    {
        // pause the game timer at start
        if (gameTimer != null)
            gameTimer.SetPaused(true);

        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        // build food list text
        string foodList = "Memorize the items:\n";
        foreach (var item in itemsToRemember)
        {
            foodList += $"{item.name} x {item.count}\n";
        }
        foodList += "\n";

        startPanel.SetActive(true);

        float timer = countdownTime;
        while (timer > 0)
        {
            startText.text = foodList + $"Starting in {Mathf.Ceil(timer)}...";
            timer -= Time.deltaTime;
            yield return null;
        }

        // hide panel
        startPanel.SetActive(false);

        Debug.Log("Game start!");

        // 10 second delay before starting the timer
        if (gameTimer != null)
            gameTimer.SetPaused(false);
    }
}
