using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    [SerializeField] private int shotgunPelletsNum = 12;
    public override void Shoot()
    {
        if(_last_shoot_time + _shoot_delay < Time.time)
        {
            //could've used object pooling
            _animator.SetTrigger("Fire");
            _shooting_system.Play();
            Vector3 direction = GetDirection();
            for (int i=0; i< shotgunPelletsNum;i++)
            {
                if (Physics.Raycast(_bullet_spawn_point.position, direction, out RaycastHit hit, float.MaxValue, _mask))
                {
                    TrailRenderer trail = Instantiate(_bulletTrail, _bullet_spawn_point.position, Quaternion.identity);

                    StartCoroutine(SpawnTrail(trail, hit));
                    direction = GetDirection();
                }
                else
                {
                    TrailRenderer trail = Instantiate(_bulletTrail, _bullet_spawn_point.position, Quaternion.identity);

                    StartCoroutine(SpawnTrail(trail, direction));
                    direction = GetDirection();
                }
            }
            _last_shoot_time = Time.time;
        }
    }
}
