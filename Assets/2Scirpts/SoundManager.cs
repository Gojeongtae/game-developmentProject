using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSound;
    public AudioSource bgmSound;

    void Start()
    {
        // �ɼ� �ε�
        ConfigManager.LoadConfigData();
        // ���� ����
        sfxSound.volume = ConfigManager.currentConfig.sfxVolume;
        bgmSound.volume = ConfigManager.currentConfig.bgmVolume;
    }
}
