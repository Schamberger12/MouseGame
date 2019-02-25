using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Score ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<ThisUserScore>().IncreaseScore();
			Destroy(gameObject);
			ScoreManager.UpdateText();
		}

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
