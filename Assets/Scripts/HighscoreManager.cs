using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public GameObject player;
    PlayerController pcScript;

    ScoreManagerGUI scoreManagerScript;

    private void Start()
    {
        //I have to have referene to the player to do this
        //because this script is not attached to the same object
        //as the player
        pcScript = player.GetComponent<PlayerController>();
        //I can do this becuase this script is attached to the 
        //same object as the ScoreManagerGUI script
        scoreManagerScript = GetComponent<ScoreManagerGUI>();
    }
    public void writeHighscore()
    {
        Debug.Log("Writting highscore");
        //we can write simple things to a standard text file by using the PlayerPrefs
        PlayerPrefs.SetInt("Highscore1", pcScript.getPlayerHighScore());
    }

    public int readHighscore()
    {
        Debug.Log("HIGH READ");
        int highscoreFromFile = PlayerPrefs.GetInt("Highscore1", 0);
        Debug.Log("HIGH FROM HM: " + highscoreFromFile);
        return highscoreFromFile;
    }
}
