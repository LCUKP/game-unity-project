using UnityEngine;

public class GodMode : MonoBehaviour
{
    public static bool NavisCalling;
    [SerializeField] private GameObject GodModeUI;
    
    void Start()
    {
        NavisCalling = false;
        GodModeUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(NavisCalling);
            if(NavisCalling)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }
    
    void Resume()
    {
        GodModeUI.SetActive(false);
        NavisCalling = false;
    
    }

    void Pause()
    {
        GodModeUI.SetActive(true);
        NavisCalling = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
