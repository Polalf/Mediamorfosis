using UnityEngine;

public class Panel : MonoBehaviour
{
    [Header("Panel Setting")]
    [SerializeField] private string m_identifier;

    public string Identifier => m_identifier;

    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    public virtual void Set(bool active)
    {
        gameObject.SetActive(active);
    }
}