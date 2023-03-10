using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private EnemiesManager enemiesManager;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float smoothMoveTime=.2f;
    [SerializeField] private float turnSpeed = 8f;

    private float rotateAngle;
    private float smoothInputMagnitude;
    private float smoothMoveVelocity;
    
    private Rigidbody rb;

    private Transform target;
    public Transform GetTarget => target;

    private Vector3 direction;
    private Vector3 velocity;

    public Vector3 GetDirection => direction;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0 ,Input.GetAxisRaw("Vertical")).normalized;

        float inputMagmitude = direction.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagmitude, ref smoothMoveVelocity, smoothMoveTime); 

        float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
        rotateAngle = Mathf.LerpAngle(rotateAngle, targetAngle, turnSpeed*Time.deltaTime*inputMagmitude); 

        velocity = transform.forward*moveSpeed*smoothInputMagnitude;
    }

    private void FixedUpdate() {    
        target = GetClosestEnemy(enemiesManager.GetEnemies);
        if(target!=null && direction==Vector3.zero){
            Vector3 _direction = (target.position - transform.position).normalized;
            float inputMagmitude = _direction.magnitude;
            smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagmitude, ref smoothMoveVelocity, smoothMoveTime); 
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z)*Mathf.Rad2Deg;
            rotateAngle = Mathf.LerpAngle(rotateAngle, targetAngle, turnSpeed*Time.deltaTime*inputMagmitude); 
            rb.MoveRotation(Quaternion.Euler(Vector3.up*rotateAngle));
            rb.MovePosition(rb.position);
        }
        else {
            rb.MoveRotation(Quaternion.Euler(Vector3.up*rotateAngle));
            rb.MovePosition(rb.position+velocity*Time.deltaTime);
        }
    }

    private Transform GetClosestEnemy(List<Enemy> _enemies){
        float targetDist = Mathf.Infinity;
        Transform currentTarget = null;
        for (int i = 0; i < _enemies.Count; i++) {
            float dist = Vector3.Distance(transform.position, _enemies[i].transform.position);
            if (dist<targetDist){
                targetDist = dist;
                currentTarget = _enemies[i].transform;
            }
        }

        return currentTarget;
    }
}
