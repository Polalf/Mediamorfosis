using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Boton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("References")]
    [SerializeField] private Image btnImage;
    [SerializeField] private TMP_Text text;

    [Header("Default")]
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Color defaultColor = Color.white; 
    
    [Header("Select")]
    [SerializeField] private Sprite selectSprite;
    [SerializeField] private Color selecttColor = Color.black;

    void Awake()
    {
        btnImage.sprite = defaultSprite;
        if(text != null) text.color = defaultColor;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        btnImage.sprite = defaultSprite;
        if(text!= null) text.color = defaultColor;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        btnImage.sprite = selectSprite;
        if(text!= null)text.color = selecttColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        btnImage.sprite = defaultSprite;
        if(text!= null) text.color = defaultColor;
    }
}
