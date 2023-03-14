using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;

    private NavMeshAgent enemyMeshAgent;
    private Rigidbody rb;

    private bool canMove = true;

    private float rotateAngle;
    private float smoothInputMagnitude;
    private float smoothMoveVelocity;
    private float smoothMoveTime=.2f;
    private float turnSpeed = 8f;

    private void Start() {
        enemyMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    public void SetTarget(Transform _target){
        target = _target;
    }

    public void Stop(){
        if(canMove) {
            canMove = false;
            enemyMeshAgent.enabled = false;
         }   
    }
    public void ContinueMove(){
        if(!canMove) {
            canMove = true;
            enemyMeshAgent.enabled = true;
            }
    }

    private void Update() {
        if(target!=null){
            if(canMove) Move();
            else LookToToTarget();
        }    
    }

    private void Move(){
        enemyMeshAgent.destination = target.position;
    }

    private void LookToToTarget(){
        Vector3 _direction = (target.position - transform.position).normalized;
        float inputMagmitude = _direction.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagmitude, ref smoothMoveVelocity, smoothMoveTime); 
        float targetAngle = Mathf.Atan2(_direction.x, _direction.z)*Mathf.Rad2Deg;
        rotateAngle = Mathf.LerpAngle(rotateAngle, targetAngle, turnSpeed*Time.deltaTime*inputMagmitude);
        rb.MoveRotation(Quaternion.Euler(Vector3.up*rotateAngle));
    }
}
