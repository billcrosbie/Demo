using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); //deltaTime represents the difference in seconds since the last frame occurred. Changes it's value based on frame length; ensures smooth rotation.
    }
}
