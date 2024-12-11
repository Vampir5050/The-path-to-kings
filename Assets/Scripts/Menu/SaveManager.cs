using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
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

    string fileName = "SaveGame";

    public bool isLoading;

    public Canvas loadingScreen;

    private void Start()
    {
        jsonPathProject = Application.dataPath + Path.AltDirectorySeparatorChar;
        jsonPathPersistant = Application.persistentDataPath + Path.AltDirectorySeparatorChar;
    }
    #region -------General Section -------

    #region -------Saving Game -------
    public void SaveGame(int slotNumber)
    {
        AllGameData data = new AllGameData();
        data.playerData = GetPlayerData();

        SaveAllGameData(data,slotNumber);
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

        string[] inventory = InventorySystem.Instance.itemList.ToArray();

        return new PlayerData(playerStats, playerPosAndRot,inventory);


    }

    public void SaveGameDataToJsonFile(AllGameData gameData, int slotNumber)
    {
        string json = JsonUtility.ToJson(gameData);
        string encrypting = EncryptionDescryption(json);
        using (StreamWriter writer = new StreamWriter(jsonPathProject+fileName+slotNumber+".json"))
        {
            writer.Write(encrypting);
            print("save " + jsonPathProject);

        }
    }
    private void SaveAllGameData(AllGameData gameData, int slotNumber)
    {
        SaveGameDataToJsonFile(gameData,slotNumber);
    }

   
    #endregion

    #region -------Loading -------

    public AllGameData LoadGameDataFromJsonFile(int slotNumber)
    {
        using(StreamReader reader = new StreamReader(jsonPathProject + fileName + slotNumber + ".json"))
        {
            string json = reader.ReadToEnd();
            string descypted = EncryptionDescryption(json);
            AllGameData data = JsonUtility.FromJson<AllGameData>(descypted);
            print(jsonPathProject);
            return data;
        }
    }
    public AllGameData LoadAllGameData(int slotNumber)
    {
        AllGameData gameData = LoadGameDataFromJsonFile(slotNumber);
        return gameData;
    }

    public void LoadGame(int slotNumber)
    {
        SetPlayerData(LoadAllGameData(slotNumber).playerData);
        SoundManager.Instance.startingZoneBGMusic.Play();
        isLoading = false;
        DisableLoadingScreen();
    }

    private void SetPlayerData(PlayerData playerData)
    {
        SoundManager.Instance.startingMenuAndPause.Stop();
        isLoading = true;
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
        //inventory
        foreach(string item in playerData.inventoryContent)
        {
            InventorySystem.Instance.AddToInventory(item);
        }

    }

    public void StartLoadedGame(int slotNumber)
    {
        ActivateLoadingScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        StartCoroutine(DelayedLoading(slotNumber));
    }

    private IEnumerator DelayedLoading(int slotNumber)
    {
        yield return new WaitForSeconds(1f);

        LoadGame(slotNumber);

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

    #region -------Encryption -------

    public string EncryptionDescryption(string jsonString)
    {
        string keyword = "1234567";
        string result = "";
        for (int i = 0; i < jsonString.Length; i++)
        {
            result += (char)(jsonString[i] ^ keyword[i % keyword.Length]);
        }
        return result;
    }

    #endregion

    #region -------Utility-------
    public bool DoesFileExists(int slotNumber)
    {
        if (File.Exists(jsonPathProject+fileName+slotNumber+".json"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsSlotEmpty(int slotNumber)
    {
        if (DoesFileExists(slotNumber))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void DeselectButton()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }

    #endregion

    #region -------Loading Section -------
    public void ActivateLoadingScreen()
    {
        loadingScreen.gameObject.SetActive(true);
        Cursor.visible = false;
    }
    public void DisableLoadingScreen()
    {
        loadingScreen.gameObject.SetActive(false);
    }
    #endregion
}
