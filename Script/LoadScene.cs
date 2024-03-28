using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Lobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void AIIYL()
    {
        SceneManager.LoadScene("AIIYL");
    }
    public void OneforTheRoad()
    {
        SceneManager.LoadScene("OneforTheRoad");
    }
    public void Really()
    {
        SceneManager.LoadScene("Really");
    }
    public void AllTooWell()
    {
        SceneManager.LoadScene("AllTooWell");
    }
    public void KickIt()
    {
        SceneManager.LoadScene("KickIt");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
