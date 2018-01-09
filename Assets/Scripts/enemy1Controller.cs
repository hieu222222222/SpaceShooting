using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy1Controller : MonoBehaviour {
	public float speed;
	public GameObject explosion;
	public Text LifeScore;
	const int scoredefault = 0;
	int score;
	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position = new Vector2 (position.x,position.y-speed*Time.deltaTime);
		transform.position = position;
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));
		if(transform.position.y<min.y)
		{
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag=="PlayerShipTag"||col.tag=="PlayerBulletTag")
		{Explosion ();
			Destroy(gameObject);
		}
	}
	void Explosion()
	{
		GameObject _explosion = (GameObject)Instantiate (explosion);
		_explosion.transform.position = transform.position;
	}
}
