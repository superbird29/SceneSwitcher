using TMPro;
using UnityEngine;

public class CaughtManager : MonoBehaviour
{
    public GameObject Text;
    public string Caught = "I've Been Caught";

    public void IveBeenCalled()
    {
        Text.GetComponent<TextMeshProUGUI>().text = Caught;
    }
}
