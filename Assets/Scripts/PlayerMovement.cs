using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player_rb;

    [Header("Movement Properties:")]
    [SerializeField] private float thrust = 10.0f;
    [SerializeField] private float minThrust = 0.1f;
    [SerializeField] private float maxThrust = 300.0f;
    [SerializeField] private float accelerationRate = 100.0f;
    [SerializeField] private float decelerationRate = 100.0f;
    [SerializeField] private float turnSpeed = 10.0f;

    [Header("Rotation Properties:")]
    [SerializeField] private float torque = 0.1f;
    [SerializeField] private float minTorque = 0.01f;
    [SerializeField] private float maxTorque = 1.0f;
    [SerializeField] private float torqueIncreaseRate = 0.5f;
    [SerializeField] private float torqueDecreaseRate = 1.0f;

    [HideInInspector] public bool playerIsRotating;

    PlayerInput playerInput;


    void Start()
    {
        OnStart();
    }


    private void Update()
    {
        CalculateAcceleration();
        CalculateRotationTorque();
    }


    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, player_rb.velocity * 500.0f);

        //Moves player forward as long as Left Shift is held down;
        player_rb.AddForce(transform.forward * thrust, ForceMode.Acceleration);

        RotationX();
        RotationY();
        RotationZ();
    }


    private void OnStart() 
    {
        playerInput = GetComponent<PlayerInput>();
        player_rb = GetComponent<Rigidbody>();
        thrust = minThrust;
        torque = minTorque;
        playerIsRotating = false;
    }


    private void CalculateAcceleration()
    {
        if (playerInput.leftShift_isHeldDown)
        {
            //Acceleration;
            if (thrust >= maxThrust)
                return;
            else if (thrust < maxThrust)
                thrust += accelerationRate * Time.deltaTime;
        }
        else
        {
            //Deceleration;
            if (thrust <= minThrust)
                return;
            else if (thrust > minThrust)
                thrust -= decelerationRate * Time.deltaTime;
        }
    }


    private void CalculateRotationTorque()
    {
        if (playerIsRotating)
        {
            if (torque >= maxTorque)
                return;
            else if (torque < maxTorque)
                torque += torqueIncreaseRate * Time.deltaTime;
        }
        else
            if (torque <= minTorque)
            return;
        else if (torque > minTorque)
            torque -= torqueDecreaseRate * Time.deltaTime;
    }


    private void RotationX() 
    {
        //Rotates player up and down;
        float relativeTurnSpeed;
        if (playerInput.w_isHeldDown || playerInput.s_isHeldDown)
        {
            playerIsRotating = true;

            if (playerInput.w_isHeldDown)
            {
                relativeTurnSpeed = torque * 1.0f;
            }
            else if (playerInput.s_isHeldDown)
            {
                relativeTurnSpeed = torque * -1.0f;
            }
            else
            {
                relativeTurnSpeed = 0.0f;
            }
            player_rb.AddTorque(transform.right * relativeTurnSpeed * 1.0f);
        }
    }


    private void RotationY()
    {
        //Rotates player left and right;
        float relativeTurnSpeed;
        if (playerInput.a_isHeldDown || playerInput.d_isHeldDown)
        {
            playerIsRotating = true;

            if (playerInput.a_isHeldDown)
            {
                relativeTurnSpeed = torque * -1.0f;
            }
            else if (playerInput.d_isHeldDown)
            {
                relativeTurnSpeed = torque * 1.0f;
            }
            else
            {
                relativeTurnSpeed = 0.0f;
            }
            player_rb.AddTorque(transform.up * relativeTurnSpeed * 1.0f);
        }
    }


    private void RotationZ()
    {
        //Tilts player left and right;
        float relativeTurnSpeed;
        if (playerInput.q_isHeldDown || playerInput.e_isHeldDown)
        {
            playerIsRotating = true;

            if (playerInput.q_isHeldDown)
            {
                relativeTurnSpeed = torque * 1.0f;
            }
            else if (playerInput.e_isHeldDown)
            {
                relativeTurnSpeed = torque * -1.0f;
            }
            else
            {
                relativeTurnSpeed = 0.0f;
            }
            player_rb.AddTorque(transform.forward * relativeTurnSpeed * 1.0f);
        }
    }
}