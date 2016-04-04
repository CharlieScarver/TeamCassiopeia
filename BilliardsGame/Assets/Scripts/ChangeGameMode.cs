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
				PlayerPrefs.SetString("whoWonText", "GAME FINISHED"); // for testing purposes is set to "GAME FINISHED"; TODO remove to ""
                break;
            case 2:
                this.gameMode = GameModes.TwoPlayers;
				PlayerPrefs.SetString("whoWonText", "");
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
