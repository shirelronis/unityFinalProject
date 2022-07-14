using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystemScript : MonoBehaviour
{
    private const int WINNING_SCORE = 200;
    public static bool isWin = true;

    public static int score = 0;

    void Update()
    {
        if (score >= WINNING_SCORE)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void OnGUI(){
        GUI.Label(new Rect(10f, 30f, 100, 20), "Score : " + score);
    }
}
