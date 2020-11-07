/*
* Sam Carpenter
* Prot / Chall 4
* moveing
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveing : MonoBehaviour
{
	private Rigidbody prb;
	private GameObject focalpoint;
	public GameObject indicator;
	public float speed;
	public float pstrength = 15.0f;
	public bool powerup;
	private float vinput;
    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody>();
		focalpoint = GameObject.Find("Focal Point");
		indicator.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        vinput = Input.GetAxis("Vertical");
		if(transform.position.y < -10 && GameObject.Find("SpawnManager").GetComponent<SpawnManager>().gameing){
			GameObject.Find("SpawnManager").GetComponent<SpawnManager>().win.text = "YOU LOSE";
			GameObject.Find("SpawnManager").GetComponent<SpawnManager>().gameing = false;
		}
    }
	
	void FixedUpdate(){
		prb.AddForce(focalpoint.transform.forward * speed * vinput);
	}
	
	private void OnTriggerEnter(Collider other){
		if(other.CompareTag("Powerup")){
			powerup = true;
			Destroy(other.gameObject);
			indicator.active = true;
			StartCoroutine(coroutine());
		}
	}
	
	private void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Enemy") && powerup){
			Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
			Vector3 d = (other.gameObject.transform.position - transform.position).normalized;
			r.AddForce(d * pstrength, ForceMode.Impulse);
		}
	}
	
	IEnumerator coroutine(){
		yield return new WaitForSeconds(7);
		powerup = false;
		indicator.active = false;
	}
}
