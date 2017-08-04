using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// Global copy of player
/// </summary>
public class PlayerHandler : MonoBehaviour{

    public static PlayerHandler Instance;
    public PlayerStatistics LocalData_Copy = new PlayerStatistics();

    public string SaveLoc = "Saves/";
    public bool IsSceneBeingLoaded = false;

    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    public void SaveData() {
        if (!Directory.Exists(SaveLoc)) {
            Directory.CreateDirectory(SaveLoc);
        }

        BinaryFormatter formatter = new BinaryFormatter();

        LocalData_Copy = PlayerState.Instance.LocalData;

        FileStream saveFile = File.Create($"{SaveLoc}{LocalData_Copy.Username}.binary");

        formatter.Serialize(saveFile, LocalData_Copy);

        saveFile.Close();
    }

    public void LoadData() {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

        LocalData_Copy = (PlayerStatistics)formatter.Deserialize(saveFile);

        saveFile.Close();
    }
}
