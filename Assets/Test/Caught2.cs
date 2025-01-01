using TMPro;
using UnityEngine;

public class Caught2 : MonoBehaviour
{
    public GameObject Text;
    public void IveBeenCalled()
    {
        Text.GetComponent<TextMeshProUGUI>().text = "hello";
    }
}
