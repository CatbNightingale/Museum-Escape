using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dianxiang : MonoBehaviour
{
    public GameObject ball;
    public GameObject particleEffectA;
    public GameObject particleEffectB;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ����������Чa
            particleEffectA.SetActive(false);
            // ��ʾ������Чb
            particleEffectB.SetActive(true);

            // ��������
            ball.SetActive(false);
        }
    }
}

