using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameScore : MonoBehaviour {
    public static PlayerNameScore Instance;
    [HideInInspector] public string playerName;
    [HideInInspector] public string playerNameBest;
    [HideInInspector] public int playerScore;
    [SerializeField] InputField inputField;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadNameScore();
        }
    }

    public void OnEnterPlayerName() {
        playerName = inputField.text;
        Debug.Log(playerName);
    }

    public void SetName() {
        inputField.text = playerName;
    }



    [System.Serializable]
    class SaveData {
        public string playerName;
        public string playerNameBest;
        public int playerScore;
    }

    public void SaveNameScore() {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerNameBest = playerNameBest;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            playerNameBest = data.playerNameBest;
            playerScore = data.playerScore;
        }
    }
}
