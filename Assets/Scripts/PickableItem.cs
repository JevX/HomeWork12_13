using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private int _cost = 1;

    public int ID {get; private set;}

    public void SetID(int id)
    {
        ID = id;
    }
    
    public int PickUp()
    {        
        transform.gameObject.SetActive(false);

        return _cost;
    }
}
