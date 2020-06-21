using UnityEngine;

public class Loop : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed;
    private float _angularSpeed;
    public Vector3 Force { get; set; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Force = transform.eulerAngles += new Vector3(0 ,0, 1) * (Time.deltaTime * speed);
    }
}
