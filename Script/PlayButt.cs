using UnityEngine;

public class PlayButt : MonoBehaviour
{
    [SerializeField] private GameObject GuideMenu;
    [SerializeField] private GameObject GUILevel2;
    
    void Start()
    {
        Time.timeScale = 0f;
        GUILevel2.SetActive(false);
    }

    public void PlayButtom()
    {
        Time.timeScale = 1f;
        GUILevel2.SetActive(true);
        GuideMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
