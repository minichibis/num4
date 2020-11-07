/*
* Sam Carpenter
* Prot / Chall 4
* enemyy
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
	public GameObject foe;
	public GameObject pup;
	private float range = 9;
	public float enemycount = 0;
	public int wave = 1;
	public bool gameing = true;
	
	public Text win;
	public Text wavey;
	public Text r;
	
    // Start is called before the first frame update
    void Start()
    {
		win.gameObject.SetActive(false);
		r.gameObject.SetActive(false);
		gameing = true;
        spawnwave(3);
    }

    // Update is called once per frame
    void Update()
    {
		wavey.text = "Wave " + wave.ToString();
		if(enemycount <= 0 && gameing){
			wave++;
			if(wave == 10){
				gameing = false;
				win.text = "YOU WIN";
			}else{
				spawnwave(2 + wave);
			}
		}
		if(!gameing){
			win.gameObject.SetActive(true);
			r.gameObject.SetActive(true);
		}
		
		if(Input.GetKeyDown(KeyCode.R) && !gameing){
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
    }
	
	
	void foemake(){
		Vector3 pos = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
		Instantiate(foe, pos, foe.transform.rotation);
		enemycount++;
	}
	
	void spawnwave(int num){
		for(int i = 0; i < num; i++){
			foemake();
		}
		Vector3 pos = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
		Instantiate(pup, pos, foe.transform.rotation);
	}
}
