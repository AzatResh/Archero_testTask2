using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private BulletProjectile bullet;

    [SerializeField] private float fireRate = 2;
    private float currentShootTime;

    private PlayerMovement playerMovement;
    private Transform target;
    
    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.GetDirection!=Vector3.zero || playerMovement.GetTarget==null) {
            currentShootTime = 0;
            return;
        }

        if(currentShootTime < 1/fireRate){
            currentShootTime+=Time.deltaTime;
            return;
        }

        currentShootTime = 0;
        Instantiate(bullet, shootPoint.position, transform.rotation);
    }
}
