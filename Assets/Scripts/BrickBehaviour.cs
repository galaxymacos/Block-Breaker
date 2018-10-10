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

	private void OnCollisionExit2D(Collision2D other)
	{
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
