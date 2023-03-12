using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody2D inventoryRigidbody2D;
    [SerializeField] private float rangeOfInventory = 0.5f;
    private Rigidbody2D Rigidbody2D1 { get; set; }
    private Vector2 MousePosition { get;  set; }
    private Vector2 WantedPosition { get;  set; }
    private float DeltaX { get;  set; }
    private float DeltaY { get; set; }

    private float RangeOfInventory => rangeOfInventory;

    private void Awake()
    {
        Rigidbody2D1 = GetComponent<Rigidbody2D>();
        WantedPosition = Rigidbody2D1.position;
    }

    private void FixedUpdate()
    {
        Rigidbody2D1.MovePosition(WantedPosition);
    }

    private void OnMouseDown()
    {
        if (Camera.main != null)
        {
            DeltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - Rigidbody2D1.position.x;
            DeltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - Rigidbody2D1.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (Camera.main != null) MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        WantedPosition = new Vector2(MousePosition.x - DeltaX, MousePosition.y - DeltaY);
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(Rigidbody2D1.position.x - inventoryRigidbody2D.position.x) <= RangeOfInventory && 
            Mathf.Abs(Rigidbody2D1.position.y - inventoryRigidbody2D.position.y) <= RangeOfInventory)
        {
            var position = inventoryRigidbody2D.position;
            WantedPosition = new Vector2(position.x, position.y);
        }
        else
        {
            WantedPosition = Rigidbody2D1.position;
        }
    }
}
