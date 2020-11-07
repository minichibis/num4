/*
* Sam Carpenter
* Prot / Chall 4
* speeeeeeeeeeeeen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameras : MonoBehaviour
{
	public float rotspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up, hinput * rotspeed * Time.deltaTime);
    }
}
