using UnityEngine;
using UnityEngine.Rendering;

namespace Jain
{
    public class Bullet : MonoBehaviour
    {
        [UnityEngine.SerializeField]
        private Vector3 destination;
        public float speed = 1.0f;
        public bool isPlayer = true;

        public GameObject Item;

        public Vector3 dir;

        void Start()
        {
        
        }

        void Update()
        {
            // 방향계산에 따른 조준탄
            this.transform.position += dir.normalized * Time.deltaTime * speed;
        }

        public void SetBullet(Vector3 _destination)
        {
            destination = _destination;
            dir = destination - this.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isPlayer)
            {
                if (other.CompareTag("Enemy"))
                {
                    Instantiate(Item, this.transform.position, Item.transform.rotation);

                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
