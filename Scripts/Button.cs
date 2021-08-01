using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
	public void play()
	{
		SceneManager.LoadScene("Level-01");
	}
	public void exit()
	{
		Application.Quit();
		Debug.Log("Game Successfully works!");
	}
	public void restart()
	{
		SceneManager.LoadScene("Level-01");
	}
}
