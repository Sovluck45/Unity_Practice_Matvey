using UnityEngine;

public class WinCondition : MonoBehaviour
{

    private void Update()
    {
        if ( SceneController.Score >= 100 )
        {
            FindObjectOfType<GameOverManager>().ShowGameOver( true );
        }
    }

}