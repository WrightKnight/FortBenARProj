using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float cameraTransformX;
    public float cameraTransformY;
    public GameObject cameraObject;
    public void moveCamera()
    {
        cameraObject.transform.position += new Vector3(cameraTransformX, cameraTransformY, 0);
    }
}
