using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TextMeshProUGUI scoreText;
    public GameObject bestTextUI;
    public TextMeshProUGUI scoreTextUI;
    public TextMeshProUGUI highScoreText;
    public Image tutorial;
    public GameObject sureUI;

    public Animator gameOverAnim;
    public Animator playerAnim;
    public FreeParallax parallax;
    public GameObject gameOverUI;
    public GameObject gameUI;
    public GameObject shareScreenUI;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highscore;
    private int targetScore = 25;

    private float[] speed = { .8f, -.8f };
    [Header("Controls")]
    public Slider slider;
    [HideInInspector]
    public bool gameOver;
    public bool gameStart;


    float timerr;
    public float CountInterval = 0.05f, timer = 0;
    int i = 0;

    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        sureUI.SetActive(false);
        gameUI.SetActive(true);
        shareScreenUI.SetActive(false);
        gameOver = false;
        score = 0;
        gameOverUI.SetActive(false);
        highscore = PlayerPrefs.GetInt("highscore");
        bestTextUI.SetActive(false);
        StartCoroutine(FadeImage(true));
    }

    // Update is called once per frame
    void Update()
    {
        BlocksMove.speed = speed[0];
        parallax.Speed = speed[1];
        if (gameOver)
        {
            timerr += Time.deltaTime;

            for (int i = 0; i < speed.Length; i++)
            {
                speed[i] = 0;
            }
            playerAnim.Rebind();
            gameStart = false;
            StartCoroutine("DisplayScore");
            gameUI.SetActive(false);
            if (timerr >= 1f)
            {
                gameOverUI.SetActive(true);
                gameOverAnim.Play("GameOver");
                timerr = 0;
            }
        }

        scoreText.text = score.ToString();
        if (score >= targetScore)
        {
            if (speed[0] <= 3)
            {
                speed[0] += .1f;
                speed[1] -= .1f;
                ObstaclePool.spawnRate -= .05f;
                targetScore += 25;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            sureUI.SetActive(true);
        }
            

        switch (score)
        {
            case 100:
                {
                    Social.ReportProgress("CgkI39Df16sREAIQAQ", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
                    break;
                }

            case 250:
                {
                    Social.ReportProgress("CgkI39Df16sREAIQAg", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
                    break;
                }

            case 500:
                {
                    Social.ReportProgress("CgkI39Df16sREAIQAw", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
                    break;
                }

            case 1000:
                {
                    Social.ReportProgress("CgkI39Df16sREAIQBA", 100.0f, (bool success) =>
                    {
                        // handle success or failure
                    });
                    break;
                }
        }
    }


    public void Score()
    {
        score++;
        SoundManagerScript.scoredAudioSource.Play();
    }
    IEnumerator DisplayScore()
    {
        yield return new WaitForSeconds(2.2f);

        timer += Time.deltaTime;
        if (i < score && timer >= CountInterval)
        {
            i++;
            SoundManagerScript.coinAudioSource.Play();
            scoreTextUI.text = "SCORE: " + i.ToString();
            timer = 0;
        }
        else
        {
            if (score > highscore)
            {
                bestTextUI.SetActive(true);
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
            }
            highScoreText.text = "HIGH SCORE: " + highscore.ToString();
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        yield return new WaitForSeconds(2);
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                tutorial.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                tutorial.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        yield return new WaitForSeconds(4);
        Destroy(tutorial.gameObject);
    }

    public void No()
    {
        Time.timeScale = 1;
        sureUI.SetActive(false);
    }
}
