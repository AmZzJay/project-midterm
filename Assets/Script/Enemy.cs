using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float speed = 3f;

    private int waypointIndex = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypointIndex >= Waypoints.points.Length)
        {
            ReachEnd();
            return;
        }

        Transform targetPoint = Waypoints.points[waypointIndex];

        Vector3 dir = targetPoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // เช็คว่าถึงจุดยัง
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            waypointIndex++;
        }
    }

    void ReachEnd()
    {
        Debug.Log("Enemy reached end!");
        Destroy(gameObject);
    }

    // ===== ระบบเลือด =====
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}