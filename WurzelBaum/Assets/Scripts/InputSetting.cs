// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSetting.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSetting : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSetting()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSetting"",
    ""maps"": [
        {
            ""name"": ""Moorhuhn"",
            ""id"": ""f658d68f-3888-40b7-8bcd-e0a418f97c61"",
            ""actions"": [
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""e39c3dde-7094-48b7-a191-b3bf59c6efc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ballern"",
                    ""type"": ""Button"",
                    ""id"": ""adeb1c80-83c3-4864-85ca-f5278c913ec4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""getMouse"",
                    ""type"": ""Value"",
                    ""id"": ""196d8851-d985-4ecb-8bcd-de3a5407ef4b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""75b001be-ac76-4320-81a0-9b8cbf7a3f02"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""549d9129-426c-4832-9b3f-91b47f9b4c3c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ballern"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4186da3-61fc-4d30-9c6f-a1e5e9df158d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""getMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Graph"",
            ""id"": ""97e867c6-0cdf-4334-b2e0-bf7599c06710"",
            ""actions"": [
                {
                    ""name"": ""moveGraph"",
                    ""type"": ""Value"",
                    ""id"": ""a876c52c-d818-4547-90fa-ae87de294cbf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6204093c-c2b7-4c5e-ba4b-08894109cf48"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveGraph"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Moorhuhn
        m_Moorhuhn = asset.FindActionMap("Moorhuhn", throwIfNotFound: true);
        m_Moorhuhn_Reload = m_Moorhuhn.FindAction("Reload", throwIfNotFound: true);
        m_Moorhuhn_Ballern = m_Moorhuhn.FindAction("Ballern", throwIfNotFound: true);
        m_Moorhuhn_getMouse = m_Moorhuhn.FindAction("getMouse", throwIfNotFound: true);
        // Graph
        m_Graph = asset.FindActionMap("Graph", throwIfNotFound: true);
        m_Graph_moveGraph = m_Graph.FindAction("moveGraph", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Moorhuhn
    private readonly InputActionMap m_Moorhuhn;
    private IMoorhuhnActions m_MoorhuhnActionsCallbackInterface;
    private readonly InputAction m_Moorhuhn_Reload;
    private readonly InputAction m_Moorhuhn_Ballern;
    private readonly InputAction m_Moorhuhn_getMouse;
    public struct MoorhuhnActions
    {
        private @InputSetting m_Wrapper;
        public MoorhuhnActions(@InputSetting wrapper) { m_Wrapper = wrapper; }
        public InputAction @Reload => m_Wrapper.m_Moorhuhn_Reload;
        public InputAction @Ballern => m_Wrapper.m_Moorhuhn_Ballern;
        public InputAction @getMouse => m_Wrapper.m_Moorhuhn_getMouse;
        public InputActionMap Get() { return m_Wrapper.m_Moorhuhn; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoorhuhnActions set) { return set.Get(); }
        public void SetCallbacks(IMoorhuhnActions instance)
        {
            if (m_Wrapper.m_MoorhuhnActionsCallbackInterface != null)
            {
                @Reload.started -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnReload;
                @Ballern.started -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnBallern;
                @Ballern.performed -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnBallern;
                @Ballern.canceled -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnBallern;
                @getMouse.started -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnGetMouse;
                @getMouse.performed -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnGetMouse;
                @getMouse.canceled -= m_Wrapper.m_MoorhuhnActionsCallbackInterface.OnGetMouse;
            }
            m_Wrapper.m_MoorhuhnActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Ballern.started += instance.OnBallern;
                @Ballern.performed += instance.OnBallern;
                @Ballern.canceled += instance.OnBallern;
                @getMouse.started += instance.OnGetMouse;
                @getMouse.performed += instance.OnGetMouse;
                @getMouse.canceled += instance.OnGetMouse;
            }
        }
    }
    public MoorhuhnActions @Moorhuhn => new MoorhuhnActions(this);

    // Graph
    private readonly InputActionMap m_Graph;
    private IGraphActions m_GraphActionsCallbackInterface;
    private readonly InputAction m_Graph_moveGraph;
    public struct GraphActions
    {
        private @InputSetting m_Wrapper;
        public GraphActions(@InputSetting wrapper) { m_Wrapper = wrapper; }
        public InputAction @moveGraph => m_Wrapper.m_Graph_moveGraph;
        public InputActionMap Get() { return m_Wrapper.m_Graph; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GraphActions set) { return set.Get(); }
        public void SetCallbacks(IGraphActions instance)
        {
            if (m_Wrapper.m_GraphActionsCallbackInterface != null)
            {
                @moveGraph.started -= m_Wrapper.m_GraphActionsCallbackInterface.OnMoveGraph;
                @moveGraph.performed -= m_Wrapper.m_GraphActionsCallbackInterface.OnMoveGraph;
                @moveGraph.canceled -= m_Wrapper.m_GraphActionsCallbackInterface.OnMoveGraph;
            }
            m_Wrapper.m_GraphActionsCallbackInterface = instance;
            if (instance != null)
            {
                @moveGraph.started += instance.OnMoveGraph;
                @moveGraph.performed += instance.OnMoveGraph;
                @moveGraph.canceled += instance.OnMoveGraph;
            }
        }
    }
    public GraphActions @Graph => new GraphActions(this);
    public interface IMoorhuhnActions
    {
        void OnReload(InputAction.CallbackContext context);
        void OnBallern(InputAction.CallbackContext context);
        void OnGetMouse(InputAction.CallbackContext context);
    }
    public interface IGraphActions
    {
        void OnMoveGraph(InputAction.CallbackContext context);
    }
}
