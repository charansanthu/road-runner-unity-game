using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_spawner : MonoBehaviour
{
	public GameObject coin,Enemy;
	public Transform[] coinpos;
	int wait_for_coin = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(wait_for_coin == 0)
		{
		Instantiate(coin,coinpos[Random.Range(0,3)].position,Quaternion.identity); 
			Instantiate(Enemy,coinpos[Random.Range(0,3)].position,Quaternion.identity); 
			wait_for_coin = 50;
		}
		else
		{
			wait_for_coin -= 1;
		}
	}
}
