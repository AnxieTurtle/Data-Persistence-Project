using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuUIHandler : MonoBehaviour{
    [SerializeField] Text bestScoreText;
    private void Start() {
        ShowNameScore();
        PlayerNameScore.Instance.SetName();
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
    public void ShowNameScore() {
        bestScoreText.text = $"Best Score : {PlayerNameScore.Instance.playerNameBest} : {PlayerNameScore.Instance.playerScore}";
    }
}
