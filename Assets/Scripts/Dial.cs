using UnityEngine;
using System.Collections;

public class Dial : MonoBehaviour {

    public int[] MarkerRotation;
    public GameObject Marker = null;
    private GameManager _manager;
    private int _selector = 0;

    public int Selector { get { return _selector; } }

	// Use this for initialization
	void Start () {
        _manager = GameManager.GetInstance();
	}

    public void MoveDialLeft()
    {
        --_selector;

        if (_selector < 0)
            _selector = MarkerRotation.Length - 1;

        FinishMoveDial();
    }

    public void MoveDialRight()
    {
        ++_selector;

        if (_selector >= MarkerRotation.Length)
            _selector = 0;

        Marker.transform.Rotate(Vector3.back, MarkerRotation[_selector]);

        FinishMoveDial();

    }

    private void FinishMoveDial()
    {
        Marker.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + MarkerRotation[_selector]);
        _manager.UpdateDials();
    }
}
