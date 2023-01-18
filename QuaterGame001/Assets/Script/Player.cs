using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    Vector3 VectorMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
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
}
