using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverText;
    public Text TimeText;
    public Text RecordText;

    private float _surviveTime;
    private bool _isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        _surviveTime = 0f;
        _isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isGameOver)
        {
            _surviveTime += Time.deltaTime;
            TimeText.text = $"Time: {(int)_surviveTime} sec";
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void FinishGame()
    {
        _isGameOver = true;
        GameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(_surviveTime > bestTime)
        {
            bestTime = _surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        RecordText.text = $"Best Time : {(int)bestTime} sec";
    }
}
