using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TittleScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI username;
    [SerializeField] private TextMeshProUGUI bestScore;
    // Start is called before the first frame update
    private void Start()
    {
        if (DataManager.Instance.isThereSavedData())
        {
            DataManager.Instance.LoadScore();
            bestScore.text = DataManager.Instance.BestScoreUsername + ": " + DataManager.Instance.BestScore;
        }
    }
    private void ResetLeaderboard()
    {
        DataManager.Instance.DeleteData();
            bestScore.text = "Best Score: 0";
    }
    public void GameStart()
    {
        DataManager.Instance.username = username.text;
        SceneManager.LoadScene(1);
    }
    public void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
