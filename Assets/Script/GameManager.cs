using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public GameObject gameOverUI;

    public TextMeshProUGUI recordText;

    public TextMeshProUGUI HpText;

    private float surviveTime;

    private bool isGameOver;

    public PlayerController playerController;

    private void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        HpText.text = $"HP: {playerController.HP}";
        if (!isGameOver)
        {       
            surviveTime += Time.deltaTime;
            timeText.text = $"TIME: {surviveTime:F1}";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
    
    public void EndGame()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestScore)
        {
            bestScore = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestScore);
        }
        
        recordText.text = $"Best Record: {bestScore:F1}";  
    }
}