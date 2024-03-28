using UnityEngine;

public class cameraMove2 : MonoBehaviour
{
    private const float SMOOTH_TIME = 0.3f;
    [SerializeField] private bool LockX,LockY,LockZ;
    [SerializeField] private float offSetz = -3f;
    [SerializeField] private bool useSmoothing = true;
    [SerializeField] private Transform target;
    private Transform thisTransform;
    private Vector3 velocity;

    void Awake()
    {
        thisTransform = transform;
    }

    void Update()
    {
        var newPos = new Vector3(thisTransform.position.x,thisTransform.position.y,thisTransform.position.z);
        if(useSmoothing)
        {
            newPos.x = Mathf.SmoothDamp(thisTransform.position.x,target.position.x,ref velocity.x,SMOOTH_TIME);
            newPos.y = Mathf.SmoothDamp(thisTransform.position.y,target.position.y,ref velocity.y,SMOOTH_TIME);
            newPos.z = Mathf.SmoothDamp(thisTransform.position.z,target.position.z + offSetz,ref velocity.z,SMOOTH_TIME);
        } 
        else 
        {
            newPos.x = target.position.x;
            newPos.y = target.position.y;
            newPos.z = target.position.z + offSetz;
        }

    if(LockX)newPos.x = thisTransform.position.x;
    if(LockY)newPos.y = thisTransform.position.y;
    if(LockZ)newPos.z = thisTransform.position.z;

    transform.position = Vector3.Slerp(thisTransform.position,newPos, Time.time);
    }
}
