using UnityEngine;

namespace Jain
{
    public class GameDataManager : MonoBehaviour
    {
        public static GameDataManager instance;
        public int isMusic = 0;
        public int isSound = 0;
        public float gameTime = 0;
        public int gameScore;
        public string curld;

        //플레이어에 대한 정보
        public float maxHp = 10f;
        public int upgrade = 0;
        public int maxUpgrade = 3;
        public int bomb = 0;
        public int maxBomb = 3;
        public float score = 0;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(instance);
            LoadDate();
        }

        public void LoadDate()
        {
            if (!PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.SetInt("Music", 1);
            }
            if (!PlayerPrefs.HasKey("Sound"))
            {
                PlayerPrefs.SetInt("Sound", 1);
            }
            if (!PlayerPrefs.HasKey("saveData"))
            {
                string saveData = curld + "," + gameScore;
                PlayerPrefs.SetString("saveData", saveData);
            }

            string tempData = PlayerPrefs.GetString("saveData");
            string[] data = tempData.Split(',');

            curld = data[0];
            gameScore = int.Parse(data[1]);

            isMusic = PlayerPrefs.GetInt("Music");
            isSound = PlayerPrefs.GetInt("Sound");

            Debug.Log(isMusic);
            Debug.Log(isSound);
            Debug.Log(gameScore);
        }

        public void SaveData()
        {
            if (PlayerPrefs.HasKey("id"))
            {
                string id = PlayerPrefs.GetString("id");
                Debug.Log(id);
            }
            else
            {
                PlayerPrefs.SetString("id", "Jain");
                //PlayerPrefs.DeleteAll();
                //PlayerPrefs.DeleteKey("id");
            }

            string saveData = curld + "," + gameScore;
            PlayerPrefs.SetString("saveData", saveData);

            PlayerPrefs.SetInt("Music", isMusic);
            PlayerPrefs.SetInt("Sound", isSound);
        }

        void Start()
        {
            
        }

        void Update()
        {

        }
    }
}
