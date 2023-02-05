using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    [SerializeField] GameObject endGamePanel;

    public void EndGame()
    {
        Time.timeScale = 0;
        endGamePanel.SetActive(true);
    }
}
