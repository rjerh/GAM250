using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    private Vector3 rayhit;
    [SerializeField] private Rigidbody rb;

    public bool throttle => Input.GetKey(KeyCode.W);
    public bool stopping => Input.GetKey(KeyCode.S);
    public bool pitchL => Input.GetKey(KeyCode.A);
    public bool pitchR => Input.GetKey(KeyCode.D);

    public float pitchPower, enginePower, engineMin, engineMax, lookRateSpeed;
    private float activeRoll, activePitch, activeYaw;

    private Vector2 lookInput, screenCentre, mouseDistance;
    private RaycastHit hit;

    [SerializeField]private float timerTarget = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        screenCentre.x = Screen.width * .5f;
        screenCentre.y = Screen.height * .5f;

    }



    private void FixedUpdate()
    {
        //only look for new target if no target
/*        if(target == null)
        {

        }*/
        // Does the ray intersect any objects
        if (Physics.SphereCast(transform.position, 8, transform.TransformDirection(Vector3.forward), out hit, 700) && hit.transform.gameObject.tag == "Target_P")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            //Debug.Log("Did Hit");
            target = hit.collider.gameObject.GetComponent<Transform>();
        }

    }

    void OnDrawGizmos()
    {
        //Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hit.point, 10);
    }

    private void Update()
    {


        //look at mouse position
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCentre.x) / screenCentre.y;
        mouseDistance.y = (lookInput.y - screenCentre.y) / screenCentre.y;

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        //Player speed acceleration and deccelration clamped between values
        enginePower = Mathf.Clamp(enginePower, engineMin, engineMax);

        if (throttle)
        {
            enginePower = Mathf.Lerp(enginePower, engineMax, 1 * Time.deltaTime) ;
        }
        if (stopping)
        {
            enginePower = Mathf.Lerp(enginePower, engineMin, 2 * Time.deltaTime);
        }
        if (pitchL)
        {
            transform.Rotate(0,0,pitchPower * Time.deltaTime);
        }
        if (pitchR)
        {
            transform.Rotate(0, 0,-pitchPower * Time.deltaTime);
        }

        rb.velocity += transform.forward * enginePower * Time.deltaTime;

        //Debug.Log(timerTarget);

        //if you cant see the target start counting down
        //if timer expires clear target
        if (target != null && target.GetComponent<Renderer>().isVisible == false)
        {
            timerTarget -= Time.deltaTime;
            timerTarget = Mathf.Clamp(timerTarget, 0, 2);

            if (timerTarget <= 0)
            {
                target = null;
                timerTarget = 1.5f;
            }
        }

    }

}
