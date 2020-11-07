/*
* Sam Carpenter
* Prot / Chall 4
* fixes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int waveCount = 0;


    public GameObject player; 
	
	public Text w;
	public Text s;
	public Text r;
	public bool gameing;

	void Start(){
		w.gameObject.active = false;
		r.gameObject.active = false;
		gameing = true;
		waveCount = 0;
	}

    // Update is called once per frame
    void Update()
    {
		s.text = waveCount.ToString();
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
		
		if(Input.GetKeyDown(KeyCode.R) && !gameing){
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
		
        if (enemyCount == 0 && gameing)
        {
			if(waveCount >= 10){
				gameing = false;
				w.text = "YOU WIN";
				w.gameObject.active = true;
				r.gameObject.active = true;
			} else{
				SpawnEnemyWave(waveCount);
			}
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
		waveCount++;
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn + 1; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        ResetPlayerPosition(); // put player back at start

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
