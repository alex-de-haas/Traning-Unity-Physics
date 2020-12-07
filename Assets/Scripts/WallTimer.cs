using UnityEngine;
using UnityEngine.UI;

public class WallTimer : MonoBehaviour
{
    public Text TimerText;

    private float _seconds = 0f;
    private bool _timerActive = true;

    private void Update()
    {
        if (_timerActive)
        {
            _seconds += Time.deltaTime;
        }
        TimerText.text = $"Timer: {_seconds:f2}";
    }

    private void OnCollisionEnter(Collision other)
    {
        _timerActive = false;
    }
}