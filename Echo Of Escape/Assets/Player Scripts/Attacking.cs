using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject squarePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 1f;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 toMouse = mouseWorldPos - firePoint.position;
        float distanceToMouse = toMouse.magnitude;

        Vector2 direction = toMouse.normalized;

        // Sprawdzamy: jeœli kursor jest dalej ni¿ attackRange, ograniczamy zasiêg
        float spawnDistance = Mathf.Min(distanceToMouse, attackRange);
        Vector3 spawnPosition = firePoint.position + (Vector3)(direction * spawnDistance);


        GameObject square = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        square.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
