using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction5 : MonoBehaviour
{
    [SerializeField] private int _numFound;
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private Transform _ResetPosition;
    [SerializeField] private float _interactionPointRadius = 0.25f;
    [SerializeField] private LayerMask _interactableMask;    
    [SerializeField] private float delay = 120f;
    [SerializeField] private GameObject EndGame;
    [SerializeField] private GameObject Sound;
    [SerializeField] private List<AudioClip> Sounds = new List<AudioClip>();
    [SerializeField] private List<TextMeshProUGUI> UI = new List<TextMeshProUGUI>();
    [SerializeField] private TextMeshProUGUI _TotalScore;
    [SerializeField] private TextMeshProUGUI __TotalScore;
    public static int RanNumL5;
    private AudioSource audioSource;
    private float LevelScore = 0f;
    private readonly Collider [] _colloder  = new Collider[3];
    private Interactable5 _Interactable5;
    private int CountAns,lastNum = 0;
    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        RanDomNum();
    }

    void Update()
    {
        Sound.SetActive(true);
        delay -= Time.deltaTime;
        int _delay = (int)delay;
        UI[0].text = _delay.ToString();
        UI[1].text = LevelScore.ToString();

        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colloder, _interactableMask);
        
        if(_numFound == 1)
        {
            _Interactable5 =_colloder[0].GetComponent<Interactable5>();
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(_Interactable5.InteractionPrompt);
                AsIfItsYourLast();
            }
            
            if(_Interactable5.InteractionPrompt == 'X')
            {
                LevelScore = 0;
                audioSource.PlayOneShot(Sounds[3]);
                this.transform.position = new Vector3(_ResetPosition.transform.position.x,_ResetPosition.transform.position.y,_ResetPosition.transform.position.z);
            }
        }

        if(_delay == 0)
        {
            TotalScore.TotalFunc(LevelScore,__TotalScore);   
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            _TotalScore.text = LevelScore.ToString();
            EndGame.SetActive(true);
            Time.timeScale = 0;
        }
        if(Time.timeScale == 0)
        {
            Sound.SetActive(false);
        }

    
    }
    void AsIfItsYourLast()
    {
        if(delay > 0)
        {
            if(_Interactable5.InteractionPrompt == AnswerBox.AnswerTrueL5[RanNumL5,0])
            {
                CountAns++;
                RanDomNum();
                LevelScore += 100;
                audioSource.PlayOneShot(Sounds[0]);
            }
            else
            {
                audioSource.PlayOneShot(Sounds[2]);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
    void RanDomNum()
    {
        RanNumL5 = UnityEngine.Random.Range(0, Screen.QuestionL5.GetLength(0));
        if(RanNumL5 == lastNum)
        {
            RanNumL5 = UnityEngine.Random.Range(0, Screen.QuestionL5.GetLength(0));
        }
        lastNum = RanNumL5;
        Debug.Log("Random : "+RanNumL5);
    }
}
