using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : PathFireBullet
{
    public int poolSize = 10;                   // Size of the object pool

    [Header("Shooting Settings")]
    public float timeBetweenShots = 0.1f; // Time between each shot
    public float timeBetweenWaves = 1f;  // Time between waves
    public float waveNum = 1;            // Number of wave bullets shoot
    public int bulletAmount = 5;
    public override IEnumerator FireProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            
            for (int i = 0; i < waveNum; i++)
            {
                for (int j = 0; j < bulletAmount; j++)
                {
                    Vector3 direction = (target.position - shootingPoint.position).normalized;
                    float angle = (90f / bulletAmount) * j - (90f / (bulletAmount - 1));
                    direction = Quaternion.Euler(0, 0, angle) * direction;

                    GameObject projectile = ObjectPool.SharedInstance.GetPooledObject(projectilePrefab);
                    if (projectile != null)
                    {
                        projectile.transform.position = shootingPoint.position;
                        projectile.transform.rotation = owner.transform.rotation; 
                        projectile.SetActive(true);
                        projectile.GetComponent<Bullet>().SetMoveDirection(direction);
                    }
                }

                yield return new WaitForSeconds(timeBetweenShots);
            }

        }
    }
}

