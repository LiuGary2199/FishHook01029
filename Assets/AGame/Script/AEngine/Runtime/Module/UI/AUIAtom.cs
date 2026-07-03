using UnityEngine;

public class AUIAtom : MonoBehaviour
{
    public Camera BalladUI=> transform.Find("UICamera").GetComponent<Camera>();

    public Canvas UIUnable=> transform.Find("Canvas").GetComponent<Canvas>();
    
    public Canvas UIWrongTeller=> transform.Find("EventSystem").GetComponent<Canvas>();
    
    public Transform SandalViral=> transform.Find("Canvas/Bottom");

    public Transform UIViral=> transform.Find("Canvas/UI");

    public Transform RayViral=> transform.Find("Canvas/Top");
    
    public Transform FuelViral=> transform.Find("Canvas/Tips");
    
    public Transform TellerViral=> transform.Find("Canvas/System");
    
    public AUIWavyAfar UIWavyAfar=> transform.Find("Canvas/UIMask").GetComponent<AUIWavyAfar>();
}