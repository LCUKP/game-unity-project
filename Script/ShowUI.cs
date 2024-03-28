using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private GameObject GuideMenu;
    [SerializeField] private GameObject End;

    void Start()
    {
        End.SetActive(false);
        GuideMenu.SetActive(true);
    }

}
