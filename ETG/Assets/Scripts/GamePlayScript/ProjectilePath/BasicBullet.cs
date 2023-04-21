using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour, PathFireBullet
{
    [Header("Bullet position Settings")]
    public Transform target;
    public Transform shootingPoint;
    public Transform enemyTransform; //
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;         // Prefab to spawn

    [Header("Shooting Settings")]
    public float timeBetweenWaves = 2f; // Time between each wave
    public float timeBetweenShots = 1f; // Time between each shot
    public int bulletAmount = 3;

    private void Start()
    {
        StartCoroutine(FireProjectile());
    }

     public  IEnumerator FireProjectile()
    {
        while (true)
        {
            for (int k = 0; k < bulletAmount; k++)
            {
                yield return new WaitForSeconds(timeBetweenShots);

                Vector3 direction = (target.position - shootingPoint.position).normalized; //
                GameObject projectile = ObjectPool.SharedInstance.GetPooledObject(projectilePrefab);
                if (projectile != null)
                {
                    projectile.transform.position = shootingPoint.transform.position;
                    projectile.transform.rotation = transform.rotation; //
                    projectile.SetActive(true);
                    projectile.GetComponent<Bullet>().SetMoveDirection(direction);
                }
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}