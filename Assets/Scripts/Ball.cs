using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed;
	public Text scoreDisplay;
	public Transform RealtiveCamera;
	public Text gameovertext;
	public Text gameoverscore;
	public Image gameoverimage;
	public Text addtime;
	
	private float previoustime;
	private bool GameOverFlag;
	private Vector3 newSpawn;
	private float timeLeft = 30.0f;
	private Rigidbody rigid;
	private int score;
	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody>();
		score = 0;
		scoreDisplay.text = "Score - " + score.ToString() + "  Time Left - " + ((int)timeLeft).ToString("0.00");
		gameovertext.gameObject.SetActive(false);
		gameoverscore.gameObject.SetActive(false);
		gameoverimage.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplay.text = "Score - " + score.ToString() + " Time Left - " + timeLeft.ToString("0.00");
	}

    // Fixed update will have pyysics code
    void FixedUpdate ()
    {
    	if (!GameOverFlag)
    	{
			gameovertext.gameObject.SetActive(false);
			gameoverscore.gameObject.SetActive(false);
			gameoverimage.gameObject.SetActive(false);
	        float moveHorizontal = Input.GetAxis("Horizontal");
	        float moveVertical = Input.GetAxis("Vertical");

	        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);

	        rigid.AddForce ((RealtiveCamera.TransformDirection(movement))*speed);
			timeLeft -= Time.deltaTime;
			if (previoustime- timeLeft > 1 )
			{
				addtime.gameObject.SetActive(false);
			}
			if(timeLeft < 0)
			{
				GameOver();
			}
		}
    }

    // to destroy collectible
    void OnTriggerEnter(Collider other)
    {
    	if(!GameOverFlag)
    	{
			// Destroy(other.gameObject);
	    	if (other.gameObject.CompareTag("goli"))
	    	{
	    		newSpawn = new Vector3(Random.Range(-14.0f, 14.0f), (float)0.59, Random.Range(-14.0f, 14.0f));
	    		// other.gameObject.SetActive(false);
	    		other.transform.position = newSpawn;
	    		score = score + 1;
	    		timeLeft = timeLeft + 1.00f;
	    		addtime.gameObject.SetActive(true);
	    		previoustime = timeLeft;

	    	}
	    }
    }

    void GameOver(){
    	float timeLeft = 30.0f;
    	GameOverFlag = true;
    	gameoverscore.text = "Score : " + score.ToString();
		gameovertext.gameObject.SetActive(true);
		gameoverscore.gameObject.SetActive(true);
		gameoverimage.gameObject.SetActive(true);

    }

}
