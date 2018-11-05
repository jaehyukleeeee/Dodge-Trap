using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonManager : MonoBehaviour {

    public GameObject PausePopup;
    public GameObject OptionPopup;

    public bool isMain;
    public bool isIngame;
    public bool isShop;
    public bool isStageList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMain)
            {
                if(OptionPopup.activeSelf)
                {
                    OptionPopup.SetActive(false);
                }
                else
                {
                    Application.Quit();
                    Debug.Log("게임종료");
                }
            }

            if(isIngame)
            {
                if(PausePopup.activeSelf)
                {
                    PausePopup.SetActive(false);
                    GameResume();
                }
                else
                {
                    PausePopup.SetActive(true);
                    GamePause();
                }
            }
        }
	}

    void GamePause()
    {
        Time.timeScale = 0f;
    }

    public void GameResume()
    {
        PausePopup.SetActive(false);
        Time.timeScale = 1f;
    }

    void GameQuit()
    {

    }
}
