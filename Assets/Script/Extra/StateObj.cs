using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateObj : MonoBehaviour
{

    public GameObject target;
    //GameObject[] cubes;

    // Start is called before the first frame update
    void Start()
    {
        //cubes = GameObject.FindGameObjectsWithTag("box");
        //for (int i = 0; i < cubes.Length; i++)
        //{
        //    cubes[i].SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(target, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

            //for (int i = 0; i < cubes.Length; i++)
            //{
            //    cubes[i].SetActive(true);
            //}
        }
    }
}
