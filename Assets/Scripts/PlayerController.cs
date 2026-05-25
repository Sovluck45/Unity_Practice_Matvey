using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float Speed = 5f;

    public int Health = 100;

    private Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            SceneController.Health = Mathf.Max( 0, SceneController.Health - 10 );
            Debug.Log( "Çהמנמגüו: " + SceneController.Health );
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis( "Horizontal" );
        float moveZ = Input.GetAxis( "Vertical" );

        Vector3 movement = new Vector3( moveX, 0, moveZ );

        _rb.MovePosition( transform.position + movement * Speed * Time.fixedDeltaTime );
    }

}
