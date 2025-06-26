using UnityEngine;
using UnityEngine.UI;

public class mapImage : MonoBehaviour
{
    public Sprite Map_zoomIn;
    public Sprite Map_normal;
    public Sprite Map_zoomOut;
    public Sprite Sattelite_zoomIn;
    public Sprite Sattelite_normal;
    public Sprite Sattelite_zoomOut;
    public Button Button;

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
        Button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Toggle between Map zoom in and out
        if (img.sprite == Map_zoomOut)
        {
            img.sprite = Map_normal;
        }
        else if (img.sprite == Map_normal)
        {
            img.sprite = Map_zoomIn;
        }
        else if (img.sprite == Map_zoomIn)
        {
            img.sprite = Map_zoomOut;
        }
        else if (img.sprite == Sattelite_zoomOut)
        {
            img.sprite = Sattelite_normal;
        }
        else if (img.sprite == Sattelite_normal)
        {
            img.sprite = Sattelite_zoomIn;
        }
        else if (img.sprite == Sattelite_zoomIn)
        {
            img.sprite = Sattelite_zoomOut;
        }
    }

    public void changeView()
    {
        if (img.sprite == Map_zoomIn)
        {
            img.sprite = Sattelite_zoomIn;
        }
        else if (img.sprite == Map_zoomOut)
        {
            img.sprite = Sattelite_zoomOut;
        }
        else if (img.sprite == Map_normal) 
        { 
            img.sprite = Sattelite_normal;
        }
        else if (img.sprite == Sattelite_zoomIn)
        {
            img.sprite = Map_zoomIn;
        }
        else if (img.sprite == Sattelite_zoomOut)
        {
            img.sprite = Map_zoomOut;
        } else if (img.sprite == Sattelite_normal) 
        { 
            img.sprite = Map_normal;
        }
    }
}
