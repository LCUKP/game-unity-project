using UnityEngine;
using TMPro;

public class Interaction3 : MonoBehaviour
{
    [SerializeField] private int _numFound;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.25f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private TextMeshProUGUI QtionScreen;
    [SerializeField] private TextMeshProUGUI _LevelScore;
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI _TotalScore;
    [SerializeField] private float delay = 180f;
    [SerializeField] private GameObject EndGame;
    [SerializeField] private GameObject Sound;
    [SerializeField] private AudioClip SoundTrue;
    // [SerializeField] private AudioClip SoundPass;
    [SerializeField] private AudioClip SoundFail;
    [SerializeField] private Transform ResetPosPlayer;
    private AudioSource audioSource;
    private float LevelScore = 0;
    private readonly Collider [] _colloder  = new Collider[3];
    private Interactable3 _Interactable;
    private string[,] Qtion = {
        {
            "We ... (is,am,are) students.",
            "This ... (is,am,are) a yellow book.",
            "... (is,am,are) she the owner of this PC?",
            "I ... (is,am,are) not a good teacher.",
            "They ... (is,am,are) not good students.",
            "He ... (is,am,are) a driver. ",
            "... (is,am,are) i the only on here?",
            "This ... (is,am,are) my vely fu*kin best friend",
            "I ... (is,am,are) a son of the bible",
            "You ... (is,am,are) my whole life",
            "You'r Done!!!"
        },
    };
    public static string[,] AnswersTrue = {
        {
            "are",
            "is",
            "is",
            "am",
            "are",
            "is",
            "am",
            "is",
            "am",
            "are",
            "Alone"
        },
    };
    public static int CountAnswers,ArrayIndex = 0;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update() 
    {
        Sound.SetActive(true);
        delay -= Time.deltaTime;
        int _delay = (int)delay;
        Timer.text = _delay.ToString();

        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colloder, _interactableMask);
        QtionScreen.text = Qtion[ArrayIndex,CountAnswers];
        _LevelScore.text = LevelScore.ToString();

        if(CountAnswers == AnswersTrue.GetLength(1) - 1 )
        {
            TotalScore.TotalFunc(LevelScore,_TotalScore);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Score.text = LevelScore.ToString();
            EndGame.SetActive(true);
            Time.timeScale = 0;
        }
        if(Time.timeScale == 0)
        {
            Sound.SetActive(false);
        }
    }

    private void FixedUpdate() 
    {
        SpawnCar.DestroyCar = false;

        if(_numFound == 1){
            _Interactable =_colloder[0].GetComponent<Interactable3>();
            Bomblastic();
        }
    }

    void Bomblastic()
    {
        if(CountAnswers < Qtion.GetLength(1))
        {
            if(NumCar.Answers[ArrayIndex,_Interactable.InteractionPrompt - 1] == AnswersTrue[ArrayIndex,CountAnswers])
            {
                SpawnCar.DestroyCar = true;
                LevelScore += 100;
                audioSource.PlayOneShot(SoundTrue);
                CarMove.speed += 1.5f;
                CountAnswers++ ;
                if(SpawnCar.TimeToSpawn > 0){
                    SpawnCar.TimeToSpawn -= 1f;
                }
            }
            else
            {
                audioSource.PlayOneShot(SoundFail);
                this.transform.position = new Vector3(ResetPosPlayer.transform.position.x,ResetPosPlayer.transform.position.y,ResetPosPlayer.transform.position.z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
