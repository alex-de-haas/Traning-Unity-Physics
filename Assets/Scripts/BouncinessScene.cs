using Ascetic.Unity.PixelText;
using UnityEngine;

public class BouncinessScene : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public PixelTextRenderer GroundDetails;
    public PixelTextRenderer Ball1Details;
    public PixelTextRenderer Ball2Details;
    public PixelTextRenderer Ball3Details;

    private Vector3 _ball1Position;
    private Vector3 _ball2Position;
    private Vector3 _ball3Position;

    private void Awake()
    {
        _ball1Position = Ball1.transform.position;
        _ball2Position = Ball2.transform.position;
        _ball3Position = Ball3.transform.position;

        GroundDetails.Text = $"{Ground.GetComponent<Collider>().material.bounciness:f1}";
        Ball1Details.Text = $"{Ball1.GetComponent<Collider>().material.bounciness:f1}";
        Ball2Details.Text = $"{Ball2.GetComponent<Collider>().material.bounciness:f1}";
        Ball3Details.Text = $"{Ball3.GetComponent<Collider>().material.bounciness:f1}";
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ball1.transform.position = _ball1Position;
            Ball2.transform.position = _ball2Position;
            Ball3.transform.position = _ball3Position;
        }
    }
}
