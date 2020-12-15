using UnityEngine;

public class DragLabel : BaseLabel
{
    public Rigidbody Rigidbody;

    protected override string GetLabelText()
    {
        return $"{Rigidbody.drag}";
    }
}
