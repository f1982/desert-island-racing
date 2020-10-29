using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayingScene : MonoBehaviour
{
    public int totalScore = 19;
    public int currentScore = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onRewardCollect += OnRewardCollect;
        GameEvents.current.onTimeoutTrigger += OnTimeoutTrigger;
        scoreText.text = currentScore + "/" + totalScore;
    }

    private void OnRewardCollect(int score)
    {
        currentScore += score;
        scoreText.text = currentScore+"/"+totalScore;
        Debug.Log("OnRewardCollect currentScore :" + currentScore);
        if (currentScore >= totalScore)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTimeoutTrigger()
    {
        SceneManager.LoadScene(3);
    }

    private void OnDestroy()
    {
        GameEvents.current.onRewardCollect -= OnRewardCollect;
        GameEvents.current.onTimeoutTrigger -= OnTimeoutTrigger;
    }
}
