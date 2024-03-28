using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    [SerializeField] private float GizmosX = 1f;
    [SerializeField] private float GizmosY = 1f;
    [SerializeField] private float GizmosZ = 1f;

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(GizmosX, GizmosY, GizmosZ));
    }
}
