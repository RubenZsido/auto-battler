using UnityEngine;

public class Messenger : MonoBehaviour
{
    public static Messenger Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Log(string message)
    {
        Debug.Log(message);
    }
    public void Warning(string message)
    {
        Debug.LogWarning(message);
    }
}
