using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRotation : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    float height = 2f;
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, height, transform.localPosition.z);
        transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }
}
