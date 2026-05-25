using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneController
{

    public static int Score = 0;

    public static float Health = 100f;


    public static void LoadMainMenu()
    {
        SceneManager.LoadScene( "MenuScene" );
        Debug.Log( "Меню загружено" );
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene( "SampleScene" );
        Debug.Log( "Игра загружена" );
    }

}
