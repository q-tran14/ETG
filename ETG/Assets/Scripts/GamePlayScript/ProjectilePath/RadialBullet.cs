using UnityEngine;
using System.Collections;

public class RadialBullet : PathFireBullet
{
    [Header("Shooting Settings")]
    public float timeBetweenShots = 0.1f; // Time between each shot
    public float timeBetweenWaves = 1f;         // Time between waves
    public float waveNum = 1;            // number of wave bullets shoot
    public int bulletAmount = 5;           // Number of bullets per wave
    public float startAngle = 90f, engAngle = 270f;

    //public override void RadialBulletPath(float timeBetweenWaves, float waveNum, float timeBetweenShots, int bulletAmount, float startAngle, float engAngle)
    //{
    //    this.timeBetweenWaves = timeBetweenWaves;
    //    this.waveNum = waveNum;
    //    this.timeBetweenShots = timeBetweenShots;
    //    this.bulletAmount = bulletAmount;
    //    this.startAngle = startAngle;
    //    this.engAngle = engAngle;
    //}

    public override IEnumerator FireProjectile()
    {
        float angleStep = (engAngle - startAngle) / bulletAmount;
        float angle = startAngle;
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int k = 0; k < waveNum; k++) // Fire waves
            {
                for (int i = 0; i < bulletAmount; i++) // Spawn bullets in a wave
                {
                    float bulDirx = owner.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                    float bulbiry = owner.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirx, bulbiry, 0f);
                    Vector2 bulDir = (bulMoveVector - owner.transform.position) .normalized;

                    GameObject projectile = ObjectPool.SharedInstance.GetPooledObject(projectilePrefab);
                    if (projectile != null)
                    {
                        projectile.transform.position = shootingPoint.position;
                        projectile.transform.rotation = owner.transform.rotation; 
                        projectile.SetActive(true);
                        projectile.GetComponent<Bullet>().SetMoveDirection(bulDir);
                    }
                    angle += angleStep;
                }
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }
    }
}