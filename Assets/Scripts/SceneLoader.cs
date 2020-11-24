using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class SceneLoader : MonoBehaviour {
    public string gpgsLeaderboardCode = "CgkI39Df16sREAIQAA";


    private void Start()
    {
       
    }

    public void ShowLeaderboard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(gpgsLeaderboardCode);
    }

    public void ShowAchievments()
    {
        Social.ShowAchievementsUI();
    }
    public void Share()
    {
       Social.ReportScore(GameController.instance.highscore ,gpgsLeaderboardCode, (bool success) =>
        {
            if (success)
            {
                GameController.instance.shareScreenUI.SetActive(true);
            }
            else
            {
                GameController.instance.shareScreenUI.SetActive(false);
            }
        });
    }
    public void Quit()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Rate()
    {
        Application.OpenURL("market://details?id=com.WOLKY.RuggedTower");
    }

    public void OK()
    {
        GameController.instance.shareScreenUI.SetActive(false);
    }
}
