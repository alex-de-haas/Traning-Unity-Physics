using UnityEngine;

public class WallStoper : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
    }
}