using UnityEngine;
using TMPro;

public class Interaction2 : MonoBehaviour
{
    [SerializeField] private int _numFound;
    [SerializeField] private int _NumPad;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.25f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private Animator AnimatorLight;
    [SerializeField] private Transform RespanwPoint ;
    [SerializeField] private TextMeshProUGUI QtionScreen;
    [SerializeField] private TextMeshProUGUI QtionScreenTH;
    [SerializeField] private float delay = 180f;
    [SerializeField] private GameObject EndGame;
    [SerializeField] private GameObject Sound;
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI _LevelScore;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI _TotalScore;
    [HideInInspector] public bool DestroyPad = false;
    [SerializeField] private AudioClip SoundTrue;
    [SerializeField] private AudioClip SoundFail;
    private AudioSource audioSource;
    private float LevelScore;
    private readonly Collider [] _colloder  = new Collider[3];
    private Interactable2 _Interactable;
    private int ListQ,QuestionCount = 0; //ListQi,j
    public static int CountFalseAns = 0;
    private string [,] Qtion = {
        {
        "The second most common vowel in English after e is b. ?",
        "Verb to be includes is, am, are, was, were?",
        "English is the most widely spoken language in the world.",
        "The English alphabet consists of 26 letters.",
        "American and British English are identical in terms of vocabulary and pronunciation.",
        "English is a Germanic language with heavy influence from Latin and French.",
        "English is classified as a Romance language.",
        "The English language originated in England.",
        "The word 'oxen' is the plural form of 'ox' in English.",
        "English is the official language of the United Kingdom and the United States."
        },
        {
        "The definite article in English is 'the.'",
        "The word 'book' can be both a noun and a verb.",
        "'Fast' can be both an adjective and an adverb.",
        "'Affect' is a verb, while 'effect' is a noun.",
        "The word 'universe' is spelled with a double 'i.'",
        "The word 'abstemious' has only one vowel.",
        "The word 'cat' is a homophone of 'cot.'",
        "The word 'xylophone' starts with a vowel.",
        "In English, the letter 'q' is always followed by the letter 'u.'",
        "The word 'segue' is pronounced 'see-gyoo.'",
        },
        {
        "The past tense of 'sing' is 'sang.'",
        "'Cats' is a singular noun.",
        "'Color' and 'colour' are two different words with distinct meanings.",
        "The past tense of 'Run' is 'Ran.'",
        "The adverb 'always' is often used with the simple past tense.",
        "The past tense of 'sing' is 'sang.'",
        "The past tense of 'drink' is 'drank.'",
        "In English, double negatives are used for emphasis.",
        "The verb 'to have' changes to 'had' in the past tense.",
        "The word 'obfuscate' means to clarify or make clear.",
        },
    };
    private string [,] QtionTH = {
        {
        "สระที่สองที่พบบ่อยที่สุดในภาษาอังกฤษหลังจาก e คือ b?",
        "กริยา 'to be' รวมถึง is, am, are, was, were?",
        "ภาษาอังกฤษเป็นภาษาที่พูดกันอย่างแพร่หลายที่สุดในโลก?",
        "อักษรอังกฤษประกอบด้วยตัวอักษรจำนวน 26 ตัว?",
        "อังกฤษแบบอเมริกันและอังกฤษแบบบริติชเหมือนกันทั้งในเรื่องคำศัพท์และการออกเสียง?",
        "ภาษาอังกฤษเป็นภาษาเชิงเยอรมันที่มีการมีอิทธิพลจากภาษาละตินและฝรั่งเศส?",
        "ภาษาอังกฤษถูกจัดอยู่ในกลุ่มภาษาโรแมนซ์?",
        "ภาษาอังกฤษมีต้นกำเนิดที่อังกฤษ?",
        "คำว่า 'oxen' เป็นรูปพหูพจน์ของ 'ox' ในภาษาอังกฤษ?",
        "ภาษาอังกฤษเป็นภาษาอย่างเป็นทางการของสหรัฐอาหรับเอมิเรตส์และสหราชอาณาจักร?"
        },
        {
        "บทนิพนธ์ที่กำหนดเป็น 'the' ในภาษาอังกฤษคือ 'the.'",
        "คำว่า 'book' สามารถเป็นคำนามและกริยาได้ทั้งคู่?",
        "'Fast' สามารถเป็นคำคุณศัพท์และคำกริยาวิเศษณ์ได้ทั้งคู่?",
        "'Affect' เป็นคำกริยา ในขณะที่ 'effect' เป็นคำนาม?",
        "คำว่า 'universe' สะกดด้วยสระ 'i' สองตัว?",
        "คำว่า 'abstemious' มีเพียงสระเดียว?",
        "คำว่า 'cat' เป็นคำที่เสียงเหมือนกับ 'cot'?",
        "คำว่า 'xylophone' เริ่มต้นด้วยสระ?",
        "ในภาษาอังกฤษ ตัวอักษร 'q' จะตามทันทีด้วยตัวอักษร 'u.'?",
        "คำว่า 'segue' มีการออกเสียงเป็น 'see-gyoo.'?",
        },
        {
        "กริยาช่อง 3 ของ 'sing' คือ 'sang.'",
        "'Cats' เป็นคำนามในรูปเอกพจน์?",
        "'Color' และ 'colour' เป็นคำที่แตกต่างกันและมีความหมายที่แตกต่างกัน?",
        "กริยาช่อง 3 ของ 'Run' คือ 'Ran.'",
        "คำวิเศษณ์ 'always' มักถูกใช้กับ tensed simple หรือ simple past tense?",
        "กริยาช่อง 2 ของ 'sing' คือ 'sang.'",
        "กริยาช่อง 2 ของ 'drink' คือ 'drank.'",
        "ในภาษาอังกฤษ การใช้คำลบคู่มักถูกใช้เพื่อเน้นความหมาย.",
        "กริยา 'to have' จะเปลี่ยนเป็น 'had' ในอดีตกาล.",
        "คำว่า 'obfuscate' หมายถึงการทำให้เข้าใจลำบากหรือไม่ชัดเจน."
        }
    };

    private bool [,] Ans ={
        {
        false,
        true,
        true,
        true,
        false,
        true,
        false,
        false,
        true,
        true,
        },
        {
        false,
        true,
        true,
        true,
        false,
        true,
        false,
        false,
        true,
        true,
        },
        {
        true,
        false,
        false,
        true,
        false,
        true,
        true,
        false,
        true,
        false,
        },
    };
    
    private void Start() 
    {
        AnimatorLight = AnimatorLight.GetComponent<Animator>();
        Debug.Log(Qtion.Rank);
        EndGame.SetActive(false);

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

        if(QuestionCount < Qtion.GetLength(1) )
        {
            QtionScreen.text = Qtion[ListQ,QuestionCount];
            QtionScreenTH.text = QtionTH[ListQ,QuestionCount];
            _LevelScore.text = LevelScore.ToString();
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ResetPosition();
        }

        if (_delay == 0 || QuestionCount == Qtion.GetLength(1) || CountFalseAns == 10)
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
        if(_numFound == 1)
        {
            _Interactable =_colloder[0].GetComponent<Interactable2>();
            _NumPad = _Interactable.NunPad;

            if(_NumPad == 11)
            {
                QuestionCount = 0;
                AnimatorLight.SetBool("TurnRed", true);
                AnimatorLight.SetBool("TurnGreen", false);
                ResetPosition();
                audioSource.PlayOneShot(SoundFail);
                if(LevelScore != 0)
                {
                    LevelScore = 0;
                }

                if(ListQ < Qtion.Rank)
                {
                    ListQ++ ;
                }
                else
                {
                    ListQ = 0 ;
                }
            }
            else
            {
                CheckQ();
            }
        } 
        else 
        {
            AnimatorLight.SetBool("TurnGreen", false);
            AnimatorLight.SetBool("TurnRed", false);
            _NumPad = 0;
        }
    }

    void CheckQ()
    {
        if(QuestionCount < Qtion.GetLength(1))
        {
            if(_NumPad == QuestionCount + 1)
            {
                if(_Interactable.InteractionPrompt == Ans[ListQ,QuestionCount])
                {
                    AnimatorLight.SetBool("TurnGreen", true);
                    AnimatorLight.SetBool("TurnRed", false);
                    QuestionCount++;
                    Debug.Log(QuestionCount);
                    LevelScore += 100;
                    DestroyPad = false;

                    audioSource.PlayOneShot(SoundTrue);

                }
                else
                {
                    AnimatorLight.SetBool("TurnRed", true);
                    AnimatorLight.SetBool("TurnGreen", false);
                    ResetPosition();

                    audioSource.PlayOneShot(SoundFail);
                    
                    CountFalseAns++;

                    if(ListQ < Qtion.Rank)
                    {
                        ListQ++ ;
                    }
                    else
                    {
                        ListQ = 0 ;
                    }

                    QuestionCount = 0;
                    DestroyPad = true;

                    if(LevelScore != 0)
                    {
                        LevelScore -= 80;
                    }
                }
            }   
        }
    }

    void  ResetPosition()
    {
        this.transform.position = new Vector3(RespanwPoint.position.x,RespanwPoint.position.y,RespanwPoint.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
