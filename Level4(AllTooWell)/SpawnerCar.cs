using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpawnerCar : MonoBehaviour
{
    public static int CountNum = 0 ;
    public static float currenttimetospawn;
    public static int Round;
    [SerializeField] private float TimeToSpawn = 10f;
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private List<GameObject> Cars = new List<GameObject>();
    [SerializeField] private GameObject Line;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject TimeObject;
    [SerializeField] private GameObject EndGame;
    [SerializeField] private GameObject Sound;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI _Score;
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI SentencesUI;
    [SerializeField] private TextMeshProUGUI _TotalScore;
    [SerializeField] private List<AudioClip> Sounds = new List<AudioClip>();
    private AudioSource audioSource;
    private int LevelScore;
    private int AmountAnswers = 0;
    public static int AnswerBool;
    public static int RanNum ;
        

    void Start()
    {
        SentencesUI.text = " ";
        RanDomNum();
        Round = 0;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        Sound.SetActive(true);
        int _delay = (int)currenttimetospawn;
        Timer.text = _delay.ToString();
        Score.text = LevelScore.ToString();

        if(Round < 3)
        {
            if(currenttimetospawn > 0)
            {
                currenttimetospawn -= Time.deltaTime;
            }
            else
            {
                if(CountNum == 0)
                {
                    Line.SetActive(true);
                    Button.SetActive(false);
                    TimeObject.SetActive(false);

                    SentencesUI.text = " ";
                    AmountAnswers = 0 ;

                    SpawnCarOne();
                    Debug.Log(CountNum);
                    currenttimetospawn = TimeToSpawn;
                    CountNum++;
                }
                else if(CountNum == 1)
                {
                    SpawnCarTwo();
                    Debug.Log(CountNum);
                    currenttimetospawn = TimeToSpawn;
                    CountNum++;
                }
                else if(CountNum == 2)
                {
                    SpawnCarThree();
                    Debug.Log(CountNum);
                    currenttimetospawn = TimeToSpawn;
                    CountNum++;
                }
                else if(CountNum == 3)
                {
                    SpawnCarFour();
                    Debug.Log(CountNum);
                    currenttimetospawn = TimeToSpawn;
                    CountNum++;
                }
                else if(CountNum == 4)
                {
                    SpawnCarFive();
                    Debug.Log(CountNum);
                    currenttimetospawn = 10;
                    CountNum++;
                }
                else if(CountNum == 5 )
                {
                    DestroyCar();
                    Line.SetActive(false);
                    Button.SetActive(true);
                    currenttimetospawn = 16;
                    TimeObject.SetActive(true);
                }
            }
        }
        else
        {
            TotalScore.TotalFunc(LevelScore,_TotalScore);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SentencesUI.text = "As If It's Your Last!!!";

            _Score.text = LevelScore.ToString();
            EndGame.SetActive(true);
            Time.timeScale = 0;
        }
        if(Time.timeScale == 0)
        {
            Sound.SetActive(false);
        }

        if(AnswerBool == 1)
        {
            audioSource.PlayOneShot(Sounds[0]);
            LevelScore += 80;

            SentencesUI.text += WordCarFour.Sentences[RanNum,AmountAnswers] + " ";
            AmountAnswers++;
        }
        else if(AnswerBool == 2)
        {
            audioSource.PlayOneShot(Sounds[2]);

            if(LevelScore !<0){
                LevelScore -= 30;
            }

            SentencesUI.text += WordCarFour.Sentences[RanNum,AmountAnswers] + " ";
            AmountAnswers++;
        }
        else if(AnswerBool == 3)
        {
            Round++;
            LevelScore += 100;
            Line.SetActive(true);
            Button.SetActive(false);
            TimeObject.SetActive(false);
            audioSource.PlayOneShot(Sounds[1]);
            
            SentencesUI.text += WordCarFour.Sentences[RanNum,AmountAnswers] + " ";
            AmountAnswers++;
            
            RanDomNum();
        }
        else if(AnswerBool == 4)
        {
            Round++;
            Line.SetActive(true);
            Button.SetActive(false);
            TimeObject.SetActive(false);
            audioSource.PlayOneShot(Sounds[3]);
                        
            RanDomNum();
        }

        AnswerBool = 0;
    }

    void RanDomNum()
    {
        RanNum = UnityEngine.Random.Range(0, 14);
        Debug.Log("Random : "+RanNum);
        Debug.Log("Round : "+Round);
    }

    void DestroyCar()
    {
        Destroy(GameObject.Find("Car1(Clone)"));
        Destroy(GameObject.Find("Car2(Clone)"));
        Destroy(GameObject.Find("Car3(Clone)"));
        Destroy(GameObject.Find("Car4(Clone)"));
        Destroy(GameObject.Find("Car5(Clone)"));
    }


    void SpawnCarOne()
    {
        Instantiate(Cars[0],SpawnLocation);
    }

    void SpawnCarTwo()
    {
        Instantiate(Cars[1],SpawnLocation);
    }

    void SpawnCarThree()
    {
        Instantiate(Cars[2],SpawnLocation);
    }

    void SpawnCarFour()
    {
        Instantiate(Cars[3],SpawnLocation);
    }

    void SpawnCarFive()
    {
        Instantiate(Cars[4],SpawnLocation);
    }
}
