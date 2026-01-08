using UnityEngine;

public class BlockPresent : BlockMove
{
    [SerializeField] private GameObject _anim;
    public override void Broken()
    {
        ItemManager.instance.AddReroll(1);
<<<<<<< Updated upstream
=======
        ScoreManager.instance.AddScore(1);
        Instantiate(_anim, transform.position, Quaternion.identity);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
