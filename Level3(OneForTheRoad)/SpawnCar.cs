using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    [SerializeField] private int Count;
    [SerializeField] private int CountNum = 0 ;
    [SerializeField] private float currenttimetospawn;
    [SerializeField] private List<GameObject> Cars = new List<GameObject>();
    [SerializeField] private Transform SpawnLocationStart;
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private Transform SpawnLocationEnd;
    public static float TimeToSpawn = 10f;
    public static bool DestroyCar = false;

    void Start()
    {
        Count = 20;
    }

    void Update()
    {
        
        if(currenttimetospawn > 0)
        {
            currenttimetospawn -= Time.deltaTime;
        }
        else
        {
            if(CountNum < Count)
            SpawnCarOn();
            currenttimetospawn = TimeToSpawn;
            CountNum++;
        }

        if(Interaction3.CountAnswers < 10){
            if(DestroyCar)
            {
                Destroy(GameObject.Find("Car(Clone)"));
                Destroy(GameObject.Find("CarOne(Clone)"));
                Destroy(GameObject.Find("CarTwo(Clone)"));
            }
        }
    }

    void SpawnCarOn()
    {
        Instantiate(Cars[0],SpawnLocationStart);
        Instantiate(Cars[1],SpawnLocation);
        Instantiate(Cars[2],SpawnLocationEnd);
    }
}
