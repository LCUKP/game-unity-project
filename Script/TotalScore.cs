using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public static float TotalScore_ = 0;

    public static void TotalFunc(float TotalScore, TextMeshProUGUI _TotalScore)
    {
        TotalScore_ += TotalScore;
        _TotalScore.text = TotalScore_.ToString();
    }
}
