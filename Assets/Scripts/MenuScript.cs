using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject LostGame;
    public static bool isExit = false;
    public static bool isReplay = false;
    public string ExitMenu;
    // Start is called before the first frame update
    void Start()
    {
        LostGame?.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownTimer.isLost)
        {
            LostGame?.SetActive(true);
            MenuChoosen();
        }
    }
    private void MenuChoosen()
    {
        if (isExit && CountdownTimer.isLost && !isReplay) {
            SceneManager.LoadScene(ExitMenu);
        }else if (isReplay && CountdownTimer.isLost && !isExit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
