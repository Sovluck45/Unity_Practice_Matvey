using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

    public void OnStartButton()
    {
        SceneController.Score = 0;
        SceneController.Health = 100f;

        SceneManager.LoadScene( "SampleScene" );
        Debug.Log( "Игра началась!" );
    }

}
