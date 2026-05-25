using UnityEngine;


public class EnemyCollision : MonoBehaviour
{

    private void OnTriggerEnter( Collider other )
    {
        if ( other.CompareTag( "Player" ) )
        {
            SceneController.Health -= 10f;
            Debug.Log( "Враг ударил! Здоровье: " + SceneController.Health );

            if ( SceneController.Health <= 0 )
            {
                FindObjectOfType<GameOverManager>().ShowGameOver( false );
            }
        }
    }

}
