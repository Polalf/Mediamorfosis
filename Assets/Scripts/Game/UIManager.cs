using UnityEngine;

public class UIManager : PanelsManager
{
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    
}
