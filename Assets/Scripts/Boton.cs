using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Boton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("References")]
    [SerializeField] private Image btnImage;
    [SerializeField] private TMP_Text text;
    [SerializeField] private AudioClip clip;

    [Header("Default")]
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Color defaultColor = Color.white; 
    [SerializeField] private float defScale = 1f;
    
    [Header("Select")]
    [SerializeField] private Sprite selectSprite;
    [SerializeField] private Color selecttColor = Color.black;
    [SerializeField] private float selectScale = 1.2f; 

    void Awake()
    {
        transform.localScale = new Vector3(defScale,defScale,defScale);
        btnImage.sprite = defaultSprite;
        if(text != null) text.color = defaultColor;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        btnImage.sprite = defaultSprite;
        transform.localScale = new Vector3(defScale,defScale,defScale);
        if(text!= null) text.color = defaultColor;
        if(clip != null)AudioManager.instance.PlayAudio(clip);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        btnImage.sprite = selectSprite;
        transform.localScale = transform.localScale * selectScale;
        if(text!= null)text.color = selecttColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        btnImage.sprite = defaultSprite;
        transform.localScale =  new Vector3(defScale,defScale,defScale);
        if(text!= null) text.color = defaultColor;
    }
}
