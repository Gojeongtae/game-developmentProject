using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ConfigManager
{
    [Serializable]
    public class Config
    {
        public int resolution = 1;
        public float sfxVolume = .5f;
        public float bgmVolume = .5f;
    }
    public static Config defaultConfig = new Config();
    public static Config currentConfig = new Config();

    public static void RemoveConfigData()
    {
        PlayerPrefs.DeleteKey("Config");
    }

    public static Config ReadConfigData()
    {
        string data;
        Config temp;

        try
        {
            // ���ڿ� ������ �ε�
            data = PlayerPrefs.GetString("Config");

            // �� �����Ͱ� �ƴ� ���
            if (!string.IsNullOrEmpty(data))
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();

                // ���ڿ� �����͸� Byte �迭 ���·� ��ȯ
                ms = new MemoryStream(Convert.FromBase64String(data));
                temp = (Config)bf.Deserialize(ms);

                return temp;
            }
        }
        catch { }

        return null;
    }

    public static void SaveConfigData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();

        // �����͸� Byte �迭 ���·� ��ȯ
        bf.Serialize(ms, currentConfig);
        // ���ڿ��� ��ȯ�Ͽ� ����
        PlayerPrefs.SetString("Config", Convert.ToBase64String(ms.GetBuffer()));
    }

    public static void LoadConfigData()
    {
        string data;

        try
        {
            // ���ڿ� ������ �ҷ���
            data = PlayerPrefs.GetString("Config");

            // �� �����Ͱ� �ƴ� ���
            if (!string.IsNullOrEmpty(data))
            {
                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();

                // ���ڿ� �����͸� Byte �迭 ���·� ��ȯ
                ms = new MemoryStream(Convert.FromBase64String(data));
                currentConfig = (Config)bf.Deserialize(ms);
            }
        }
        catch { }
    }
}
