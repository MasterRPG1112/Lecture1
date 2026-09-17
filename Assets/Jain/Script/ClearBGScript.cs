using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Jain
{
    public class ClearBGScript : MonoBehaviour
    {
        public GameObject ClearBG;

        public void OpenUI()
        {
            ClearBG.SetActive(true);
        }

        void Start()
        {
        
        }

        void Update()
        {
        
        }

        public void BtnBack()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
