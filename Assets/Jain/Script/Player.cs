using UnityEngine;
using UnityEngine.Rendering;

namespace Jain
{
    public class Player : MonoBehaviour
    {
        public float bulletTime = 0.1f;
        public float reloadTime = 0f;
        Rigidbody thisRigi;
        public float speed = 2.0f;
        public GameObject objBullet;
        public Transform BulletPoint;

        void Start()
        {
            thisRigi = this.GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
            fireBullet();
        }

        void fireBullet()
        {
            reloadTime += Time.deltaTime;

            if (Input.GetButton("Fire1") && (bulletTime <= reloadTime))
            {
                reloadTime = 0f;
                GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                bullet.GetComponent<Bullet>().SetBullet(BulletPoint.position + Vector3.forward);
            }
        }
        
        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveX, 0.0f, moveZ);
            thisRigi.linearVelocity = move * speed;

            Vector3 poslnWorld = Camera.main.WorldToScreenPoint(this.transform.position);

            float posX = Mathf.Clamp(poslnWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(poslnWorld.y, 0, Screen.height);

            Vector3 poslnScreen = Camera.main.ScreenToWorldPoint(new Vector3(posX, posZ, 0));

            thisRigi.position = new Vector3(poslnScreen.x, 0, poslnScreen.z);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}