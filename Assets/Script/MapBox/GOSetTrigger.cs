using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOSetTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject _GameObjectPrefab;
    //[SerializeField]
    //Vibration _vibrate;
    [SerializeField]
    GameObject target;
    void Awake()
    {
        // _vibrate = FindObjectOfType<Vibration>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        _GameObjectPrefab.SetActive(false);

        
        this.transform.position = this.transform.localPosition;
    }
    void Update()
    {
        transform.LookAt(target.transform);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //if (_vibrate != null)
            //{
            //    _vibrate.VibrateToggle();
            //}

            
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
