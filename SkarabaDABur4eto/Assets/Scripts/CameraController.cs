using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float cameraSpeed;

    void FixedUpdate ()
    {
        this.GetComponent<Transform>().position = Vector3.Lerp(this.GetComponent<Transform>().position, 
            new Vector3(target.position.x, target.position.y, this.GetComponent<Transform>().position.z), 
            cameraSpeed * Time.deltaTime);
	}
}
