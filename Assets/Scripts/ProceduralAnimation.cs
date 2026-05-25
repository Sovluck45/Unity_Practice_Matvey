using UnityEngine;


public class ProceduralAnimation : MonoBehaviour
{

    public float speed = 2f;

    void Update()
    {
        float x = Mathf.Sin( Time.time * speed ) * 2f;
        float z = Mathf.Cos( Time.time * speed ) * 2f;

        transform.position = new Vector3( x, 0, z );
    }

}
