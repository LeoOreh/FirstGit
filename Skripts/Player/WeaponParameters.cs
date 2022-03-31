using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponParameters : MonoBehaviour
{
    public GameObject weaponInfo;
    GameObject _targetE;
    public float _Speed = 1.5f;
    public float _life = 2f;

    public int DAMAGE = 5;

    bool _colliderEnemy = false;
    bool _colliderTerrain = false;
    bool _move = true;
    ParticleSystem.MainModule _ps;

    public Image IconWeapon;
    void Start()
    {
        _targetE = GameObject.FindGameObjectWithTag("ENEMY");
        transform.LookAt(_targetE.transform);
        _ps = GetComponentInChildren<ParticleSystem>().main;
    }
    private void FixedUpdate()
    {

        if (_colliderEnemy)
        {
            if (_targetE)
                transform.LookAt(_targetE.transform);
            if (_move)
                transform.Translate(Vector3.forward.normalized * _Speed * Time.deltaTime);
            Dissolution(0.1f);
        }

        if (_colliderTerrain)
        {
            Dissolution(0.1f);
            _move = false;
            transform.Translate(Vector3.forward.normalized * (_Speed * 0.1f) * Time.deltaTime);
        }
        else
        {
            if (_move)
                transform.Translate(Vector3.forward.normalized * _Speed * Time.deltaTime);
        }


        Destroy(gameObject, _life);
    }

    void Dissolution(float _alfa)
    {
        Color a = _ps.startColor.color;
        Color b = new Color(1, 1, 1, 0);
        _ps.startColor = Color.Lerp(a, b, _alfa);
        if (_ps.startColor.color.a <= 0.1f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == ("ENEMY"))
            _colliderEnemy = true;

        if (other.tag == ("Terrain"))
            _colliderTerrain = true;
    }


}

