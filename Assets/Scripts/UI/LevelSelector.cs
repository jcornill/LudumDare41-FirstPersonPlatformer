using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	public void LoadLevel(int level)
	{
		SceneManager.LoadScene (level);
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public static void LoadLevelStatic(int level)
	{
		SceneManager.LoadScene (level);
	}
}
