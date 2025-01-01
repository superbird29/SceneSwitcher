using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public Caught2 _caught2;
    // Singleton Varables

    // Singleton Varables
    //Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static GameManager2 m_Instance;

    public static GameManager2 Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(GameManager2) +
                    "' already destroyed. Returning null.");
                return null;
            }
            if (m_Instance == null)
            {
                // Search for existing instance and grabs a reference.
                m_Instance = (GameManager2)FindObjectOfType(typeof(GameManager2));
            }
            return m_Instance;
        }
    }



    public void ChangeSecene(string level_name)
    {
        StartCoroutine(StartMatch(level_name));
    }


    public IEnumerator StartMatch(string level_name)
    {
        SceneManager.LoadScene(level_name);
        yield return new WaitForEndOfFrame();

        yield return new WaitForEndOfFrame();
        GameObject ScriptObj = GameObject.Find("CaughtHolder");
        print(ScriptObj);
        if (ScriptObj != null)
        {
            _caught2 = ScriptObj.GetComponent<Caught2>();
        }
        yield return new WaitForEndOfFrame();
        _caught2.IveBeenCalled();
    }
}
