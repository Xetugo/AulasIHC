﻿using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public TextAsset m_TextFile;
    public Text m_TextUI;
    public Credits m_Credits;

    private void Start()
    {
        string json = m_TextFile.text;
        m_Credits = JsonUtility.FromJson<Credits>(json);
        StringBuilder sb = new StringBuilder();

        foreach (Function function in m_Credits.functions)
        {
            sb.Append($"<b><size={80}>{function.title}</size></b>");
            sb.Append($"<size={80}>\n</size>");
            foreach (string name in function.people)
            {
                sb.Append($"<b><size={48}>{name}</size></b>");
                sb.Append($"<size={48}>\n</size>");
            }
            sb.Append($"<size={80}>\n</size>");
        }

        m_TextUI.text = sb.ToString();
        Canvas.ForceUpdateCanvases();
    }

    public void Update()
    {
        m_TextUI.transform.Translate(Vector3.up * 80.0f * Time.deltaTime);
    }
}

[Serializable]
public class Credits
{
    public Function[] functions;
}

[Serializable]
public class Function
{
    public string title;
    public string[] people;
}
