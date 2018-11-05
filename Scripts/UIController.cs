using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public GameObject OptionPopUp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Button_StageList()
    {
        transform.GetChild(0).GetComponent<PoopController>().UISpikeOn();
        //SceneManager.LoadScene(1);
    }
    public void Button_Start()
    {
        transform.GetChild(0).GetComponent<PoopController>().UISpikeOn();
        Invoke("Go2Game", 0.5f);
    }
    public void Button_Shop()
    {
        transform.GetChild(0).GetComponent<PoopController>().UISpikeOn();
        //SceneManager.LoadScene(1);
    }
    public void Button_Main()
    {
        Time.timeScale = 1;
        Go2Main();
    }
    public void Button_Retry()
    {
        Time.timeScale = 1;
        Go2Game();
    }

    public void Button_Option()
    {
        OptionPopUp.SetActive(true);
    }

    public void Button_OptionBack()
    {
        OptionPopUp.SetActive(false);
    }

    void Go2Game()
    {
        SceneManager.LoadScene(1);
    }

    void Go2Main()
    {
        SceneManager.LoadScene(0);
    }
}
