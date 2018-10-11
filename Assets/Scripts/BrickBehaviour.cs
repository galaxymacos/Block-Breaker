using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{

	[SerializeField] private GameObject powerUp;
	[SerializeField] private int PowerUPPercentage = 20;
	private GameObject ball;
	
	private GameManager code;
	// Use this for initialization
	void Start () {
		code = GameObject.Find("GameManager").GetComponent<GameManager>();
		code.AddBlock();
		ball = GameObject.Find("ball");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Vector2 ballOriSpeed;
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		ballOriSpeed = ball.GetComponent<Rigidbody2D>().velocity;
		
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (code.fireballTime > 0)
		{
			ball.GetComponent<Rigidbody2D>().velocity = ballOriSpeed;	// keep the original speed
			code.fireballTime--;
		}
		float destiny = Random.Range(1, 100);
		Debug.Log(destiny);
		if (destiny > 0 && destiny <= PowerUPPercentage)
		{
			Instantiate(powerUp, ball.transform.position,Quaternion.identity);
		}
		Destroy(gameObject);
		code.AddPoints();	
	}

	
}
