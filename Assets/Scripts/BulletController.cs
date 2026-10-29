using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float bulletLifeTime = 1f;

    private void OnEnable()
    {
        Invoke(nameof(DeactivateBullet), bulletLifeTime);
    }

    private void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        DeactivateBullet();

        
    }
}
