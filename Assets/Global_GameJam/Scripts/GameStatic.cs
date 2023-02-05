using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatic : MonoBehaviour
{
    [SerializeField] Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        SceneController.Instance.NextScene();

        DontDestroyOnLoad(gameObject);

        //playButton.onClick.AddListener(() => SceneLoadManager.Instance.LoadSceneGamePlay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
