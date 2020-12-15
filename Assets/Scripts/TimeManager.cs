using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float ScaleDelta = 0.1f;
    public float MinScale = 0.1f;
    public float MaxScale = 1f;
    public Text TimeScaleUI;
    public bool IsPaused = false;

    private float _scale = 1f;

    private void Awake()
    {
        SetTimeScale();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsPaused = !IsPaused;
            SetTimeScale();
        }
        if (Input.mouseScrollDelta.y != 0f)
        {
            _scale += Input.mouseScrollDelta.y * ScaleDelta;
            _scale = Mathf.Clamp(_scale, MinScale, MaxScale);
            SetTimeScale();
        }
    }

    private void SetTimeScale()
    {
        var scale = IsPaused ? 0f : _scale;
        Time.timeScale = scale;
        Time.fixedDeltaTime = scale * 0.02f;
        if (TimeScaleUI != null)
        {
            TimeScaleUI.text = $"Time scale: {_scale:f1}";
            if (IsPaused)
            {
                TimeScaleUI.text += " (PAUSE)";
            }
        }
    }
}