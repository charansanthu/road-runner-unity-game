using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		StartCoroutine("wait_for_platform");
	}
	IEnumerator wait_for_platform()
	{
		yield return new WaitForSeconds(5f);
		transform.Translate(new Vector3(0,0,-10 * Time.deltaTime));
		if(transform.position.z<=-50)
		{
			transform.position = new Vector3(0,0,148);
		}

    }


		
}
