using UnityEngine;
using System.Collections;

public class ChangeGameMode : MonoBehaviour
{
    public GameModes gameMode;
    public void SetGameMode (int gameMode)
	
    {
        PlayerPrefs.SetInt("gameMode", gameMode);
        switch (gameMode)
        {
            case 0:
                this.gameMode = GameModes.StartMenu;
                break;
            case 1:
                this.gameMode = GameModes.PracticeMode;
				PlayerPrefs.SetString("whoWonText", ""); //the text stays empty until the end of the game - there is no wining in this game mode
                break;
            case 2:
                this.gameMode = GameModes.TwoPlayers;
				PlayerPrefs.SetString("whoWonText", ""); // still no one has won the game
				PlayerPrefs.SetInt("playerTurn", 1); // player 1 begins to play first
				PlayerPrefs.SetInt("twoPlayerMode", 1); // the first mode in two players mode which define which player with which balls to play
                break;
            case 3:
                this.gameMode = GameModes.Exit;
                break;
            case 4:
                this.gameMode = GameModes.GameOver;
                break;
        }
    }
    public enum GameModes
    {
        StartMenu,
        PracticeMode,
        TwoPlayers,
        Exit,
        GameOver
    }
}
