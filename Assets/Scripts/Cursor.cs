using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
    public InventoryItem m_item;
    private PlayerController _player;

    public InventoryItem Item
    {
        get { return m_item; }
        set
        {
            m_item = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        _player = GameObject.Find("Guy").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, LayerMask.GetMask("InteractiveObject"));
            if (hit != null && hit.transform != null)
            {
                Debug.Log("boxs");
                _player.Move(hit.transform.gameObject.GetComponent<SceneItem>(), Input.GetMouseButtonDown(1) || Item != null);
            }
            else
            {
                hit = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, LayerMask.GetMask("Floor"));

                if (hit != null && hit.transform != null)
                {
                    _player.Move(null, false);
                }
            }
        }
    }
}
