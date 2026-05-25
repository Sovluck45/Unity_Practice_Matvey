using UnityEngine;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{

    public GameObject GameOverPanel;

    public Text ResultText;

    public Text ScoreText;


    public void ShowGameOver( bool isWin )
    {
        GameOverPanel.SetActive( true );

        if ( isWin )
        {
            ResultText.text = "ÏÎÁÅÄÀ!";
            ResultText.color = Color.green;
        }
        else
        {
            ResultText.text = "ÂÛ ÏĞÎÈÃĞÀËÈ";
            ResultText.color = Color.red;
        }

        ScoreText.text = "Âàø ñ÷¸ò: " + SceneController.Score;
        Debug.Log( "Èãğà îêîí÷åíà. Ñ÷¸ò: " + SceneController.Score );
    }

    public void ToMainMenu()
    {
        SceneController.LoadMainMenu();
    }

}
