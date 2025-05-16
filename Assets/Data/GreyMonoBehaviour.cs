using UnityEngine;

public class GreyMonoBehaviour : MonoBehaviour
{

    protected virtual void Start()
    {
        //For override
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValues();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValues()
    {
        //For override
    }
    protected virtual void OnEnable()
    {
        //For override
    }
}
