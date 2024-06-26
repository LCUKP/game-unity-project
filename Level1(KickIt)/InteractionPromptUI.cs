using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;

    private void Start(){
        _mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(worldPosition:transform.position + rotation * Vector3.forward, worldUp:rotation * Vector3.up);
    }

}
