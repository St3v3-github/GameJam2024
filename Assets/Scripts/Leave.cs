using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }
}
