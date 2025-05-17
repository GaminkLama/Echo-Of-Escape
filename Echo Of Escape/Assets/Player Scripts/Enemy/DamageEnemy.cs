using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private int damagePerSecond = 1;
    [SerializeField] private float damageInterval = 1f;

    private bool isTouchingPlayer = false;
    private Coroutine damageCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
            damageCoroutine = StartCoroutine(DamageOverTime(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    }

    private IEnumerator DamageOverTime(Collider player)
    {
        while (isTouchingPlayer)
        {
            if (player.TryGetComponent<PlayerHealth>(out PlayerHealth health))
            {
                health.TakeDamage(damagePerSecond);
            }
            yield return new WaitForSeconds(damageInterval);
        }
    }
}