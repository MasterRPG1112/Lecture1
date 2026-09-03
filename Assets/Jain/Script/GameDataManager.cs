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

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(instance);
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

            isMusic = PlayerPrefs.GetInt("Music");
            isSound = PlayerPrefs.GetInt("Sound");

            Debug.Log(isMusic);
            Debug.Log(isSound);
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
            PlayerPrefs.SetInt("Music", isMusic);
            PlayerPrefs.SetInt("Sound", isSound);
        }

        void Start()
        {
            LoadDate();
        }

        void Update()
        {
            
        }
    }
}
