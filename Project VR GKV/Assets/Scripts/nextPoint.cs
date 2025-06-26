using UnityEngine;
using UnityEngine.UI;

public class nextPoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button Button;
    public GameObject[] Points;

    private int index;
    void Awake()
    {
        Button.onClick.AddListener(OnClick);
    }

    void Start()
    {
        index = 0;
        Points[index].SetActive(true);
    }

    void OnClick()
    {
        Points[index].SetActive(false);

        index += 1;
        if (index >= Points.Length) index = 0;
        Points[index].SetActive(true);
    }
}
