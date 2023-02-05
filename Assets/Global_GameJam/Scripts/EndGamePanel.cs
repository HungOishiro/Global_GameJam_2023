using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] Button replayButton;

    private void Start()
    {
        replayButton.onClick.AddListener(Replay);
    }

    void Replay()
    {
        Time.timeScale = 1;
        SceneLoadManager.Instance.LoadSceneGamePlay();
    }
}
