using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    public float pushForce = 10.0f;//����������
    //����Ѳ��
    public float speed = 1.0f; // �ƶ��ٶ�
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        //�����忪ʼ�ƶ�ǰִ�У���ʼ����㡢�յ㡢��ʼʱ����ܾ���
        startPoint = GameObject.Find("startPoint").transform.position;
        endPoint = GameObject.Find("endPoint").transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint, endPoint);
    }

    void Update()
    {
        //ÿ֡����һ�Σ������Ѿ��ƶ��ľ�����㵱ǰλ�ã���ͨ����ֵ������Lerp��������ƽ�����ƶ���Ŀ��λ�á���������Ѿ������յ㣬�򽻻������յ㣬�����¿�ʼ�ƶ�
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
        if (fracJourney >= 1.0f)
        {
            Vector3 temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
            startTime = Time.time;
        }
    }
    //�������򵯿�
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 pushDirection = other.transform.position - transform.position;
            pushDirection.Normalize();
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}

