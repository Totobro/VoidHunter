using UnityEngine;
using System.Collections;

public enum GameMode
{
    Survival,
    KingOfTheHill,
    TimeLimit,
    Pacifist
}

public enum PlayerMode
{
    SinglePlayer,
    MultiPlayerCoopMultiShip,
    MultiPlayerCoopOneShip,
    MultiPlayerComp
}

public class GameControler : MonoBehaviour {

    public GameMode gameMode = GameMode.Survival;
    public PlayerMode playerMode = PlayerMode.SinglePlayer;

	void Start () {
        gameObject.tag = "GameControler";
        DontDestroyOnLoad(gameObject);
	}
}
