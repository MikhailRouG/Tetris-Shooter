using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private float _destroyTime;

    [SerializeField] Vector3 _velocity;
    [SerializeField] float _size;

    [SerializeField] GameObject _hitEffectPrefab;
    [SerializeField] GameObject _destroyEffectPrefab;
    private AudioSource _audioSource;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    [SerializeField] AudioClip _hitEffect;
=======
    [SerializeField] private AudioClip _hitEffect;
    [SerializeField] private LayerMask _unCollisionLayer;
>>>>>>> Stashed changes
=======
    [SerializeField] private AudioClip _hitEffect;
    [SerializeField] private LayerMask _unCollisionLayer;
>>>>>>> Stashed changes
    int _damage;
    private static int _count = 0;
    private static int _maxCount = 100;
    private bool isInit = false;
    Rigidbody _rb;
    bool isDoubled;

    private void Awake()
    {
        _count++;
        if (_count >= _maxCount) Destroy(gameObject);
        isInit = true;  
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>(); 
        _rb.useGravity = false;
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        Destroy(gameObject, _destroyTime);
    }
    private void OnDestroy()
    {
        if(isInit) _count--;
        Instantiate(_destroyEffectPrefab, transform.position, transform.rotation);
    }
    private void FixedUpdate()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        _rb.linearVelocity = _velocity.normalized * _speed;
=======
=======
>>>>>>> Stashed changes
        transform.position += (Vector3)_velocity * _speed * Time.fixedDeltaTime;

        Vector3 vel = _velocity;
        vel.y = 0.0f;
        vel = vel.normalized;

        if (Physics.BoxCast(
            transform.position,
            new Vector3(0.2f, 0.2f, 0.2f),
            vel,
            out RaycastHit hit,
            Quaternion.identity,
            _size,_unCollisionLayer))
        {
            Transform hitTrans = hit.collider.transform;

            Vector3 direction = transform.position - hitTrans.position;
            direction.y = 0.0f;
            direction = direction.normalized;

            Vector3 axis;
            axis = hitTrans.right;
            axis.y = 0.0f;
            axis = axis.normalized;
            float outHorizontal = Vector3.Dot(direction, axis);
            axis = hitTrans.forward;
            axis.y = 0.0f;
            axis = axis.normalized;
            float outVertical = Vector3.Dot(direction, axis);


            SpawnEffect();
            _audioSource.PlayOneShot(_hitEffect);

            if (Mathf.Abs(outHorizontal) < Mathf.Abs(outVertical))
            {
                _velocity.z = Mathf.Sign(direction.z) * Mathf.Abs(_velocity.z);
            }
            else
            {
                _velocity.x = Mathf.Sign(direction.x) * Mathf.Abs(_velocity.x);
            }

            // ダメージ
            // NOMOVEにはダメージを与えない
            Block b = hit.collider.gameObject.GetComponent<Block>();
            if (b != null && b.GetBlockType() != BLOCK_TYPE.NOMOVE)
            {
                int health = b.GetNumber() - _damage;
                b.SetNumber(health);
                b.UpdateNumberText();

                if (health <= 0)
                {
                    Stage.instance.DeleteBlock(b.GetIndex());
                }
            }
        }


        if (transform.position.z < 0) Destroy(gameObject);
>>>>>>> Stashed changes
    }
    private void OnCollisionEnter(Collision collision)
    {
        SpawnEffect();
        _audioSource.PlayOneShot(_hitEffect);
        ContactPoint contact = collision.contacts[0];

        _velocity = Vector3.Reflect(_velocity, contact.normal);
        _velocity.y = 0.0f;

        Block block = collision.collider.GetComponent<Block>();
        if (block != null)
        {
            int hp = block.GetNumber() - _damage;
            block.SetNumber(hp);
            block.UpdateNumberText();

            if (hp <= 0 && Stage.instance != null)
            {
                Stage.instance.DeleteBlock(block.GetIndex());
            }
;        }

    }

    void SpawnEffect()
    {
        if (_hitEffectPrefab == null) return;

        GameObject fx = Instantiate(_hitEffectPrefab, transform.position, transform.rotation);
    }

    public void SetParameter(float speed , Vector3 velocity,int daamge)
    {
        _speed = speed;
        _velocity = velocity;
        _damage = daamge;
    }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public void SetDamage(int damage)
    {
        _damage = damage;
    }
=======
#if UNITY_EDITOR
>>>>>>> Stashed changes
=======
#if UNITY_EDITOR
>>>>>>> Stashed changes
    private void OnDrawGizmos()
    {
        Vector3 vel = _velocity;
        vel.y = 0.0f;
        vel = vel.normalized;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, vel * _size);
    }
    public Vector3 GetVelocity()
    {
        return _rb.linearVelocity;
    }
    public float GetSpeed()
    {
        return _speed;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public bool GetIsDouble()
    {
        return isDoubled;
    }
    public void SetIsDouble(bool b)
    {
        isDoubled = b;
    }
}
#endif