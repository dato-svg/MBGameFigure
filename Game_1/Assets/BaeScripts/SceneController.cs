using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaeScripts
{
    public class SceneController : MonoBehaviour
    {
        public void RestartGame() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
