using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOSetTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject _GameObjectPrefab;    
[SerializeField]
    Vibration _vibrate;

    void Awake()
    {
        _vibrate = FindObjectOfType<Vibration>();
    }
    void Start()
    {
        _GameObjectPrefab.SetActive(false);
       

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_vibrate != null)
            {
                _vibrate.VibrateToggle();
            }
            _GameObjectPrefab.SetActive(true);
          
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Handheld.Vibrate();
            _GameObjectPrefab.SetActive(true);
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Handheld.Vibrate();
            _GameObjectPrefab.SetActive(false);
        }
    }
}
