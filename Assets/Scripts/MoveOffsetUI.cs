using UnityEngine;
using UnityEngine.UI;

public class MoveOffsetUI : MonoBehaviour
{
    public Vector2 m_Axis = Vector2.right;
    public Vector2 m_Tile = Vector2.one;
    public float m_ScrollSpeed = 0.5f;

    private RawImage m_Image;

    private void Awake()
    {
        m_Image = GetComponent<RawImage>();
    }

    private void Update()
    {
        float offset = Time.time * m_ScrollSpeed;
        m_Image.uvRect = new Rect(m_Axis * offset, m_Tile);
    }
}
