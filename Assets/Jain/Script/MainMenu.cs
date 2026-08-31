using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jain
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject MenuBG;
        public GameObject Setting;

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

        void OpenSetting()
        {
            Setting.SetActive(true);
            Setting.GetComponent<Animator>().SetTrigger("Open");
        }
    }
}
