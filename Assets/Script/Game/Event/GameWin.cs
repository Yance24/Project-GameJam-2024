using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : GameEvent
{
    public override void execute()
    {
        base.execute();
        SceneManager.LoadScene("WinScene");
        finish();
    }
}
