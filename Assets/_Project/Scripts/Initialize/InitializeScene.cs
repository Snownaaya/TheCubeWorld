using Reflex.Attributes;
using UnityEngine;
using Assets.Scripts.UseCase;
using Cysharp.Threading.Tasks;

public class InitializeScene : MonoBehaviour
{
    private SceneTransitions _transitions;

    [Inject]
    private void Construct(SceneTransitions sceneTransitions)
    {
        _transitions = sceneTransitions;
;
        LoadMenu().Forget();
    }

    private async UniTask LoadMenu()
    { 
        await UniTask.Yield();
        await _transitions.GetMainMenu();
    }
}
