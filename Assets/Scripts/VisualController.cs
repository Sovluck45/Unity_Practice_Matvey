using UnityEngine;


public class VisualController : MonoBehaviour
{

    public ParticleSystem ParticleSystem;

    public SoundManager SoundManager;


    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            if ( ParticleSystem != null )
                ParticleSystem.Play();

            if ( SoundManager != null )
                SoundManager.PlayEffect();

            Debug.Log( "Ёффекты активированы!" );
        }
    }

}
