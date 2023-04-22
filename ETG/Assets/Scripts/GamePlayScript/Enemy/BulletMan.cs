using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class BulletMan : Enemy
    {
        [SerializeField] private bool isFire = false;
        [SerializeField] private bool isFiring = false;
        #region Special Attributes for fire path if it has
        //
        #endregion


        

        public override void Fire()
        {
            PathFireBullet path = new BasicBullet();                                                                        // create path fire bullet
            path.SetValue(target.transform, spawnBullet, projectilePrefab, projectileSpeed, typeBullet.ToString(), owner);  // set value
            // set special value
            fireManager.SetPathFire(path);
            if (isFire == true && isFiring == false)
            { 
                isFiring = true;
                fireManager.Fire(this); 
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                isFire = true;
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.tag == "Player" && isFire ==  true)
            {
                Fire();
                isFiring = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                isFire = false;
            }
        }
    }

}
