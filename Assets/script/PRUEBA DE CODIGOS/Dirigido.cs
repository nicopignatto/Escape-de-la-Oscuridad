using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Dirigido : MonoBehaviour
{
    public Transform target;
    public float vel;
    public float vel1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(vel,vel1,0);
    }
}
