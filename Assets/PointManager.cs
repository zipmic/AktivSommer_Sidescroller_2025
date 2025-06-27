using UnityEngine;

public class PointManager : MonoBehaviour
{
	public static PointManager instance;
	public int points = 0;

	private void Awake()
	{
		instance = this;
	}

	public void AddPoint()
	{
		points++;
		Debug.Log("Points: " + points);
	}
}


