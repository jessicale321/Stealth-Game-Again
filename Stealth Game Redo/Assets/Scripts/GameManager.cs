using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
	public class GameManager : MonoBehaviour
	{
		// Statically referencable Singleton instance.
		public static GameManager instance;
		
		public GameObject endGameScreenUI;
		private static float restartWaitTime = 2.4f;

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Debug.LogError("Cannot have two Singletons in the same scene!");
				Destroy(this.gameObject);
			}
		}

		private void OnDestroy()
		{
			if (this == GameManager.instance)
			{
				GameManager.instance = null;
			}
		}
		
		public void CompleteLevel() 
		{
			Debug.Log("show end level");
			endGameScreenUI.SetActive(true); // enable UI
			Time.timeScale = 0;
		}
		
		public static IEnumerator ReloadLevel() 
		{
			yield return new WaitForSeconds(restartWaitTime);
			Debug.Log("Reloading");
			SceneManager.LoadScene(1);
		}
		
	}
}