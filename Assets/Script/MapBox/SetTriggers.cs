using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTriggers : MonoBehaviour
{
    //[SerializeField]
    //GameObject _GameObjectPrefab;
    [SerializeField]
    GameObject _directionPanel;
    //[SerializeField]
    //Vibration _vibrate;

    void Awake()
    {
        //_vibrate = FindObjectOfType<Vibration>();
    }
    void Start()
    {
       // _GameObjectPrefab.SetActive(false);
        _directionPanel.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //if (_vibrate != null)
            //{
            //    _vibrate.VibrateToggle();
            //}
           // _GameObjectPrefab.SetActive(true);
            _directionPanel.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _directionPanel.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            _directionPanel.SetActive(false);
        }
    }

}
