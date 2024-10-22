using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Find instance");
                instance = FindObjectOfType<T>();
            }
            
            if (instance == null)
            {
                Debug.Log("Couldn't find instance. So make new one.");
                GameObject go = new GameObject(typeof(T).Name);

                instance = go.AddComponent<T>();
            }

            Debug.Log("Return instance");
            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}