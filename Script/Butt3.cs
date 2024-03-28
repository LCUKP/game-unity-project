using UnityEngine;

public class Butt3 : MonoBehaviour
{
    [SerializeField] private GameObject GuideMenu;
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void PlayButtom()
    {
        Time.timeScale = 1f;
        GuideMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
