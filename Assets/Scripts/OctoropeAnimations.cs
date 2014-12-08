using UnityEngine;
using System.Collections;

public class OctoropeAnimations : MonoBehaviour {

    public float m_speed = 1;

    GameObject _player = null;
    GameObject _window = null;
    GameObject _box = null;
    LineRenderer _rope = null;
    bool _playBoxAnim = false;
    bool _playEndAnim = false;
    Vector3 _mov;
    int _state = 0;
    float _timeStartFly;



	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Guy");
        _window = GameObject.Find("Prison_Window");
        _box = GameObject.Find("Prison_Box");
        _rope = GetComponent<LineRenderer>();
      //  _rope.SetColors(Color.green, Color.green);
        _rope.enabled = false;
       // _rope.SetVertexCount(2);
        renderer.enabled = false;
        _rope.sortingLayerName = "Near Elements";

        
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (_playBoxAnim)
        {
            
            if (_state == 0)
            {
                if (Vector3.Distance(transform.position, _window.transform.position) <= Vector3.Distance(_window.transform.position, transform.position + _mov))
                {
                    transform.parent = _box.transform;
                    _box.gameObject.GetComponent<Animator>().SetTrigger("Fall");
                    ++_state;
                    transform.position += _mov;
                    

                }
                else
                {
                    transform.position += _mov;

                }

                _rope.SetPosition(1, transform.position);
            }
            else
                _rope.SetPosition(1, _box.transform.position);

            _rope.SetPosition(0, _player.transform.position);
            
        }


        if (_playEndAnim)
        {
           
 
               
            transform.position += _mov;


            if (_timeStartFly < Time.time)
            {
                _player.transform.parent = transform;
                ++_state;
            }

               
            if(_state != 0)
            {
                transform.localScale *= 0.9f;
                _player.gameObject.transform.localScale *= 0.9f;
            }
                
            _rope.SetPosition(1, transform.position);
            _rope.SetPosition(0, _player.transform.position);


            if (_timeStartFly + 3 < Time.time)
            {
                Credits credits;

                credits = GameObject.FindWithTag("Credits").GetComponent<Credits>();

                credits.Roll();

                enabled = false;
            }
            
        }
	}

	

    public void OctoropeBoxAnimation()
    {
        transform.position = _player.transform.position;
        _playBoxAnim = true;
        renderer.enabled = true;
        _rope.enabled = true;
        
        _mov = Vector3.Normalize(_box.transform.position - transform.position) * m_speed;
    }

    public void OctoropeEndAnimation()
    {
        transform.position = _player.transform.position;
        _playEndAnim = true;
        renderer.enabled = true;
        _rope.enabled = true;
        _state = 0;

        _timeStartFly = Time.time + 1;
        transform.GetChild(0).gameObject.SetActive(true);

        _mov = Vector3.Normalize(_window.transform.position - transform.position) * m_speed/4;
    }

    public void EndBoxAnimation()
    {
        transform.parent = null;
        renderer.enabled = false;
        _playBoxAnim = false;
        _rope.enabled = false;
    }

}
