using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class IntroPlayer : MonoBehaviour 
{

    public MovieTexture movie;
    private AudioSource audio_movie;

    public string level = "Outdoor";

    public SceneFader sceneFader;

    void Start () 
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio_movie = GetComponent<AudioSource>();
        audio_movie.clip = movie.audioClip;
        movie.Play ();
        audio_movie.Play ();
    }

	void Update () 
    {
        if (!movie.isPlaying)
        {
            levelLoad();
        }
	}

    public void levelLoad()
    {
        sceneFader.FadeToScene(level);
    }



}

