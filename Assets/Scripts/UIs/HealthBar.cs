using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealthBar : MonoBehaviour
{
    [Header("UI")]
    public Image m_BarUI;
    public Text m_ValueUI;

    [Header("Properties")]
    public float m_Value = 100.0f;
    public float m_MaxValue = 100.0f;

    [ContextMenu("Take Damage (10)")]
    public void TakeFixedDamage10()
    {
            TakeDamage(10.0f);
    }

    [ContextMenu("Heal (20)")]
    public void FixedHeal10()
    {
            Heal(20.0f);
    }

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(float damage)
    {
        m_Value -= damage;
        UpdateUI();
    }

    public void Heal(float value)
    {
        m_Value += value;
        UpdateUI();
    }

    private void UpdateUI() 
    {
        float rate = Mathf.Clamp01(m_Value / m_MaxValue);
        m_BarUI.transform.localScale = new Vector3(rate, 1.0f, 1.0f);
        if(m_ValueUI)
            m_ValueUI.text = $"{(int)m_Value}/{(int)m_MaxValue}";
    }
}
