using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public TagBehaviour Player1;
    public TagBehaviour Player2;
    public int ScoreAmountToSwitch = 100;
    public int SwitchAfter = 5;
    public Text WinText;
    public string NextScene;

    private bool _winnerFound;
    private float _time;

    // Update is called once per frame
    void Update()
    {
        if (!_winnerFound)
        {
            if (Player1.Score > Player2.Score + ScoreAmountToSwitch)
            {
                _winnerFound = true;
                //if player 1 wins
                Player1.gameObject.GetComponent<InputBehaviour>().enabled = false;
                Player2.gameObject.GetComponent<InputBehaviour>().enabled = false;
                WinText.text = "Player 1 wins";
            }

            if (Player2.Score > Player1.Score + ScoreAmountToSwitch)
            {
                _winnerFound = true;
                //if player 2 wins
                Player1.gameObject.GetComponent<InputBehaviour>().enabled = false;
                Player2.gameObject.GetComponent<InputBehaviour>().enabled = false;
                WinText.text = "Player 2 wins";
            }
        }
        else
        {
            _time += Time.deltaTime;
            if (_time > SwitchAfter)
            {
                SceneManager.LoadScene(NextScene,LoadSceneMode.Single);
            }
        }
    }
}
