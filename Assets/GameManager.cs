using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CaughtManager _caughtManager;

    private static bool m_ShuttingDown = false;
    private static GameManager m_Instance;

    public static GameManager Instance
    {
        get
        {
            if(m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance" + typeof(GameManager) + " Already destroyed. REturing null.");
                return null;
            }
            if(m_Instance == null)
            {
                m_Instance = (GameManager)FindAnyObjectByType(typeof(GameManager));
            }
            return m_Instance;
        }
    }

    /// <summary>
    /// takes in name of level and calls the coroutine startmatch
    /// </summary>
    /// <param name="Level_name"></param>
    public void ChangeSecen(string Level_name)
    {
        StartCoroutine(StartMatch(Level_name));
    }

    public IEnumerator StartMatch(string Level_name)
    {
        SceneManager.LoadScene(Level_name);
   
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        GameObject Script = GameObject.Find("CaughtManager");
        print(Script);
        if(Script != null)
        {
            _caughtManager = Script.GetComponent<CaughtManager>();
        }
        yield return new WaitForEndOfFrame();
        Instance._caughtManager.IveBeenCalled();

    }
}
