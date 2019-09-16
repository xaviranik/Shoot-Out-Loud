using UnityEngine;
using System.Collections;

public class CameraFallThrough : MonoBehaviour 
{

	
	void Awake () 
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("obstacle"), LayerMask.NameToLayer("obstacle"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("obstacle"));
	}
	
	
	void Update () 
    {
	
	}
}
