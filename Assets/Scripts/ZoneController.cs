using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public Transform target;      // ����Box��Transform���
    public float attractSpeed;    // �����ٶ�
    public float attractTime;     // ����ʱ��
    public float waitTime;        // ֹͣ����ʱ��
    public ParticleSystem attractEffect; // ��ұ�����ʱ���ŵ���Ч

    private bool isAttracting = false;
    private float currentTime = 0f;
    private bool isPlayerControlled = true; // ���һ��bool���͵ı������ڿ�������Ƿ�ɱ��ٿ�

    private void Start()
    {
        // �ڿ�ʼʱ����������Ч
        attractEffect.Stop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && target != null)
            {
                if (isAttracting) // ����������
                {
                    currentTime += Time.deltaTime;
                    if (currentTime <= attractTime) // ������ʱ����
                    {
                        // ���㵱ǰλ�õ�Ŀ��λ�õ�����
                        Vector3 direction = target.position - rb.position;

                        // ���㱾֡��Ҫ�ƶ��ľ���
                        float distanceThisFrame = attractSpeed * Time.deltaTime;

                        // ����һ������������ƶ�������Box��λ��
                        rb.MovePosition(rb.position + direction.normalized * distanceThisFrame);

                        // ����������Ч
                        if (!attractEffect.isPlaying)
                        {
                            attractEffect.Play();
                        }
                    }
                    else // ��������ʱ��
                    {
                        isAttracting = false;
                        currentTime = 0f;

                        // ֹͣ�������ʱ����isPlayerControlled����Ϊtrue��������ұ��ٿ�
                        isPlayerControlled = true;

                        // ֹͣ����������Ч
                        attractEffect.Stop();
                    }
                }
                else // ����������
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= waitTime) // �ȴ�ʱ���Ѿ���ȥ
                    {
                        isAttracting = true;
                        currentTime = 0f;

                        // ��������״̬ʱ����isPlayerControlled����Ϊfalse����ֹ��ұ��ٿ�
                        isPlayerControlled = false;
                    }
                }

                // ��isPlayerControlledΪfalseʱ��������ҵ��ƶ�����ת
                other.GetComponent<CharacterControl>().enabled = isPlayerControlled;
            }
        }
    }
}