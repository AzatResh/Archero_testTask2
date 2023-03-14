using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2;
    [SerializeField] private int damage = 2;
    [SerializeField] private ParticleSystem particle;
    
    private Rigidbody rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = (transform.forward*bulletSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        Enemy _enemy;
        if(other.TryGetComponent<Enemy>(out _enemy)){
            _enemy.TakeDamage(damage);
            ObstacleTrigger();
        }

        if(other.tag == "Wall"){
            ObstacleTrigger();
        }
    }

    private void ObstacleTrigger(){
        ParticleSystem new_particle = Instantiate(particle, transform.position, Quaternion.identity);
        new_particle.Play();
        Destroy(gameObject);
    }
}
