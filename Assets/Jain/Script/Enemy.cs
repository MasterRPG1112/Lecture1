using UnityEngine;

namespace Jain
{
    public class Enemy : MonoBehaviour
    {
        public float speed;
        public GameObject Player;
        public GameObject objBullet;
        public Transform BulletPoint;
        public float delay = 0.5f;
        public float fireRate = 1.0f;

        public float hp = 1.0f;
        public float maxHp = 1.0f;

        void Start()
        {
            this.GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
            InvokeRepeating("fireBullet", delay, fireRate);
        }

        void Update()
        {
            
        }

        void fireBullet()
        {
            if (Player != null)
            {
                GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullet(Player.transform.position);
            }
        }
    }
}
