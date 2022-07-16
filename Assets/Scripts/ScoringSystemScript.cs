using UnityEngine;

public class ScoringSystemScript : MonoBehaviour
{
    public static bool isWin = true;

    public static int score = 0;

    void Update()
    {
        if(score < 0)
        {
            PlayerScript.playerLives--;
            score = 0;
        }
    }

    public void OnGUI(){
        GUI.Label(new Rect(10f, 30f, 100, 20), "Score : " + score);
    }
}
