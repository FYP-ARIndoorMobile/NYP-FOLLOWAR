namespace Mapbox.Unity.Ar
{

    using Mapbox.Unity.Map;
    using Mapbox.Unity.Location;
    using Mapbox.Utils;
    using UnityARInterface;
    using UnityEngine;
    using Mapbox.Unity.Utilities;
    using System;


    public class FixedLocationSynchronizationContextBehaviour : MonoBehaviour, ISynchronizationContext
    {
        [SerializeField]
        AbstractMap _map;

        [SerializeField]
        Transform _mapCamera;

        [SerializeField]
        Transform ARCamera;

        [SerializeField]
        AbstractAlignmentStrategy _alignmentStrategy;

        float _lastHeading;
        float _lastHeight;



        //[SerializeField]
        //SyncronizationPointsLocationProvider _locationProvider;


        public event Action<Alignment> OnAlignmentAvailable = delegate { };
    }
}
