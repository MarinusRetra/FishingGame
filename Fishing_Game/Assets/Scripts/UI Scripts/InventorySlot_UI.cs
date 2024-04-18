using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot_UI : MonoBehaviour
{
    [SerializeField] private Image ItemSprite;
    [SerializeField] private TextMeshProUGUI ItemCount;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button button;

    public InventorySlot AssignedInventorySlot { get { return assignedInventorySlot; } }
    public InventoryDisplay parentDisplay {get; private set;}

    private void Awake()
    {
        ClearSlot();


        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        parentDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    public void Init(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if (slot.ItemData != null)
        {
            ItemSprite.sprite = slot.ItemData.Icon;
            ItemSprite.color = Color.white;
            // ik heb van de if else een ternery statement gemaakt check later of dit goed wertk
            ItemCount.text = (slot.StackSize > 1) ? ItemCount.text = slot.StackSize.ToString() : ItemCount.text = ""; 
        }
        else
        {
            ClearSlot();
        }
    }

    public void UpdateUISlot()
    {
        if (assignedInventorySlot != null)
        { 
           UpdateUISlot(assignedInventorySlot);
        }
    }


    public void OnUISlotClick()
    {
        parentDisplay?.SlotClicked(this);
    }
    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
        ItemCount.text = "";
    }

}
