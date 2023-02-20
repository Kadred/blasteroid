//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/LevelObjects/Input/SpaceshipInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @SpaceshipInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @SpaceshipInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SpaceshipInput"",
    ""maps"": [
        {
            ""name"": ""Spaceship"",
            ""id"": ""1432ede0-682d-4df6-9643-008596758078"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""5b3b59a9-1eb7-4dd8-8faa-dbe736f8c5ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""77d65155-ea01-4cba-91ce-9970ea91090a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""a2ad9a40-632d-4431-8284-33123382b5d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Laser"",
                    ""type"": ""Button"",
                    ""id"": ""20b62afb-d28d-41be-aa1f-ee19ae56dbec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ed5bf1a-d297-43e5-bd10-553ce7be90c6"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dbf7bc8-4ea8-446e-a75f-b71ca53ae309"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6992804c-5440-4822-bdd0-61e850e9f892"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e6cf5072-3eb2-4ae8-b4be-9e0978f282ec"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e0badb6-4380-4095-8b6e-97a9a35557af"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6b1680ae-6859-4a92-a7f0-6981a722e5a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""77dc9155-c82a-4be9-ab13-1edc9050433f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Laser"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse & Keyboard"",
            ""bindingGroup"": ""Mouse & Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Spaceship
        m_Spaceship = asset.FindActionMap("Spaceship", throwIfNotFound: true);
        m_Spaceship_Move = m_Spaceship.FindAction("Move", throwIfNotFound: true);
        m_Spaceship_Shot = m_Spaceship.FindAction("Shot", throwIfNotFound: true);
        m_Spaceship_Rotate = m_Spaceship.FindAction("Rotate", throwIfNotFound: true);
        m_Spaceship_Laser = m_Spaceship.FindAction("Laser", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Spaceship
    private readonly InputActionMap m_Spaceship;
    private ISpaceshipActions m_SpaceshipActionsCallbackInterface;
    private readonly InputAction m_Spaceship_Move;
    private readonly InputAction m_Spaceship_Shot;
    private readonly InputAction m_Spaceship_Rotate;
    private readonly InputAction m_Spaceship_Laser;
    public struct SpaceshipActions
    {
        private @SpaceshipInput m_Wrapper;
        public SpaceshipActions(@SpaceshipInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Spaceship_Move;
        public InputAction @Shot => m_Wrapper.m_Spaceship_Shot;
        public InputAction @Rotate => m_Wrapper.m_Spaceship_Rotate;
        public InputAction @Laser => m_Wrapper.m_Spaceship_Laser;
        public InputActionMap Get() { return m_Wrapper.m_Spaceship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceshipActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceshipActions instance)
        {
            if (m_Wrapper.m_SpaceshipActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnMove;
                @Shot.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShot;
                @Rotate.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnRotate;
                @Laser.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnLaser;
                @Laser.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnLaser;
                @Laser.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnLaser;
            }
            m_Wrapper.m_SpaceshipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Laser.started += instance.OnLaser;
                @Laser.performed += instance.OnLaser;
                @Laser.canceled += instance.OnLaser;
            }
        }
    }
    public SpaceshipActions @Spaceship => new SpaceshipActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse & Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface ISpaceshipActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnLaser(InputAction.CallbackContext context);
    }
}
