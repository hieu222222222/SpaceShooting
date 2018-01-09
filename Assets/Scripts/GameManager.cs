using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject PlayerShip;
	public GameObject PlayButton;
	public GameObject spawner;
	public GameObject GameOver;
	public enum GameManagerState
	{
		Menu,
		Play,
		gameover,
		Setting,
		level,
		help,
		exit
	}
	GameManagerState GState;
	// Use this for initialization
	void Start () {
		GState = GameManagerState.Menu;
	}
	
	// Update is called once per frame
	void UpdateGameManagerState () {
		switch(GState)
		{
		case GameManagerState.Menu:
			GameOver.SetActive (false);
			PlayButton.SetActive (true);

			break;
		case GameManagerState.Play:
			PlayButton.SetActive (false);
			PlayerShip.GetComponent<ShipController> ().Init ();
			spawner.GetComponent<enemySpawner> ().startSpawner ();
			break;
		case GameManagerState.Setting:
			break;
		case GameManagerState.help:
			break;
		case GameManagerState.level:
			break;
		case GameManagerState.gameover:
			spawner.GetComponent<enemySpawner> ().stopSpawner ();
			GameOver.SetActive (true);
			Invoke ("changeToMenu",5f);
			break;
		case GameManagerState.exit:
			break;
		}
	}
	public void SetGameManagerState(GameManagerState state)
	{
		GState = state;
		UpdateGameManagerState ();
	}
	public void startGame()
	{
		GState = GameManagerState.Play;
		UpdateGameManagerState ();
	}
	public void changeToMenu()
	{
		SetGameManagerState (GameManagerState.Menu);
	}
}
