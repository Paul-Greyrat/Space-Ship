using UnityEngine;

public class GameCtrl : GreyMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance;}

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => this.mainCamera;}

    protected override void Awake()
    {
        base.Awake();
        if( GameCtrl.instance != null) Debug.LogError("Only 1 instance of GameCtrl is allowed");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + " Loaded Main Camera: ", gameObject);
    }
}
