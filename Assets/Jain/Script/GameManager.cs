using Codice.Client.Common;
using NUnit.Framework;
using PlasticGui.WorkspaceWindow.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jain
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] Enemys;
        public Vector3 spawnValue;
        public int enemyCount;

        public float spawnWait;
        public float startWait;

        public Text HP;
        public Text Upgrade;
        public Text Bomb;
        public Text Score;

        public List<GameObject> listEnemys = new List<GameObject>();

        public enum GameStatus
        {
            none,
            play,
            gameOver,
            gameClear
        }

        public GameStatus gameStatus = GameStatus.none;

        void Start()
        {
            gameStatus = GameStatus.play;
            StartCoroutine(SpawnEnemy());

            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.Hp = GameDataManager.instance.maxHp;
            player.Upgrade = GameDataManager.instance.upgrade;
            player.Bomb = GameDataManager.instance.bomb;
            player.Score = GameDataManager.instance.score;

            ReloadUI();
        }
        
        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(spawnWait);
            while (true)
            {
                for(int i = 0; i < enemyCount; i++)
                {
                    GameObject enemy = Enemys[Random.Range(0, Enemys.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    listEnemys.Add(Instantiate(enemy, spawnPosition, enemy.transform.rotation));
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }

        void Update()
        {
            
        }

        public void ReloadUI()
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            HP.text = "HP: " + player.Hp;
            Upgrade.text = "Upgrade: " + player.Upgrade;
            Bomb.text = "Bomb: " + player.Bomb;
            Score.text = "Score: " + player.Score;
        }
    }
}
