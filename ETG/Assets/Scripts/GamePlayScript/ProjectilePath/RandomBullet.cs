using UnityEngine;
using System.Collections;

public class RandomBullet : PathFireBullet
{
    [Header("Shooting Settings")]
    public float timeBetweenWaves = 5f; // Time between each wave
    public float timeBetweenShots = 0.01f; // Time between each shot
    public int bulletAmount = 100;
    public float bulletSpread = 200f;

    //public override void RandomBulletPath(float timeBetweenWaves, float timeBetweenShots, int bulletAmount, float bulletSpread)
    //{
    //    this.timeBetweenWaves = timeBetweenWaves;
    //    this.timeBetweenShots = timeBetweenShots;
    //    this.bulletAmount = bulletAmount;
    //    this.bulletSpread = bulletSpread;
    //}

    public override IEnumerator FireProjectile()
    {
        while (true)
        {
            for (int k = 0; k < bulletAmount; k++)
            {
                yield return new WaitForSeconds(timeBetweenShots);

                Vector3 direction = (target.position - shootingPoint.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                float spread = Random.Range(-bulletSpread, bulletSpread);
                angle += spread;

                direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
                GameObject projectile = ObjectPool.SharedInstance.GetPooledObject(projectilePrefab);
                if (projectile != null)
                {
                    projectile.transform.position = shootingPoint.transform.position;
                    projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
                    projectile.SetActive(true);
                    projectile.GetComponent<Bullet>().SetMoveDirection((target.position - shootingPoint.transform.position).normalized); // modified this line
                }
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}