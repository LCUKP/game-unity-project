using UnityEngine.SceneManagement;
using UnityEngine;

public class Resume : MonoBehaviour
{
    // [SerializeField] private GameObject EndGame;
    public void OnclickResumeFunction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // EndGame.SetActive(false);
    }
}
