using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour {

    public List<Material> matList = new List<Material>();
    [SerializeField] private Material mat;
    public Material changeMat;

    [SerializeField]private bool bomb = false;

    ArrayList patternArrayList = new ArrayList();

    private MeshRenderer meshRenderer;

    RowController rc;

    [SerializeField] int CurPatternCount = 0;
    [SerializeField] int column = 0;
    [SerializeField] int row = 0;

    Vector3 myPos;

    // Use this for initialization
    void Start () {
        //int matNum = UnityEngine.Random.Range(0, 2);
        meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.material = matList[matNum];
        mat = meshRenderer.material;

        rc = transform.parent.GetComponent<RowController>();

        //Debug.Log(column + ", " + row);
        myPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if(rc.GameReady && !GamePlayManager.Instance.isEditor)
        {
            SetName();
            bomb = Convert.ToBoolean(GamePlayManager.Instance.repackPattern[column, row]);
        }

        //bomb = Convert.ToBoolean(GamePlayManager.Instance.repackPattern[column, row]);

		if(bomb)
        {
            //meshRenderer.material = changeMat;
            //transform.GetChild(0).gameObject.SetActive(true);
            
            //this.tag = "Bomb";
            if (!GamePlayManager.Instance.isEditor)
            {
                transform.GetChild(0).GetComponent<PoopController>().SpikeOn();
            }
            else
            {
                meshRenderer.material = changeMat;
            }
        }
        else
        {
            this.tag = "Block";

            if(!GamePlayManager.Instance.isEditor)
            {
                transform.GetChild(0).GetComponent<PoopController>().SpikeOff();
            }
            else
            {
                meshRenderer.material = mat;
            }
            
            //transform.GetChild(0).gameObject.SetActive(false);
            //meshRenderer.material = mat;
        }
	}

    public void SetName()
    {
        column = int.Parse(transform.parent.name);
        row = int.Parse(transform.name);
    }

    public void SetBomb()
    {
        if(bomb)
        {
            bomb = false;
        }
        else
        {
            bomb = true;
        }
    }

    public bool GetBomb()
    {
        return bomb;
    }
}
