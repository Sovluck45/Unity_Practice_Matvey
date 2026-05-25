using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{

    public Transform Player;

    private NavMeshAgent _agent;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if ( Player != null )
        {
            _agent.SetDestination( Player.position );
        }
    }

}
