using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ScoreManagerGUI : MonoBehaviour
{
    public TMP_Text guiCurScore;
    public TMP_Text guiHighScore;
    public GameObject player;
    private PlayerController pcScript;
    private HighscoreManager hsmScript;
    private void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        hsmScript = GetComponent<HighscoreManager>();
        pcScript.setPlayerHighScore(hsmScript.readHighscore());
        setGUIHighscore();
    }
    public void setGUICurScore()
    {
        guiCurScore.text = "Score: " + pcScript.getPlayerScore().ToString();
        if(isHighscore())
        {
            setGUIHighscore();
            hsmScript.writeHighscore();
        }

    }

    public void setGUIHighscore()
    {
        guiHighScore.text = "Highscore: " + pcScript.getPlayerHighScore().ToString();
    }

    public bool isHighscore()
    {
        if(pcScript.getPlayerHighScore() < pcScript.getPlayerScore())
        {
            //change the highscore that is connected to the playerController
            pcScript.setPlayerHighScore(pcScript.getPlayerScore());
            //we have a new high score so return true
            return true;
        }
        else
        {
            return false;
        }
    }
}
