using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Jain
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuBG;
        public GameObject Setting;

        public GameObject SettingMusic;
        public GameObject SettingSound;

        void Start()
        {
            SetData();
        }

        void Update()
        {
            
        }

        public void BtnStart()
        {
            SceneManager.LoadScene("Main");
        }
        public void BtnSetting()
        {
            MenuBG.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenSetting", 1.5f);
        }
        public void BtnExit()
        {
            Application.Quit();
        }

        public void BtnBack()
        {
            Setting.GetComponent<Animator>().SetTrigger("Close");
            Invoke("OpenMenuBG", 1.5f);
        }

        public void OpenMenuBG()
        {
            MenuBG.GetComponent<Animator>().SetTrigger("Open");
        }

        void OpenSetting()
        {
            Setting.SetActive(true);
            Setting.GetComponent<Animator>().SetTrigger("Open");
        }

        public void BtnMusic()
        {
            if (SettingMusic.GetComponent<Text>().text == "Music on")
            {
                SettingMusic.GetComponent<Text>().text = "Music off";
                GameDataManager.instance.isMusic = 0;
            }
            else
            {
                SettingMusic.GetComponent<Text>().text = "Music on";
                GameDataManager.instance.isMusic = 1;
            }
            GameDataManager.instance.SaveData();
        }

        public void BtnSound()
        {
            if (SettingSound.GetComponent<Text>().text == "Sound on")
            {
                SettingSound.GetComponent<Text>().text = "Sound off";
                GameDataManager.instance.isSound = 0;
            }
            else
            {
                SettingSound.GetComponent<Text>().text = "Sound on";
                GameDataManager.instance.isSound = 1;
            }
            GameDataManager.instance.SaveData();
        }

        public void SetData()
        {
            if (GameDataManager.instance.isMusic == 1)
            {
                SettingMusic.GetComponent<Text>().text = "Music on";
            }
            else if (GameDataManager.instance.isMusic == 0)
            {
                SettingMusic.GetComponent<Text>().text = "Music off";
            }
            if (GameDataManager.instance.isSound == 1)
            {
                SettingSound.GetComponent<Text>().text = "Sound on";
            }
            else if (GameDataManager.instance.isSound == 0)
            {
                SettingSound.GetComponent<Text>().text = "Sound off";
            }
        }
    }
}
