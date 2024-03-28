using UnityEngine;
using UnityEngine.UI;

public class ImgBar : MonoBehaviour
{
    [SerializeField] private Image Bar;
    [SerializeField] private int BarCode;

    void Update()
    {
        if(BarCode == SpawnerCar.Round)
        {
            Bar.GetComponent<Image>().color = new Color32(157,231,104,255);
        }
        
    }
}
