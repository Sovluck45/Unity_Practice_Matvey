using UnityEngine;


public class SoundManager : MonoBehaviour
{

    public AudioClip MusicClip;

    public AudioClip EffectClip;

    private AudioSource AudioSource;


    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        if ( MusicClip != null )
        {
            AudioSource.clip = MusicClip;
            AudioSource.Play();
            AudioSource.loop = true;
        }
    }

    public void PlayEffect()
    {
        if ( EffectClip != null )
        {
            AudioSource.PlayOneShot( EffectClip );
            Debug.Log( "Звук воспроизведён!" );
        }
    }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.T ) )
        {
            AudioSource.volume = Mathf.Clamp( AudioSource.volume + 0.1f, 0, 1 );
            Debug.Log( "Громкость: " + AudioSource.volume );
        }
    }

}
