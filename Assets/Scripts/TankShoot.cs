using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{

    public void RotateCannon(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
