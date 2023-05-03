using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]
public class PathFireManager
{
    [SerializeField]private PathFireBullet pathFire;
    
    //public enum pathFireBulletName
    //{
    //    BasicBullet,
    //}
    //[Header("Choose path fire bullets")]
    //public pathFireBulletName choose;
    //[Header("Attributes user for fire")]
    //#region attribute use for fire
    //[Tooltip("Auto set target")]
    //[SerializeField] public GameObject target; 
    //[Tooltip("Spawn bullet position in enemy")]
    //public Transform spawnBullet; // previous name : shootingPoint
    //public GameObject projectilePrefab;
    //public float projectileSpeed;
    //public enum TypeBullet
    //{
    //    CircleType,
    //    None
    //}
    //public TypeBullet typeBullet;
    //public GameObject owner;
    //#endregion
   


    //private void FixedUpdate()
    //{
    //    if(target != null)
    //    {
    //        pathFire.SetValue(target.transform, spawnBullet, projectilePrefab, projectileSpeed, typeBullet.ToString(), owner);
    //    }
    //    else
    //    {
    //        pathFire.SetValue(null, spawnBullet, projectilePrefab, projectileSpeed, typeBullet.ToString(), owner);
    //    }
    //}
    public void SetFirePath(PathFireBullet p)
    {
        pathFire = p;
    }
    public void Fire(Enemy.Enemy e)
    {
        e.StartCoroutine(pathFire.FireProjectile());
    }

}
