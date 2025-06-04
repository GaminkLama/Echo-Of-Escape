using UnityEngine;

public class Runner : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stopDistance = 1.5f;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Gracz z tagiem 'Player' nie został znaleziony!");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, 1));
        }
    }
}
