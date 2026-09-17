using System;
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
            Player player = GameObject.Find("Player").GetComponent<Player>();
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (isPlayer)
            {
                if (other.CompareTag("Enemy"))
                {
                    Instantiate(Item, this.transform.position, Item.transform.rotation);
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                    player.Score += 10;
                    gameManager.ReloadUI();
                }
                else if (other.CompareTag("Boss"))
                {
                    Boss boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
                    Destroy(gameObject);
                    boss.Hp -= 1;

                    if (boss.Hp < 1)
                    {
                        player.Score += 300;
                        boss.Hp = 0;
                        Destroy(other.gameObject);
                        ClearBGScript clearBGScript = new ClearBGScript();
                        clearBGScript.OpenUI();
                    }
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(gameObject);
                    player.Hp -= 1;
                    gameManager.ReloadUI();

                    if (player.Hp < 1)
                    {
                        player.Hp = 0;
                        Destroy(other.gameObject);
                        gameManager.ReloadUI();
                    }
                }
            }
        }
    }
}
