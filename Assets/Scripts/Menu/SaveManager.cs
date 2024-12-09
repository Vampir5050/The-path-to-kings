using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    string jsonPathProject;
    string jsonPathPersistant;

    private void Start()
    {
        jsonPathProject = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveGame.json";
        jsonPathPersistant = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveGame.json";
    }
    #region -------General Section -------

    #region -------Saving Game -------
    public void SaveGame()
    {
        AllGameData data = new AllGameData();
        data.playerData = GetPlayerData();

        SaveAllGameData(data);
    }

 
    private PlayerData GetPlayerData()
    {
        float playerStats = PlayerState.Instance.currentHealth;
        float[] playerPosAndRot = new float[6];
        playerPosAndRot[0] = PlayerState.Instance.playerBody.transform.position.x;
        playerPosAndRot[1] = PlayerState.Instance.playerBody.transform.position.y;
        playerPosAndRot[2] = PlayerState.Instance.playerBody.transform.position.z;

        playerPosAndRot[3] = PlayerState.Instance.playerBody.transform.rotation.x;
        playerPosAndRot[4] = PlayerState.Instance.playerBody.transform.rotation.y;
        playerPosAndRot[5] = PlayerState.Instance.playerBody.transform.rotation.z;

        return new PlayerData(playerStats, playerPosAndRot);


    }

    public void SaveGameDataToJsonFile(AllGameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        using (StreamWriter writer = new StreamWriter(jsonPathProject))
        {
            writer.Write(json);
            print(jsonPathProject);

        }
    }
    private void SaveAllGameData(AllGameData gameData)
    {
        SaveGameDataToJsonFile(gameData);
    }

   
    #endregion

    #region -------Loading -------

    public AllGameData LoadGameDataFromJsonFile()
    {
        using(StreamReader reader = new StreamReader(jsonPathProject))
        {
            string json = reader.ReadToEnd();
            AllGameData data = JsonUtility.FromJson<AllGameData>(json);
            print(jsonPathProject);
            return data;
        }
    }
    public AllGameData LoadAllGameData()
    {
        AllGameData gameData = LoadGameDataFromJsonFile();
        return gameData;
    }

    public void LoadGame()
    {
        SetPlayerData(LoadAllGameData().playerData);
    }

    private void SetPlayerData(PlayerData playerData)
    {
        PlayerState.Instance.currentHealth = playerData.playerStats;

        Vector3 loadedPosition;
        loadedPosition.x = playerData.playerPositionAndRotation[0];
        loadedPosition.y = playerData.playerPositionAndRotation[1];
        loadedPosition.z = playerData.playerPositionAndRotation[2];

        PlayerState.Instance.playerBody.transform.position = loadedPosition;


        Vector3 loadedRotation;
        loadedRotation.x = playerData.playerPositionAndRotation[3];
        loadedRotation.y = playerData.playerPositionAndRotation[4];
        loadedRotation.z = playerData.playerPositionAndRotation[5];

        PlayerState.Instance.playerBody.transform.rotation = Quaternion.Euler(loadedRotation);

    }

    public void StartLoadedGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        StartCoroutine(DelayedLoading());
    }

    private IEnumerator DelayedLoading()
    {
        yield return new WaitForSeconds(1f);

        LoadGame();

    }
    #endregion
    #endregion
 

    #region -------Settings Section -------


    #region -------Volume Settings -------
    [Serializable]
    public class VolumeSettings
    {
        public float master;
        public float music;
        public float effects;
    }
    #endregion
    #endregion
}
