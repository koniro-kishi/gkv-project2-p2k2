using UnityEngine;

public class changePoint : MonoBehaviour
{
    public GameObject[] Points;

    private int index;
    void Start()
    {
        index = 0;
        Points[index].SetActive(true);
    }

    // Update is called once per frame
    public void next()
    {
        Points[index].SetActive(false);
        index++;
        if (index == Points.Length) index = 0;
        Points[index].SetActive(true);
    }

    public void prev()
    {
        Points[index].SetActive(false);
        index--;
        if (index == -1) index = Points.Length - 1;
        Points[index].SetActive(true);
    }
}
