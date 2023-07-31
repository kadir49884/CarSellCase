using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using KadirExtension;
using KadirExtension.Managers;
using System.IO;
using UnityEditor;

public class GameManager : MonoBehaviour
{

	private bool IsGameFinish { get; set; }
	private bool IsGameStarted { get; set; }

	public Action GameStart { get; set; }

	public Action GameWin { get; set; }
	public Action GameFail { get; set; }

	public bool RunGame { get => IsGameStarted && !IsGameFinish; }


	public static GameManager Instance { get => instance; set => instance = value; }

	private static GameManager instance;

	[SerializeField]
	private bool isReadyForLevel;

	public ScriptableManager[] managers;
	public LevelManager LevelManager { get; private set; }
	public ParticleManager ParticleManager { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		if (isReadyForLevel)
		{
			GetLevel();
		}
	}

	private void Start()
	{

		GameStart += Initialize;
		GameWin += Game_Win;
		GameFail += Game_Fail;
		ParticleManager = (ParticleManager)managers.Find(manager => manager.name.Contains("ParticleManager"));
	}

	private void GetLevel()
	{
		//getPath = Path.Combine("ScriptableObjects", "LevelManager");
		//LevelManager levelManager = Resources.Load<LevelManager>(getPath);
		LevelManager = (LevelManager)managers.Find(manager => manager.name.Contains("LevelManager"));
		LevelManager.Initialize();
	}


	public void Initialize()
	{
		IsGameStarted = true;
	}

	private void Game_Win()
	{
		IsGameFinish = true;
	}


	private void Game_Fail()
	{
		IsGameFinish = true;
	}

	public void NextLevel()
	{
		PlayerPrefsManager.LevelNext();
		RestartLevel();
		GetLevel();
	}
	public void PreviousLevel()
	{
		PlayerPrefsManager.PreviousLevel();
		RestartLevel();
		GetLevel();
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


    private void Update()
	{
        if (Input.GetKeyDown(KeyCode.R))
            RestartLevel();
	}


}



