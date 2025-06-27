using UnityEngine;

public class Point : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PointManager.instance.AddPoint();
			Destroy(gameObject);
		}
	}
}


