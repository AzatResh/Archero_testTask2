using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Player player;
    private NavMeshAgent enemyMeshAgent;

    private void Start() {
        enemyMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update() {
        enemyMeshAgent.destination = player.transform.position;
    }
}
