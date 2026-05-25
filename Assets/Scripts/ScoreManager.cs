using UnityEngine;


public class ScoreManager : MonoBehaviour
{

    private float _timer = 0f;

    private float _interval = 1f;


    private void Update()
    {
        _timer += Time.deltaTime;

        if ( _timer >= _interval )
        {
            SceneController.Score += 3;
            _timer = 0f;
            Debug.Log( "Очки: +" + SceneController.Score );
        }
    }

}
