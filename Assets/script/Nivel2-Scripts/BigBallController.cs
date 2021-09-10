using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallController : MonoBehaviour
{
    [SerializeField] private GameObject bigBall;

    public void spawnBigBall () 
    {
        bigBall.SetActive(true);
    }
}
