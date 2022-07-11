using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystemScript : MonoBehaviour
{
    private const int WINNING_SCORE = 200;

    public GameObject scoreText;
    public static int score = 0;


    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score: " + score;
        if (score >= WINNING_SCORE)
        {
            //SceneManager.LoadScene(2);
        }
    }
}
