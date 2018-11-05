using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour {

    float moveSpeed = 10f;
    Vector3 setPos; //new Vector3(0, 14, 0);

    // Use this for initialization
    private void Awake()
    {
        setPos = transform.position;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float distanceY = moveSpeed * Time.deltaTime;
        //this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }

    private void OnEnable()
    {
        //setPos = transform.position;
    }

    private void OnDisable()
    {
        //transform.position = setPos;
    }

    public void SpikeOn()
    {
        transform.position = new Vector3(setPos.x, Mathf.Lerp(transform.position.y,0.5f,0.3f), setPos.z);
    }

    public void SpikeOff()
    {
        transform.position = new Vector3(setPos.x, Mathf.Lerp(transform.position.y, setPos.y, 0.3f), setPos.z);
        //transform.position = setPos;
    }

    public void UISpikeOn()
    {
        transform.position = new Vector3(setPos.x, Mathf.Lerp(transform.position.y, 0.5f, 0.8f), setPos.z);
    }

    public void UISpikeOff()
    {
        transform.position = new Vector3(setPos.x, 14f, setPos.z);
        //transform.position = setPos;
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.tag == "Block")
        //{
        //    gameObject.SetActive(false);
            //SceneManager.LoadScene(0);
        //}
    }
}
