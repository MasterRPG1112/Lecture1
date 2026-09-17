using UnityEngine;

namespace Jain
{
    public class Boss : MonoBehaviour
    {
        GameManager gameManager;
        Player player;
        public GameObject objBullet;
        public Transform BulletPoint;

        public float bossMissileTime = 5;
        public float bossTempTime;

        public float Hp;

        void Awake()
        {
            GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
            if (gameManagerObject != null)
            {
                gameManager = gameManagerObject.GetComponent<GameManager>();
            }
            if (gameManager == null)
            {
                Debug.Log("게임 매니저가 존재하지 않습니다.");
            }
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("플레이어가 존재하지 않습니다.");
            }
        }

        void Update()
        {
            if (bossTempTime > bossMissileTime)
            {
                bossTempTime = 0;
                BossFireBullet(Random.Range(0, 2));
            }
            bossTempTime += Time.deltaTime;
        }

        void BossFireBullet(int num)
        {
            switch (num)
            {
                case 0:
                    {
                        GameObject bullet = Instantiate(objBullet, BulletPoint.transform.position, this.transform.rotation);
                        bullet.GetComponent<Bullet>().SetBullet(player.transform.position);
                    }
                    break;
                case 1:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.rotation);
                            bullet.GetComponent<Bullet>().SetBullet(player.transform.position + Vector3.forward + new Vector3(-1 + i, 0, 0));
                        }
                    }
                    break;

            }
        }
    }
}
