using UnityEngine;
using TMPro;

public class WordCarFour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextUpperCar;
    [SerializeField] private int NumCar;

    public static string [,] Sentences = {
        {"I", "will", "wait", "for", "you."},
        {"I", "have", "a", "great", "mother"},
        {"Will", "you", "go", "with", "me?"},
        {"We", "ate", "a", "hot", "soup."},
        {"I", "see", "you", "smile", "again!"},
        {"He", "is", "an", "angry", "man."},
        {"Hurry", "up!", "go", "get", "her."},
        {"It’s", "all", "that", "I", "have."},
        {"I", "like", "your", "new", "hair."},
        {"I", "am", "not", "feeling", "good."},
        {"The", "rain", "is", "so", "heavy."},
        {"The", "sun", "is", "very", "hot."},
        {"I", "wrote", "a", "love", "letter."},
        {"I", "love", "to", "eat", "cakes."},
        {"I", "hate", "you!", "Go", "away!"},
    };

    void Start()
    {
        
    }

    void Update()
    {
        if(NumCar == 1)
        {
            TextUpperCar.text = Sentences[SpawnerCar.RanNum,0];
        }
        else if(NumCar == 2)
        {
            TextUpperCar.text = Sentences[SpawnerCar.RanNum,1];
        }
        else if(NumCar == 3)
        {
            TextUpperCar.text = Sentences[SpawnerCar.RanNum,2];
        }
        else if(NumCar == 4)
        {
            TextUpperCar.text = Sentences[SpawnerCar.RanNum,3];
        }
        else if(NumCar == 5)
        {
            TextUpperCar.text = Sentences[SpawnerCar.RanNum,4];
        }
    }

}
