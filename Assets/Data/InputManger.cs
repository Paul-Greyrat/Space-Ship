using UnityEngine;

public class InputManger : MonoBehaviour
{
    private static InputManger instance;
    public static InputManger Instance { get => instance;}
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos;}

    [SerializeField] protected float onFiring;
    public float OnFiring => onFiring;
 
    private void Awake()
    {
        if (InputManger.instance != null)
        {
            Debug.LogError("InputManger already exits");
        }
        InputManger.instance = this;
    }

    void FixedUpdate()
    {
        this.GetMousePos();
        this.GetMouseHold();
    }

    protected virtual void GetMouseHold()
    {
        onFiring = Input.GetAxis("Fire1"); // giữ chuột liên tục
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
