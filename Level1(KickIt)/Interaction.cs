using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] private int _numFound;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.25f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private TextMeshProUGUI _word;
    [SerializeField] private TextMeshProUGUI _wordTH;
    [SerializeField] private TextMeshProUGUI _LevelScore;
    [SerializeField] private TextMeshProUGUI LastWord;
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private TextMeshProUGUI _TotalScore;
    [SerializeField] private AudioClip SoundTrue;
    [SerializeField] private AudioClip SoundPass;
    [SerializeField] private AudioClip SoundFail;
    [SerializeField] private float delay = 180;
    [SerializeField] private GameObject EndGame;
    [SerializeField] private GameObject Sound;
    private readonly Collider [] _colloder  = new Collider[3];
    private float LevelScore;
    private AudioSource audioSource;
    private Interactable _Interactable;
    private string [,] Str = {
        {"luck","bug","pink","computer","keyboard","guide","information","technology","code","compiler"},
        {"monitor","desktop","icon","button","mouse","modem","connect","search","password","click"},
        {"internet","social","network","scanner","speaker","drive","card","memory","plug","wire"},
        {"browser","database","server","file","software","history","tools","help","folder","hardware"},
        {"channel","router","print","type","scroll","error","processor","unit","control","access"},
        {"username","reply","sent","forward","message","spam","trash","auto","bug","system"},
        };
    string[,] wordsTH = {
        {"โชคดี","ข้อผิดพลาด","สีชมพู","คอมพิวเตอร์","แป้นพิมพ์","แนะนำ","ข้อมูล","เทคโนโลยี","รหัส","คอมไพล์เลอร์"},
        {"จอภาพ","เดสก์ท็อป","ไอคอน","ปุ่ม","เมาส์","โมเด็ม","เชื่อมต่อ","ค้นหา","รหัสผ่าน","คลิก"},
        {"อินเทอร์เน็ต","โซเชียล","เน็ตเวิร์ก","สแกนเนอร์","ลำโพง","ไดรฟ์","การ์ด","หน่วยความจำ","ปลั๊ก","สาย"},
        {"เบราว์เซอร์","ฐานข้อมูล","เซิร์ฟเวอร์","ไฟล์","ซอฟต์แวร์","ประวัติศาสตร์","เครื่องมือ","ช่วยเหลือ","โฟลเดอร์","ฮาร์ดแวร์"},
        {"ช่อง","เราเตอร์","พิมพ์","พิมพ์","เลื่อน","ข้อผิดพลาด","โปรเซสเซอร์","หน่วยควบคุม","ควบคุม","เข้าถึง"},
        {"ชื่อผู้ใช้","ตอบกลับ","ส่ง","ส่งต่อ","ข้อความ","สแปม","ถังขยะ","อัตโนมัติ","ข้อผิดพลาด","ระบบ"}
    };
    private int ArrayIndex,WordIndex,CharIndex = 0; //RandomIndex
    private int randomNumber;
    private int lastNumber;

    private void Start() 
    {
        ArrayIndex = UnityEngine.Random.Range(0, (Str.Length/10));
        Debug.Log(ArrayIndex);

        LevelScore = 0;
        LastWord.text = "";
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        Debug.Log(Str.Length);
        Debug.Log(message: Str[ArrayIndex,WordIndex]);
        Debug.Log(Str[ArrayIndex,WordIndex].Length);
    }
    private void Update() 
    {
        Sound.SetActive(true);
        delay -= Time.deltaTime;
        int _delay = (int)delay;
        Timer.text = _delay.ToString();

        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colloder, _interactableMask);
        _word.text = Str[ArrayIndex,WordIndex];
        _wordTH.text = wordsTH[ArrayIndex,WordIndex];
        _LevelScore.text = LevelScore.ToString();

        if(_numFound == 1)
        {
            _Interactable =_colloder[0].GetComponent<Interactable>();
            
            if(Input.GetKeyDown(KeyCode.E))
            {                
                word();
                Debug.Log(_Interactable.InteractionPrompt);
                Debug.Log(WordIndex);
            }            

        }
        if (_delay == 0 || WordIndex == Str.GetLength(1))
        {
            TotalScore.TotalFunc(LevelScore,_TotalScore);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Score.text = LevelScore.ToString();
            EndGame.SetActive(true);
            Time.timeScale = 0;
            Sound.SetActive(false);
        }
        if(Time.timeScale == 0)
        {
            Sound.SetActive(false);
        }
    }

    void  word()
    {
        char ch = _Interactable.InteractionPrompt;  
        if(WordIndex < Str.GetLength(1)){
            if (CharIndex < Str[ArrayIndex,WordIndex].Length)
            {
                if (ch == Str[ArrayIndex,WordIndex][CharIndex])
                    {
                        LastWord.text += ch;
                        audioSource.PlayOneShot(SoundTrue);
                        Debug.Log(message: CharIndex);
                        Debug.Log(message: "True!");

                        CharIndex++;
                    }
                    else
                    {
                        audioSource.PlayOneShot(SoundFail);
                    }
            }
            if(CharIndex == Str[ArrayIndex,WordIndex].Length)
            {
                audioSource.PlayOneShot(SoundPass);
                Debug.Log("Pass");
                WordIndex++;
                CharIndex=0;
                LastWord.text = "";
                LevelScore += 100;
            }   
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
