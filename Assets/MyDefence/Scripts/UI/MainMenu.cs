using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField] private string loadToScene = "PlayScene";
        #endregion

        public void Play()
        {
            Debug.Log("Goto Play Scene");
            SceneManager.LoadScene(loadToScene);
        }

        public void Quit()
        {
            Debug.Log("Game Quit");
            Application.Quit();
        }
    }
}
