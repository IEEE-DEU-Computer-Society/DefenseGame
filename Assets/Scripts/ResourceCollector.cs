using System;
using System.Globalization;
using UnityEngine;
using TMPro;

public class ResourceCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private double _resource;
    private float _tempRes;
    public float machineLevel = 0.5f;
    [SerializeField] [Tooltip("This chosen collider will be ignored by resource collecting machine!")] private Collider2D _collider2D;

    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),_collider2D);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Resource1")||other.CompareTag("Resource2")||other.CompareTag("Resource3"))
        {
            _tempRes += (Time.deltaTime * machineLevel);
            _resource = Mathf.FloorToInt(_tempRes);
            text.text ="Resource amount:" + _resource.ToString(CultureInfo.CurrentCulture);
        }
    }
}
