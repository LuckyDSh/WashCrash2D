using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public static Vector2 Position;

    public float startMoveSpeed = 5f;
    public static float moveSpeed;
    public float moveSmooth = .3f;
    public Joystick joystick;
    private Rigidbody2D rb;

    public static Vector2 movement = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    public bool isSlowedDown = false;

    //Vector2 mousePos = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //transform.localScale = Vector3.one /** Progression.Growth*/;
        moveSpeed = startMoveSpeed /** Progression.Growth*/;

    }

    private void FixedUpdate()
    {
        //if (Progression.IsGrowing)
        //{
        //    rb.velocity = Vector2.zero;
        //    return;
        //}

        Vector2 desiredVelocity = movement * moveSpeed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);

        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

        Position = rb.position;
    }


    //public float startMoveSpeed = 5f;
    //public TouchPhase touch;

    //[Header("REFERENCES")]
    //[Space]
    //public Rigidbody2D rb;
    //public Camera cam;
    //Vector2 directon;
    //Vector2 mousePos;
    //bool isSpeededUp = false;
    //Vector2 startTouchPos;

    //// Update is called once per frame
    //void Update()
    //{
    //    directon.x = Input.GetAxis("Horizontal");
    //    directon.y = Input.GetAxis("Vertical");
    //    mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


    //    // Speed up Method
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        isSpeededUp = true;
    //        startMoveSpeed += 5f * Time.deltaTime;
    //    } else if(isSpeededUp)
    //    {
    //        isSpeededUp = false;
    //        startMoveSpeed -= 5f * Time.deltaTime;        
    //    }



    //}

    //private void FixedUpdate()
    //{

    //    Vector2 lookDir = mousePos - rb.position;

    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //                startTouchPos = touch.position;
    //                Debug.Log("Strarted....");
    //                break;
    //            case TouchPhase.Moved:
    //                directon = startTouchPos - touch.position;
    //                Debug.Log("Moving....");
    //                break;
    //            case TouchPhase.Ended:
    //                Debug.Log("Ended...");
    //                break;
    //        }
    //    }

    //    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    //    rb.rotation = angle;
    //    rb.MovePosition(rb.position + directon * startMoveSpeed * Time.fixedDeltaTime);
    //}

}
