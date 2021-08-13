using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraMov : MonoBehaviour
{
    

  

    private void Update()
    {
        transform.Translate(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
    }
}
