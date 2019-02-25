using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisUserScore : MonoBehaviour
{

	public int score;

    // Start is called before the first frame update
    void Start()
    {
		score = 0;
    }

	public void IncreaseScore()
	{
		score++;
	}

	public int GetScore()
	{
		return this.score;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
