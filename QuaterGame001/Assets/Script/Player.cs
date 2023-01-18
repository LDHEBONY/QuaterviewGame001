using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    Vector3 VectorMove;

    public bool jumped = false;

    [SerializeField]
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");//Axis값을 받아오려면 InputManager에서 설정을 해야한다.

        vAxis = Input.GetAxis("Vertical");
    }

    void Move()
    {
        VectorMove = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += VectorMove * speed * Time.deltaTime; // 1초당 60프레임의 움직임을 벡터값에 곱해야 수렴하는 값처럼 나온다
    }

    void Turn()
    {
        transform.LookAt(transform.position + VectorMove); // 벡터의 더한 값대로 회전을 하게 됨
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumped == false)
            {
                rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Impulse); // ForceMode.Impulse : 순간적인 힘을 줄 때 무게를 적용할 때 사용, ForceMode.Force의 경우 연속적인 힘을 가할 때 사용된다
                jumped = true;
            }           
        }  
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            jumped = false;
        }
    }
}
