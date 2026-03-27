using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Stats")]
    public float range = 5f;
    public int damage = 1;      // เริ่มต้น 1
    public float fireRate = 1f; // ยิง 1 ครั้ง/วินาที

    [Header("FX")]
    public GameObject hitEffect; // ลาก FX มาใส่

    private Enemy target;
    private float fireCooldown = 0f;

    void Start()
    {
        // ใช้ Collider เป็นระยะตรวจจับ
        GetComponent<SphereCollider>().radius = range;
    }

    void Update()
    {
        if (target == null || target.gameObject == null)
            return;

        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (target == null) return;

        // 💥 ทำดาเมจ
        target.TakeDamage(damage);

        // 🔥 สร้าง FX ตอนโดน
        if (hitEffect != null)
        {
            GameObject fx = Instantiate(
                hitEffect,
                target.transform.position,
                Quaternion.identity
            );

            Destroy(fx, 1f); // ให้ FX หายเอง
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            target = enemy;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null && enemy == target)
        {
            target = null;
        }
    }
}