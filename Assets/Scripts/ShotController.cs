using UnityEngine;

public class ShotController : MonoBehaviour
{
    [Header("Ammo Settings")]
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int currentAmmo = 10;
    [SerializeField] private bool infiniteAmmo = false;

    [Header("Bullet Settings")]
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private int bulletDamage = 10;

    private ObjectPool bulletPool;
    private Transform bulletSpawnAnchor;

    private float lastShotTime = 0f;

    private void Start()
    {
        bulletPool = GetComponent<ObjectPool>();
        bulletSpawnAnchor = transform.Find("ShootPoint");
    }

    /// <summary>
    /// Checks if the player can shoot based on ammo count and fire rate
    /// </summary>
    /// <returns>Whether the player can shoot</returns>
    public bool CanShoot ()
    {
        return (Time.time - lastShotTime >= fireRate) && (infiniteAmmo || currentAmmo > 0);
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            //Debug.Log("Shooting...");
            lastShotTime = Time.time;

            if (!infiniteAmmo) currentAmmo--;
            
            GameObject bullet = bulletPool.GetObjectFromPool();
            bullet.transform.position = bulletSpawnAnchor.position;
            bullet.transform.rotation = bulletSpawnAnchor.rotation;

            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.linearVelocity = bulletSpawnAnchor.up * bulletSpeed;
        }
    }
}
