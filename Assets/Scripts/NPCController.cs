using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// NPC�����ĶԻ���
/// �������ݱ�д
/// </summary>
public class NPCController : MonoBehaviour
{
    private string[] Dialog;//�Ի�����������
    private int index = 0;//�����±�
    public Text dialogText;//����ui                          
    public Texture2D pointer; //���ù����ʽ(texture type Ҫ���ó� Cursor����Ч)
    public GameObject Zone; //���Box����

    private void Start()
    {
    }

    //���¶Ի�������
    public void ShowMeeage(string Name)
    {

        Cursor.lockState = CursorLockMode.None;//��ʾ���ָ��
        Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto); //�л�������ʽ
        //�����ʾ����Ϣ�����ݽ������������ֲ�ͬ������ֵ��ͬ������
        string[] Dialog01 = new string[] { "��Ϣ��.........!!!!!!!",
            "��Ϣ��XD��QWQ",
            "��Ϣ�����µ���......",
            "�ң����涼�Ƕ϶���������������������",
            "��Ϣ���һὫ�˶���Ϣ���ö�ʱ����ÿ3�����ظ�һ�Σ�ʱ�䣺1960��X��X��" };

        string[] Dialog02 = new string[] { "��Ϣ���������ⷢ�ָ��ż������ǹŴ�����.........", "�ң�����������" };

        string[] Dialog03 = new string[] { "��Ϣ�����棡����������ĹŴ����������з����˹�ȥ�ĹŴ�����",
            "��Ϣ�����ƺ������쳣���꣬������������������...�о�Ա���ˣ���Ҫҽ��......" ,
            "�ң���¼�������ֹͣ��" };

        string[] Dialog04 = new string[] {"...",
            "...",
            "..."};

        string[] Dialog05 = new string[] { "......",
            "......",
            "......" };

        string[] Dialog06 = new string[] {
            "...",
            "..."
        };


        if (Name == "Laptop01")
        {
            Dialog = Dialog01;
            // ��ʾBox
            Zone.SetActive(true);
        }

        if (Name == "Laptop02")
        {
            Dialog = Dialog02;

        }
        if (Name == "Laptop03")
        {
            Dialog = Dialog03;

        }
        if (Name == "CellPhone01")
        {
            Dialog = Dialog04;
        }

        if (Name == "NPCPolice")
        {
            Dialog = Dialog05;
        }

        if (Name == "CellPhone02")
        {
            Dialog = Dialog06;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (index < Dialog.Length)
            {
                dialogText.text = Dialog[index];
                index++;
            }
            else
            {
                index = 0;
                dialogText.text = Dialog[index];
            }
        }
    }

    //�رնԻ���ť
    public void CloseMessage()
    {
        index = 0;//�±�Ϊ0���Ի�����
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;//�������
    }



}
