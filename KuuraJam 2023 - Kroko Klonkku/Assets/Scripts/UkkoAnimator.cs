using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UkkoAnimator : MonoBehaviour
{

    SaunaUkko ukko;

    ReactiveProperty<SaunaUkkoState> stateObserver;

    [SerializeField]
    SaunaPalvelu saunaPalvelu;

    [SerializeField]
    GameEvent pokeEvent;

    string walk = "SaunaUkkoWalking";
    string sit = "SaunaUkkoSit";
    string poke = "SaunaUkkoPoked";
    string shower = "SaunaUkkoShowering";
    string idle = "SaunaUkkoIdle";


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ukko = GetComponent<SaunaUkko>();
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
            return;
        stateObserver = new ReactiveProperty<SaunaUkkoState>(ukko.State);
        stateObserver.ObserveEveryValueChanged(v => ukko.State)
            .TakeUntilDestroy(this)
            .Subscribe(s =>
            {
                if (saunaPalvelu.OnkoLiikkeella(ukko))
                    animator.Play(walk);
                if(saunaPalvelu.OnkoSuihkussa(ukko))
                    animator.Play(shower);
                if(saunaPalvelu.OnkoIstumassa(ukko))
                    animator.Play(sit);
                else animator.Play(idle);
            });

    }

    public void PlayPoke()
    {
        pokeEvent.Raise();
        animator.Play(poke);
    }

}
