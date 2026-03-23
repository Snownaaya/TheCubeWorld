using Assets.Scripts.Input;
using Assets.Scripts.UseCase;
using Cysharp.Threading.Tasks;
using Reflex.Attributes;
using UnityEngine;

public class InitializeScene : MonoBehaviour
{
    private SceneTransitions _transitions;

    [Inject]
    private void Construct(
        SceneTransitions sceneTransitions,
        IJoystickInput joystickInput)
    {
        _transitions = sceneTransitions;

        Application.targetFrameRate = 60;

        LoadMenu().Forget();
        joystickInput.Hide();
    }

    private async UniTask LoadMenu()
    { 
        await UniTask.Yield();
        await _transitions.GetMainMenu();
    }
}
