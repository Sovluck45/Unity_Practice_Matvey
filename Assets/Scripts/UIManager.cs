using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public Slider HealthBar;

    public Text ScoreText;


    private void Update()
    {
        if ( HealthBar != null )
            HealthBar.value = SceneController.Health;

        if ( ScoreText != null )
            ScoreText.text = "Ñ÷¸ò: " + SceneController.Score;
    }

}
