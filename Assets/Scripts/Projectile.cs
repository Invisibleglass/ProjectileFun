using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;
    public float gravity = 9.81f;

    private Vector3 bulletVelocity;

    private BoxCollider2D currentCollider;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 shootDirection = transform.right;
        shootDirection.Normalize();
        bulletVelocity = shootDirection * bulletSpeed/10;
    }

    // Update is called once per frame
    void Update()
    {
        bulletVelocity.y -= gravity * Time.deltaTime;
        transform.position += bulletVelocity * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            PlayerInput.instance.AddPoint();
            Destroy(gameObject);
            Destroy(other.gameObject);
            PlayerInput.instance.SpawnEnemy();
        }
    }
}
