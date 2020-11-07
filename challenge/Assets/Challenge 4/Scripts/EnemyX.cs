/*
* Sam Carpenter
* Prot / Chall 4
* fixes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
		playerGoal = GameObject.Find("Player Goal");
		speed *= GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
			GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().gameing = false;
			GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().w.text = "YOU LOSE";
			GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().w.gameObject.active = true;
			GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().r.gameObject.active = true;
        }

    }

}
