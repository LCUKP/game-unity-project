using TMPro;
using UnityEngine;

public class ButtAnswer : MonoBehaviour
{
    [SerializeField] private int NumButt;
    [SerializeField] private TextMeshProUGUI ButtonAnswer;
    public int CountAnswersL4 = 0;
    private int KeyCodeDown;
    private string currentSentence;
    private string targetSentence;
    private int [,] SentencesIndex = {
        {2, 4, 3, 1, 0},
        {0, 4, 2, 1, 3},
        {3, 2, 1, 4, 0},
        {4, 2, 0, 3, 1},
        {3, 1, 4, 0, 2},
        {2, 4, 1, 0, 3},
        {0, 1, 2, 3, 4},
        {3, 4, 0, 2, 1},
        {2, 0, 3, 4, 1},
        {4, 2, 0, 3, 1},
        {2, 0, 4, 3, 1},
        {1, 4, 3, 0, 2},
        {0, 1, 4, 3, 2},
        {1, 0, 2, 4, 3},
        {4, 2, 3, 1, 0},
    };

    void Update()
    {
        UpdateButtonAnswerText();        

        if (Input.anyKeyDown)
        {
            KeyCodeDown = GetKeyIndex();
            chackButt();
        }
        
        if(SpawnerCar.currenttimetospawn < 1)
        {
            ResetCounters();
            SpawnerCar.AnswerBool = 4;
        }

        if(CountAnswersL4 == 5){
            CountAnswersL4 = 0;
            SpawnerCar.CountNum = 0;
            SpawnerCar.currenttimetospawn = 2;
            SpawnerCar.AnswerBool = 3;
        }
    }

    private int GetKeyIndex()
    {
        if (Input.GetKeyDown(KeyCode.W)) return SentencesIndex[SpawnerCar.RanNum,1];
        if (Input.GetKeyDown(KeyCode.A)) return SentencesIndex[SpawnerCar.RanNum,0];
        if (Input.GetKeyDown(KeyCode.S)) return SentencesIndex[SpawnerCar.RanNum,2];
        if (Input.GetKeyDown(KeyCode.D)) return SentencesIndex[SpawnerCar.RanNum,4];
        if (Input.GetKeyDown(KeyCode.E)) return SentencesIndex[SpawnerCar.RanNum,3];

        return -1;
    }
    
    private void UpdateButtonAnswerText()
    {
        if (NumButt < 1 || NumButt > 5) return;

        int index = NumButt - 1;
        ButtonAnswer.text = WordCarFour.Sentences[SpawnerCar.RanNum, SentencesIndex[SpawnerCar.RanNum, index]];
    }

    void chackButt()
    {
        currentSentence = WordCarFour.Sentences[SpawnerCar.RanNum,SentencesIndex[SpawnerCar.RanNum,KeyCodeDown]];
        targetSentence = WordCarFour.Sentences[SpawnerCar.RanNum,SentencesIndex[SpawnerCar.RanNum,CountAnswersL4]];

        if(currentSentence == targetSentence)
        {
            SpawnerCar.AnswerBool = 1;
            Debug.Log(WordCarFour.Sentences[SpawnerCar.RanNum,SentencesIndex[SpawnerCar.RanNum,KeyCodeDown]]);
            Debug.Log(WordCarFour.Sentences[SpawnerCar.RanNum,SentencesIndex[SpawnerCar.RanNum,CountAnswersL4]]);
            CountAnswersL4 += 1 ;
            Debug.Log("CountAnswers : "+CountAnswersL4);
        }
        else
        {
            SpawnerCar.AnswerBool = 2;
            CountAnswersL4 += 1 ;
            Debug.Log("CountAnswers : "+CountAnswersL4);
        }
    }

    private void ResetCounters()
    {
        Debug.Log("BCountAnswers : " + CountAnswersL4);
        CountAnswersL4 = 0;
        SpawnerCar.CountNum = 0;
        SpawnerCar.currenttimetospawn = 1;
        Debug.Log("ACountAnswers : " + CountAnswersL4);
    }
}
