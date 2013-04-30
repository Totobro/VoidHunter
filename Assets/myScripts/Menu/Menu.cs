using UnityEngine;
using System.Collections;

public enum MenuState
{
    MainMenu,
    SingleplayerMode,
    Multiplayer,
    MultiplayerMode
}

public class Menu : MonoBehaviour {

	// Use this for initialization
    public GUISkin guiSkin;
    public MenuState state = MenuState.MainMenu;
    public GameObject gameControlerPrefab;
    public GameObject gameControler;
    void Start()
    {
        if ((GameObject.FindGameObjectsWithTag("GameControler")).Length == 0)
        {
            Instantiate(gameControlerPrefab);
        }
        gameControler = GameObject.FindGameObjectWithTag("GameControler");
	}

    void DisplayMainMenu()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 200));

        ///////main menu buttons
        //game start button
        if (GUI.Button(new Rect(55, 50, 180, 40), "Single Game"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).playerMode = PlayerMode.SinglePlayer;
            state = MenuState.SingleplayerMode;
        }
        if (GUI.Button(new Rect(55, 100, 180, 40), "Multiplayer Game"))
        {
            state = MenuState.Multiplayer;
        }
        //quit button
        if (GUI.Button(new Rect(55, 150, 180, 40), "Quit"))
            Application.Quit();

        //layout end
        GUI.EndGroup();
    }

    void DisplayModeMenu()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, Screen.height));

        if (GUI.Button(new Rect(55, 50, 180, 40), "Survival"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).gameMode = GameMode.Survival;
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(55, 100, 180, 40), "King of the Hill"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).gameMode = GameMode.KingOfTheHill;
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(55, 150, 180, 40), "Time limit"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).gameMode = GameMode.TimeLimit;
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(55, 200, 180, 40), "Pacifist"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).gameMode = GameMode.Pacifist;
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(55, 250, 180, 40), "Previous"))
        {
            if (state == MenuState.SingleplayerMode)
                state = MenuState.MainMenu;
            else
                state = MenuState.Multiplayer;
        }

        //layout end
        GUI.EndGroup();
    }

    void DisplayMultiMenu()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, Screen.height));

        if (GUI.Button(new Rect(55, 50, 180, 40), "Cooperative - Multi Ship"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).playerMode = PlayerMode.MultiPlayerCoopMultiShip;
            state = MenuState.MultiplayerMode;
        }
        if (GUI.Button(new Rect(55, 100, 180, 40), "Cooperative - One Ship"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).playerMode = PlayerMode.MultiPlayerCoopOneShip;
            state = MenuState.MultiplayerMode;
        }
        if (GUI.Button(new Rect(55, 150, 180, 40), "Competitve"))
        {
            (gameControler.GetComponent("GameControler") as GameControler).playerMode = PlayerMode.MultiPlayerComp;
            state = MenuState.MultiplayerMode;
        }
        if (GUI.Button(new Rect(55, 200, 180, 40), "Previous"))
            state = MenuState.MainMenu;

        //layout end
        GUI.EndGroup();
    }

   

	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = guiSkin;

        if (state == MenuState.MainMenu)
            DisplayMainMenu();
        else if (state == MenuState.SingleplayerMode)
            DisplayModeMenu();
        else if (state == MenuState.Multiplayer)
            DisplayMultiMenu();
        else if (state == MenuState.MultiplayerMode)
            DisplayModeMenu();
    }
}
