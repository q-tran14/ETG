using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PathFireManager
{
    [SerializeField] private PathFireBullet pathFire;

    public void SetPathFire(PathFireBullet _pathFire)
    {
        pathFire = _pathFire;
    }

    public void Fire(Enemy.Enemy enemy)
    {
        enemy.StartCoroutine(pathFire.FireProjectile());
    }
}
