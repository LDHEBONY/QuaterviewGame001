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
        hAxis = Input.GetAxis("Horizontal");//Axis���� �޾ƿ����� InputManager���� ������ �ؾ��Ѵ�.

        vAxis = Input.GetAxis("Vertical");
    }

    void Move()
    {
        VectorMove = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += VectorMove * speed * Time.deltaTime; // 1�ʴ� 60�������� �������� ���Ͱ��� ���ؾ� �����ϴ� ��ó�� ���´�
    }

    void Turn()
    {
        transform.LookAt(transform.position + VectorMove); // ������ ���� ����� ȸ���� �ϰ� ��
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumped == false)
            {
                rigidbody.AddForce(Vector3.up * 10.0f, ForceMode.Impulse); // ForceMode.Impulse : �������� ���� �� �� ���Ը� ������ �� ���, ForceMode.Force�� ��� �������� ���� ���� �� ���ȴ�
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
