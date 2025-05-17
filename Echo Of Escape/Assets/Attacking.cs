using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    /*public GameObject squarePrefab;
    private Transform firePoint;
    [SerializeField] private float attackCooldown = 1f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + fireCooldown;
        }
    }

    void Attack()
    {
        /*Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
    */
}
