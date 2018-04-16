using AlfredoMB.Builder;
using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.DI.Decoupling;
using AlfredoMB.DI.Decoupling.UnityImplementations;
using AlfredoMB.Stage;
using UnityEngine;

namespace AlfredoMB.Initialization
{
    public class GameInitializer : MonoBehaviour
    {
        public StageModelScriptableObject StageModelScriptableObject;
        public GameObject Views;
                
        private void Start()
        {
            // register dependencies
            SimpleDI.Register<ICamera>(new UnityCamera());
            SimpleDI.Register<IInput>(new UnityInput());
            SimpleDI.Register<ICommandController>( new CommandController());
            SimpleDI.Register<IStageController>(new StageController(StageModelScriptableObject.ToModel()));
            SimpleDI.Register<IBuilderController>(new BuilderController());

            Views.SetActive(true);
        }
    }
}