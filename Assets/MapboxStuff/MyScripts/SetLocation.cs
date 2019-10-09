using UnityEngine;
using Mapbox.Directions;
using System.Collections.Generic;
using System.Linq;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using System.Collections;

public class SetLocation : MonoBehaviour
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

    protected virtual void Awake()
    {
        if (_map == null)
        {
            _map = FindObjectOfType<AbstractMap>();
        }
    }

    public void Update()
    {
        moveWaypointToGeoLocation();
    }
    void moveWaypointToGeoLocation()
    {
        waypoint.MoveToGeocoordinate(lat, lng, _map.CenterMercator, _map.WorldRelativeScale);
    }
}



