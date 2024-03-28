using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Screen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI QuestionScreen;
    [SerializeField] private List<TextMeshProUGUI> Option = new List<TextMeshProUGUI>();
    public static string[,] QuestionL5 = new string[12,1]
    {
    {"I came ... America."},
    {"..... there anybody in the room?"},
    {"How many siblings .....?"},
    {"What ... you doing?"},
    {"Which book is .....?"},
    {"She is ... home."},
    {"She eats ... apple."},
    {"Why ... she come late?"},
    {"60 minutes is ... ."},
    {"This girl is ... beautiful than her."},
    {"He is interested... learning."},
    {"Where ... John and Marry yesterday?"},
    };
    public static string[,] AnswerL5 = new string[12,5]
    {
    {"at","in","from","on","C"},
    {"Are","am","is","if","C"},
    {"do you have","have you gotten","did you had","both (A, B) ","D"},
    {"is","are","am","if","B"},
    {"your","yours","your is","your’s","B"},
    {"at","in","on","from","A"},
    {"a","the","two","an","D"},
    {"does","are","is","do","A"},
    {"two hours","three hours","one hour","half an hour","C"},
    {"more","most","beautifully","very","A"},
    {"at","on","from","in","D"},
    {"had been","were","had","was","B"},
    };

    void Start()
    {
        
    }

    void Update()
    {
        QuestionScreen.text = QuestionL5[Interaction5.RanNumL5,0];
        Option[0].text = "A : " + AnswerL5[Interaction5.RanNumL5,0];
        Option[1].text = "B : " + AnswerL5[Interaction5.RanNumL5,1];
        Option[2].text = "C : " + AnswerL5[Interaction5.RanNumL5,2];
        Option[3].text = "D : " + AnswerL5[Interaction5.RanNumL5,3];
    }
}
