using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text scoreText;
	public GameObject[] Players;
	public int MaxScore;
	public int Score1;
	public int Score2;
	public int Score3;
	
    // Start is called before the first frame update
    void Start()
    {
		scoreText.text = "Player1 Score: 0" + "\nPlayer2 Score: 0" + "\nPlayer3 Score: 0";

    }

	public void UpdateText()
	{
		Score1 = Players[0].GetComponent<ThisUserScore>().GetScore();
		//Score2 = Players[1].GetComponent<ThisUserScore>().GetScore();
	//	Score3 = Players[2].GetComponent<ThisUserScore>().GetScore();
		if(Score1/*+Score2+Score3*/ == MaxScore)
		{
			//DetermineWinner(Score1, Score2, Score3);
			DisplayWinner(0);
		}
		scoreText.text = "Player1 Score: " + Score1.ToString();// + "\nPlayer2 Score: " + Score2.ToString() + "\nPlayer3 Score: " + Score3.ToString();
	}

	public void DetermineWinner(int Player1, int Player2, int Player3)
	{
		if (Player1 > Player2)
		{
			if(Player1 > Player3)
			{
				DisplayWinner(0);
			}
			else
			{
				DisplayWinner(2);
			}
		}
		else
		{
			if(Player2 > Player3)
			{
				DisplayWinner(1);
			}
			else
			{
				DisplayWinner(3);
			}
		}

	}

	public void DisplayWinner(int Player)
	{
		switch (Player)
		{
			case 0:
				scoreText.text = "Winner: Player 1";
				break;
			case 1:
				scoreText.text = "Winner: Player 2";
				break;
			case 2:
				scoreText.text = "Winner: Player 1";
				break;
			default:
				break;
		}

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
