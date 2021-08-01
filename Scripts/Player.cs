using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public Text scoreText,distanceText;
	Rigidbody rb;
	Animator myAnime;
	AudioSource myAudio;
	int score = 0,distance = 0,health = 3;
    // Start is called before the first frame update
    void Start()
    {
		myAnime = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow)&& (transform.position.x==0||transform.position.x==-2))
		{
			transform.position=new Vector3(transform.position.x+2,0.29f,0);   

		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)&& (transform.position.x==0||transform.position.x==2))
		{
			transform.position=new Vector3(transform.position.x-2,0.29f,0);
		}

		StartCoroutine("wait_for_player");
    }
	IEnumerator wait_for_player()

	{
		yield return new WaitForSeconds(5f);
		if(Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y==0)
		{
			myAnime.SetTrigger("Jump");
			rb.velocity = new Vector3(0,5f,0);
			//transform.Translate(new Vector3(0,1f,0));
			//myAnime.SetBool("jump",true);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			myAnime.SetTrigger("roll");
			//myAnime.SetBool("roll",true);

		}
		distance += 1;
		distanceText.text = "Distance: " + distance + "m";
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="coin")
		{
			myAudio.Play();
			score += 10;
			scoreText.text = "score:" + score; 
			Destroy(other.gameObject);
			//Destroy(gameObject);
		}
		if(other.gameObject.tag == "Enemy")
		{
			health -=1;
			if(health == 0)
			{
				SceneManager.LoadScene("Gameover");
			  Destroy(gameObject);
			}
		}
	}

	public void RightMove()
	{
		if(transform.position.x==0||transform.position.x==-2)
		{
			transform.position=new Vector3(transform.position.x+2,0.29f,0);   

		}
	}

	public void LeftMove()
	{
		if(transform.position.x==0||transform.position.x==2)
		{
			transform.position=new Vector3(transform.position.x-2,0.29f,0);
		}
	}
}
