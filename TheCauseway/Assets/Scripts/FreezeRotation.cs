using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    void Update()
    {
        //lock rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
