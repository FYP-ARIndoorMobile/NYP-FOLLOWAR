using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOSetTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject _GameObjectPrefab;
    [SerializeField]
    CustomVibrate _vibrate;
    [SerializeField]
    GameObject target;
    void Awake()
    {

        _vibrate = FindObjectOfType<CustomVibrate>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        PlayerPrefs.GetFloat("VibVolume");
        _GameObjectPrefab.SetActive(false);
        this.transform.position = this.transform.localPosition;
    }
    void Update()
    {
        transform.LookAt(target.transform);
    }
    public void PlayerPref()
    {

        if (PlayerPrefs.GetFloat("VibVolume") == 1)
        {
            _vibrate.Vibrate();
            //Debug.Log("Vibrate");
        }
        else
        {
            //Debug.Log("Dont Vibrate");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPref();
            // print("Hello Touchy TOuch pls");            
            _GameObjectPrefab.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            _GameObjectPrefab.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _GameObjectPrefab.SetActive(false);
        }
    }

}
