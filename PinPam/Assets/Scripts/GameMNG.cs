using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMNG : MonoBehaviour
{
    [SerializeField] TMP_Text txt1;
    [SerializeField] TMP_Text txt2;

    [SerializeField] GameObject panel;

    float score1;
    float score2;

    Ball ball;

    private void Start()
    {
        score1 = 0f;
        score2 = 0f;
        ball = FindObjectOfType<Ball>();
    }

    public void UpdateScore(int TeamScored)
    {
        if (TeamScored == 1)
        {
            score1 += 1;
            txt1.SetText(score1.ToString());
        }
        else if (TeamScored == 2)
        {
            score2 += 1;
            txt2.SetText(score2.ToString());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ball.ResetWithCount();
            FindObjectOfType<AudioManager>().Play("Out");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            Pause();
        }
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

