using UnityEngine;

public class CarLevel4 : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private void Start() {
        if(SpawnerCar.Round == 1)
       {
            speed += 1.5f;
       }
       if(SpawnerCar.Round == 2)
       {
            speed += 2.5f;
       }
    }
    void Update()
    {
       transform.Translate(new Vector3(0f,-speed,0f) * Time.deltaTime);
       
    }
}