using UnityEngine;

public enum ShootType
{
    Force = 1,
    ForceAtPoint = 2,
    ExplosionForce = 3,
}

public enum ShootMode
{
    Press = 1,
    Click = 2,
}

public class PlayerShoot : MonoBehaviour
{
    public ShootType ShootType = ShootType.ForceAtPoint;
    public ShootMode ShootMode = ShootMode.Press;
    public float Force = 100f;
    public float ExplosionRadius = 5f;

    private bool _shoot = false;

    void Update()
    {
        if ((ShootMode == ShootMode.Click && Input.GetKeyDown(KeyCode.Mouse0)) || (ShootMode == ShootMode.Press && Input.GetKey(KeyCode.Mouse0)))
        {
            _shoot = true;
        }
    }

    void FixedUpdate()
    {
        if (_shoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log($"Raycast hit: {hit.distance}");
                if (ShootType == ShootType.ExplosionForce)
                {
                    var colliders = Physics.OverlapSphere(hit.point, ExplosionRadius);
                    foreach (var collider in colliders)
                    {
                        var rb = collider.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(Force, hit.point, ExplosionRadius);
                        }
                    }
                }
                if (hit.rigidbody != null)
                {
                    if (ShootType == ShootType.ForceAtPoint)
                    {
                        hit.rigidbody.AddForceAtPosition(Force * transform.forward, hit.point);
                    }
                    if (ShootType == ShootType.Force)
                    {
                        hit.rigidbody.AddForce(Force * transform.forward);
                    }
                }
            }
            _shoot = false;
        }
    }
}