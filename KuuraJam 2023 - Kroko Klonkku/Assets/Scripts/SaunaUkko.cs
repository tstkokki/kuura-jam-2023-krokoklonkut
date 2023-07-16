using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaUkko : MonoBehaviour
{
    [SerializeField] int LoylyRes = 20;
    [SerializeField] int Hp = 100;

    public bool IsKlonkku;
    public SaunaUkkoState State;

    [SerializeField]
    SaunaPalvelu saunaPalvelu;

    MovementScript myMovement;
    GameObject KlonkkuModel;

    SpriteRenderer sprite;

    private void Start()
    {
        if (myMovement == null)
            myMovement = GetComponent<MovementScript>();

        sprite = GetComponentInChildren<SpriteRenderer>();

        var klon = GetComponentInChildren<ChangeToKlonkku>();
        if (klon != null)
        {

            KlonkkuModel = klon.gameObject;
            KlonkkuModel.SetActive(false);
        }
    }

    public void OttaaLoylya(int amount)
    {
        Hp -= Mathf.Max(amount - LoylyRes, 5);
    }

    public bool EiJaksaSaunoa()
    {
        return Hp <= 0;
    }

    public void LaitaKlonkuksi(bool toggle)
    {
        IsKlonkku = toggle;
        if(sprite != null)
            sprite.enabled = !toggle;
        if (KlonkkuModel != null)
            KlonkkuModel.SetActive(toggle);
    }

    public void LaitaLiikkeelle(Vector3Variable uusiKohde)
    {
        saunaPalvelu.LaitaLiikkeelle(this);
        myMovement.SetGoal(uusiKohde);
    }

    public void Init(int hp, int res, float speed)
    {
        Hp = hp;
        LoylyRes = res;
        myMovement = GetComponent<MovementScript>();
        myMovement.moveSpeed = speed;
    }


    public void ResetHp()
    {
        Hp = 100;
    }

    public bool JaksaaSaunoa => !IsKlonkku
        && (saunaPalvelu == null || saunaPalvelu.OnkoIstumassa(this))
        && Hp > 0;


    public void GoToNext(Vector3Variable target)
    {
        myMovement.SetGoal(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.GetComponent<ITarget>();
        col?.OnEnter(this);
    }
}
