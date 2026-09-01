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
            if (SettingMusic.GetComponent<Text>().text == "¹è°æÀ½¾Ç")
            {
                SettingMusic.GetComponent<Text>().text = "¹è°æÀ½¾Ç ²û";
            }
            else
            {
                SettingMusic.GetComponent<Text>().text = "¹è°æÀ½¾Ç";
            }
        }

        public void BtnSound()
        {
            if (SettingSound.GetComponent<Text>().text == "È¿°úÀ½")
            {
                SettingSound.GetComponent<Text>().text = "È¿°úÀ½ ²û";
            }
            else
            {
                SettingSound.GetComponent<Text>().text = "È¿°úÀ½";
            }
        }
    }
}
