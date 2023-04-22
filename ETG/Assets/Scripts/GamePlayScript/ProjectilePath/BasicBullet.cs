using UnityEngine;
using System.Collections;

public class BasicBullet : PathFireBullet
{  
    [Header("Shooting Settings")]
    public float timeBetweenWaves = 2f; // Time between each wave
    public float timeBetweenShots = 1f; // Time between each shot
    public int bulletAmount = 3;

    public override IEnumerator FireProjectile()
    {
        while (true)
        {
            for (int k = 0; k < bulletAmount; k++)
            {
                yield return new WaitForSeconds(timeBetweenShots);

                Vector3 direction = (target.position - shootingPoint.transform.position).normalized;
                GameObject projectile = ObjectPool.SharedInstance.GetPooledObject(projectilePrefab);
                if (projectile != null)
                {
                    projectile.transform.position = shootingPoint.transform.position;
                    projectile.transform.rotation = owner.transform.rotation;
                    projectile.SetActive(true);
                    projectile.GetComponent<Bullet>().SetMoveDirection(direction);
                }
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}