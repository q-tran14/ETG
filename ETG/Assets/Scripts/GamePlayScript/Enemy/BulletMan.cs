using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy
{
    public class BulletMan : Enemy
    {

        public override void Die()
        {

        }

        public override void Fire()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
           
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Player")
            {

            }
        }
    }

}
