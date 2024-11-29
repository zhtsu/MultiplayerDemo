using System;
using System.Collections;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;

    public class OnStateChangedEventArgs : EventArgs
    {
        public State NewState;
    }

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }

    [SerializeField]
    private FryingRecipeSO[] _fryingRecipeSOArray;

    [SerializeField]
    private BurningRecipeSO[] _burningRecipeSOArray;

    private State _state;
    private float _fryingTimer;
    private float _burningTimer;
    private FryingRecipeSO _fryingRecipeSO;
    private BurningRecipeSO _burningRecipeSO;

    private void Start()
    {
        _state = State.Idle;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Idle:
                break;
            case State.Frying:
                _fryingTimer += Time.deltaTime;

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    ProgressNormalized = _fryingTimer / _fryingRecipeSO.FryingTimerMax
                });

                if (_fryingTimer > _fryingRecipeSO.FryingTimerMax)
                {
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(_fryingRecipeSO.Output, this);
                    ChangeStateTo(State.Fried);
                    _burningTimer = 0f;
                    _burningRecipeSO = GetBruningRecipeSOWithInput(GetKitchenObject().GetSO());
                }
                break;
            case State.Fried:
                _burningTimer += Time.deltaTime;

                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    ProgressNormalized = _burningTimer / _burningRecipeSO.BurningTimerMax
                });

                if (_burningTimer > _burningRecipeSO.BurningTimerMax)
                {
                    GetKitchenObject().DestroySelf();
                    KitchenObject.SpawnKitchenObject(_burningRecipeSO.Output, this);
                    ChangeStateTo(State.Burned);

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        ProgressNormalized = 0f
                    });
                }
                break;
            case State.Burned:
                break;
        }
    }

    public override void Interact(Player player)
    {
        if (HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetSO()))
                    {
                        GetKitchenObject().DestroySelf();
                        ChangeStateTo(State.Idle);
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            ProgressNormalized = 0f
                        });
                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
                ChangeStateTo(State.Idle);
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    ProgressNormalized = 0f
                });
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if (HasFryingRecipeWithInput(player.GetKitchenObject().GetSO()))
                {
                    _fryingRecipeSO = GetFryingRecipeSOWithInput(player.GetKitchenObject().GetSO());
                    player.GetKitchenObject().SetKitchenObjectParent(this);

                    ChangeStateTo(State.Frying);
                    _fryingTimer = 0f;

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        ProgressNormalized = _fryingTimer / _fryingRecipeSO.FryingTimerMax
                    });
                }
            }
            else
            {

            }
        }
    }

    private bool HasFryingRecipeWithInput(KitchenObjectSO input)
    {
        return GetFryingRecipeSOWithInput(input) != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        FryingRecipeSO cuttingRecipeSO = GetFryingRecipeSOWithInput(input);
        return cuttingRecipeSO != null ? cuttingRecipeSO.Output : null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (FryingRecipeSO recipeSO in _fryingRecipeSOArray)
        {
            if (recipeSO.Input == input)
            {
                return recipeSO;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBruningRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (BurningRecipeSO recipeSO in _burningRecipeSOArray)
        {
            if (recipeSO.Input == input)
            {
                return recipeSO;
            }
        }
        return null;
    }

    private void ChangeStateTo(State newState)
    {
        _state = newState;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
        {
            NewState = newState
        });
    }

    public bool IsFried()
    {
        return _state == State.Fried;
    }
}
