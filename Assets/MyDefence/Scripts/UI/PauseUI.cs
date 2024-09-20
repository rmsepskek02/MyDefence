using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUI;
        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if(pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }        

        public void Retry()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            Time.timeScale = 1f;
            Debug.Log("Goto Menu");
        }

    }
}