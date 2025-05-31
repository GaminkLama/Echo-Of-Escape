using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float attackCooldown = 0.5f; // czas miêdzy strza³ami

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            ShootTowardsMouse();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void ShootTowardsMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
}
