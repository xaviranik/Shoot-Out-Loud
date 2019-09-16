using UnityEngine;
using System.Collections;

public class BladeRotation : MonoBehaviour 
{

    public float rotateSpeed;

	
	void Update () 
    {
        transform.Rotate ((Vector3.forward * -90)*rotateSpeed*Time.deltaTime);
	}
}
