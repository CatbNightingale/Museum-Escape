using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public GameObject uiPanel; // ���UI�������
    public Texture2D pointer; //���ù����ʽ(texture type Ҫ���ó� Cursor����Ч)
    public Slider volumeSlider;
    public AudioSource bgmAudioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiPanel.SetActive(true); // ��ʾUI����
            Cursor.lockState = CursorLockMode.None;//��ʾ���ָ��
            Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto); //�л�������ʽ
            Time.timeScale = 0; // ��ͣ��Ϸ
        }
    }

    private void Start()
    {
        // ������ק���ĳ�ʼֵΪ������������
        volumeSlider.value = bgmAudioSource.volume;
    }

    // ��ק����ֵ�����ı�ʱ���õķ���
    public void OnVolumeSliderChanged(float value)
    {
        // ���ñ�����������Ϊ��ק����ֵ
        bgmAudioSource.volume = value;
    }

    // ����UI����ķ���
    public void HideUIPanel()
    {
        uiPanel.SetActive(false); //����UI����
        Cursor.lockState = CursorLockMode.Locked;//�������
        Time.timeScale = 1; // �ָ���Ϸ
    }

    // �˳���Ϸ�ķ���
    public void QuitGame()
    {
        Application.Quit();
    }
}

