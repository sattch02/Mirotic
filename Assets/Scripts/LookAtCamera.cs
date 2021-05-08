using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // UIをカメラに向ける
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
