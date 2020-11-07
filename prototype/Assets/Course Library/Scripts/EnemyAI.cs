/*
* Sam Carpenter
* Prot / Chall 4
* enemy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public float speed = 3.0f;
	private Rigidbody rb;
	private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;
		dir = new Vector3(dir.x, 0, dir.z);
		rb.AddForce(dir * speed);
		if(transform.position.y < -20){
			GameObject.Find("SpawnManager").GetComponent<SpawnManager>().enemycount--;
			Destroy(gameObject);
		}
    }
}
