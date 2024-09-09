using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    void Update()
    {
        //Creating variable that spins in the Z axis
        Vector3 spinZ = new Vector3(0,0,1);

        //Spinning in the Z axis
        transform.Rotate(spinZ);
    }
}
