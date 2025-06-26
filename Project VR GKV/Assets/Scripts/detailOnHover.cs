using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class detailOnHover : MonoBehaviour
{
    public GameObject frame;
    public GameObject show;
    public GameObject notShow1;
    public GameObject notShow2;
    public GameObject notShow3;
    public GameObject notShow4;
    public GameObject notShow5;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable hoverInteractable;

    void Awake()
    {
        hoverInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        if (hoverInteractable == null)
        {
            Debug.LogWarning("XRSimpleInteractable not found on " + gameObject.name);
            return;
        }

        if (notShow4 == null) notShow4 = notShow3;
        if (notShow5 == null) notShow5 = notShow3;

        hoverInteractable.hoverEntered.AddListener(onHover);
        hoverInteractable.hoverExited.AddListener(onExit);
    }
    void OnDestroy()
    {
        if (hoverInteractable != null)
        {
            hoverInteractable.hoverEntered.RemoveListener(onHover);
            hoverInteractable.hoverExited.RemoveListener(onExit);
        }
    }

    private void onHover(HoverEnterEventArgs args)
    {
        if (!(notShow1.activeSelf || notShow2.activeSelf || notShow3.activeSelf || notShow4.activeSelf || notShow5.activeSelf))
        {
            frame.SetActive(true);
            show.SetActive(true);
        }
    }

    private void onExit(HoverExitEventArgs args)
    {
        show.SetActive(false);
        frame.SetActive(false);
    }
}
