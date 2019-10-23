using UnityEngine;
using Mapbox.Directions;
using System.Collections.Generic;
using System.Linq;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using System.Collections;

public class SpawnGameObject : MonoBehaviour
{
    //bool _isInitialized;
    [SerializeField]
    AbstractMap _map;
    [SerializeField]
    Transform waypoint;
    [SerializeField]
    double lat;
    [SerializeField]
    double lng;

    [SerializeField]
    float posHeight;

    protected virtual void Awake()
    {
        if (_map == null)
        {
            _map = FindObjectOfType<AbstractMap>();
        }
    }

    private void Update()
    {
        moveWaypointToGeoLocation();
    }
    void moveWaypointToGeoLocation()
    {
        waypoint.MoveToGeocoordinate(lat, lng, _map.CenterMercator, _map.WorldRelativeScale);
        waypoint.transform.position = new Vector3(transform.position.x, transform.position.y + posHeight, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
