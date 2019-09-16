using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour 
{
    public Image Img;
    public AnimationCurve FadeCurve;

    void Start()
    {
        StartCoroutine(fadeIn());
    }

    public void FadeToScene(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator fadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = FadeCurve.Evaluate(t);
            Img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = FadeCurve.Evaluate(t);
            Img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
