using UnityEngine.UI;
using UnityEngine;

public class LiveBar : MonoBehaviour
{
    [SerializeField] private Image Bar;
    [SerializeField] private int BarCode;

    void Update()
    {
        if(BarCode == Interaction2.CountFalseAns)
        {
            Bar.GetComponent<Image>().color = new Color32(255,23,0,255);
        }
    }   
}
