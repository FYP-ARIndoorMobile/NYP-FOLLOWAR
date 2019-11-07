using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartPanel : MonoBehaviour
{
    [SerializeField]
    GameObject _content;

    [SerializeField]
    Image _image;

    [SerializeField]
    AnimationCurve _curve;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitAndChangeScene", 2.0f);
    }


    // Update is called once per frame
    void Update()
    {
        var t = _curve.Evaluate(Time.time);
        _image.color = Color.Lerp(Color.clear, Color.white, t);

    }
    IEnumerator WaitAndChangeScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");
    }
}
