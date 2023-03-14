using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] EnemyBulletProjectile bullet;

    [SerializeField] private float fireRate = 2;
    [SerializeField] private float distanceCanShoot = 5;
    private float currentShootTime;
    
    private Transform player;
    private EnemyMovement movement;

    private void Start() {
        movement = gameObject.GetComponent<EnemyMovement>();
    }

    public void SetPlayer(Transform _player){
        player = _player;
    }

    private void Update() {
        Shoot();
    }
    
    private void Shoot(){   
        if(player==null) return;
        if(Vector3.Distance(transform.position, player.position)>distanceCanShoot){
            movement.ContinueMove();
            currentShootTime = 0;
            return;
        }
        else{
            movement.Stop();
            Vector3 direction = (player.position - transform.position).normalized;
            if(currentShootTime < 1/fireRate){
                currentShootTime+=Time.deltaTime;
                return;
            }

            currentShootTime = 0;
            Instantiate(bullet, shootPoint.position, transform.rotation);
        }
    }
}
