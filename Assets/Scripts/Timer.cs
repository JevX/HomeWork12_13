using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _totalTimeMax = 90;

    [SerializeField] private Text _timerText;

    public bool IsTimeEnd = false;
    public bool IsGameEnd = false;

    private float _currentTime = 0;

    private void Update()
    {
        if (IsGameEnd == false)
        {
            if (_currentTime > 0)
            {
                _currentTime -= Time.deltaTime;

                RefreshText(_currentTime);
            }
            else
            {
                _timerText.text = "Время вышло!";

                _currentTime = 0;

                IsTimeEnd = true;
            }
        }
    }

    private void RefreshText(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Init()
    {
        IsTimeEnd = false;
        IsGameEnd = false;

        _currentTime = _totalTimeMax;

        RefreshText(_currentTime);
    }
}