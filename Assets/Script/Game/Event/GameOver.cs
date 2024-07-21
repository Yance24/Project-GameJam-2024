using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : GameEvent
{
    public override void execute()
    {
        base.execute();
        SceneManager.LoadScene("GameOverScene");
        finish();
    }
}
