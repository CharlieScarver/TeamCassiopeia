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
                break;
            case 2:
                this.gameMode = GameModes.TwoPlayers;
                break;
            case 3:
                this.gameMode = GameModes.Exit;
                break;
        }
    }
    public enum GameModes
    {
        StartMenu,
        PracticeMode,
        TwoPlayers,
        Exit
    }
}
