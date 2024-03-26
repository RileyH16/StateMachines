using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent ai;
    public Transform patrolPoint;
    EnemyState enemyState;
    private Animator anim;
    private float distanceToTarget;
    private Coroutine idleToPatrol;
    enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        enemyState = EnemyState.Idle;
        anim = GetComponent<Animator>();
        distanceToTarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));
        
    }

    // Update is called once per frame
    void Update()
    {
        ai.SetDestination(target.position);
    }

    IEnumerator SwitchToPatrol()
    {
        yield return new WaitForSeconds(5);
        enemyState = EnemyState.Patrol;
        idleToPatrol = null;
    }

    private void SwitchState(int newState)
    {
        if (anim.GetInteger("State") != newState)
            anim.SetInteger("State", newState);
    }
}
