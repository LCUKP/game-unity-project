using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private GameObject Car;
    public static float speed = 6;

    void Update()
    {
        transform.Translate(new Vector3(0f,-speed,0f) * Time.deltaTime);
       
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("DestroyPoint"))
        {
            Debug.Log("1");
            if(gameObject.name == "Car(Clone)")
            {
                Destroy(gameObject);
            }
        } 
        else
        {
            Debug.Log("0");
        }
    }
}
