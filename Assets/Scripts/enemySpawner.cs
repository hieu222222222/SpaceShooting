using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
	public GameObject enemy1;
	public float maxspawn=5f;
	// Use this for initialization
	void Start () {
		Invoke ("spawnEnemy1",maxspawn);
		InvokeRepeating ("increaseSpawn",0f,30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void spawnEnemy1(){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));
		GameObject en1 = (GameObject)Instantiate (enemy1);
		en1.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
		enemyspawntime ();
	}
	void enemyspawntime (){
		float second;
		if (maxspawn > 1f) {
			second = Random.Range (1f, maxspawn);

		} else
			second = 1f;
		Invoke ("spawnEnemy1",second);
	}
	void increaseSpawn()
	{
		if(maxspawn>1f)
		{
			maxspawn--;
		}
		if (maxspawn == 1f)
			CancelInvoke ("increaseSpawn");
	}
}
