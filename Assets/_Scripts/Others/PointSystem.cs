using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour 
{
    public int points;
    public Text pointText;


    void Update () 
    {
        pointText.text = (""+points);
	}

}
