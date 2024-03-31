using UnityEngine;
using UnityEngine.UI;

public class RecourseTracker : MonoBehaviour
{
    
    private static RecourseTracker _instance;
    public static RecourseTracker Instance{get{ return _instance;}}

    private int wood = 0;
    private int stone = 0;
    [SerializeField]
    Text textWood;
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void StoneValueChaning(int num)
    {
        stone += num;
        UpdateUI();
    }
    private void UpdateUI()
    {
        textWood.text = "Stone - " + stone;
    }
}
