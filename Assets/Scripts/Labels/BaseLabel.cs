using Ascetic.Unity.PixelText;
using UnityEngine;

public abstract class BaseLabel : MonoBehaviour
{
    private PixelTextRenderer _label;

    private string _text;

    private void Awake()
    {
        _label = GetComponent<PixelTextRenderer>();
    }

    private void Update()
    {
        var text = GetLabelText();
        if (_text != text)
        {
            _label.Text = text;
            _text = text;
        }
    }

    protected abstract string GetLabelText();
}
