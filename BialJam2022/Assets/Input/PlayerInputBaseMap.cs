//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/PlayerInputBaseMap.inputactions
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

public partial class @PlayerInputBaseMap : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputBaseMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputBaseMap"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""7e84c119-1caa-4e37-b369-696ff7068249"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Value"",
                    ""id"": ""6a3383ed-e595-4846-b20d-790fe97ee21b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ApplyForce"",
                    ""type"": ""Button"",
                    ""id"": ""cabcc551-1ba9-41d8-b3ee-cf3c2df02826"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70f9e981-a036-4fc4-becb-8e384a1c3b38"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePadXbox"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bfa16acc-6ba7-4de5-95d0-637667dcc3f5"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""89698b0f-878e-4942-98c0-5471aceedd31"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""296e37ff-4ac6-4975-9fb3-b359370fe6be"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8d920258-ceca-4179-be79-3fcd56223891"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2fd188f7-90d8-498d-94ec-1bce6bdef51c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d5483fd4-e95b-4aec-b9e9-86fab33ce493"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePadXbox"",
                    ""action"": ""ApplyForce"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67b971c4-03c7-44ed-bbe1-df37eb27cae8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ApplyForce"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Misc"",
            ""id"": ""cd5905d8-e543-4f8e-8a1e-de6eb7d0c12c"",
            ""actions"": [
                {
                    ""name"": ""Menu_Pause"",
                    ""type"": ""Button"",
                    ""id"": ""62ee8b22-04c8-4c7c-881c-3a298b48693e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TutorialBack"",
                    ""type"": ""Button"",
                    ""id"": ""b54f1e5b-9aaf-4087-8017-ce056e7f730b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35c4632e-2b3c-4615-a003-4c1ad354656a"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePadXbox"",
                    ""action"": ""Menu_Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93916734-ca8d-48ef-bac6-268a553fa9c2"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TutorialBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePadXbox"",
            ""bindingGroup"": ""GamePadXbox"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Roll = m_Movement.FindAction("Roll", throwIfNotFound: true);
        m_Movement_ApplyForce = m_Movement.FindAction("ApplyForce", throwIfNotFound: true);
        // Misc
        m_Misc = asset.FindActionMap("Misc", throwIfNotFound: true);
        m_Misc_Menu_Pause = m_Misc.FindAction("Menu_Pause", throwIfNotFound: true);
        m_Misc_TutorialBack = m_Misc.FindAction("TutorialBack", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Roll;
    private readonly InputAction m_Movement_ApplyForce;
    public struct MovementActions
    {
        private @PlayerInputBaseMap m_Wrapper;
        public MovementActions(@PlayerInputBaseMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_Movement_Roll;
        public InputAction @ApplyForce => m_Wrapper.m_Movement_ApplyForce;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRoll;
                @ApplyForce.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnApplyForce;
                @ApplyForce.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnApplyForce;
                @ApplyForce.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnApplyForce;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @ApplyForce.started += instance.OnApplyForce;
                @ApplyForce.performed += instance.OnApplyForce;
                @ApplyForce.canceled += instance.OnApplyForce;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Misc
    private readonly InputActionMap m_Misc;
    private IMiscActions m_MiscActionsCallbackInterface;
    private readonly InputAction m_Misc_Menu_Pause;
    private readonly InputAction m_Misc_TutorialBack;
    public struct MiscActions
    {
        private @PlayerInputBaseMap m_Wrapper;
        public MiscActions(@PlayerInputBaseMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu_Pause => m_Wrapper.m_Misc_Menu_Pause;
        public InputAction @TutorialBack => m_Wrapper.m_Misc_TutorialBack;
        public InputActionMap Get() { return m_Wrapper.m_Misc; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MiscActions set) { return set.Get(); }
        public void SetCallbacks(IMiscActions instance)
        {
            if (m_Wrapper.m_MiscActionsCallbackInterface != null)
            {
                @Menu_Pause.started -= m_Wrapper.m_MiscActionsCallbackInterface.OnMenu_Pause;
                @Menu_Pause.performed -= m_Wrapper.m_MiscActionsCallbackInterface.OnMenu_Pause;
                @Menu_Pause.canceled -= m_Wrapper.m_MiscActionsCallbackInterface.OnMenu_Pause;
                @TutorialBack.started -= m_Wrapper.m_MiscActionsCallbackInterface.OnTutorialBack;
                @TutorialBack.performed -= m_Wrapper.m_MiscActionsCallbackInterface.OnTutorialBack;
                @TutorialBack.canceled -= m_Wrapper.m_MiscActionsCallbackInterface.OnTutorialBack;
            }
            m_Wrapper.m_MiscActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menu_Pause.started += instance.OnMenu_Pause;
                @Menu_Pause.performed += instance.OnMenu_Pause;
                @Menu_Pause.canceled += instance.OnMenu_Pause;
                @TutorialBack.started += instance.OnTutorialBack;
                @TutorialBack.performed += instance.OnTutorialBack;
                @TutorialBack.canceled += instance.OnTutorialBack;
            }
        }
    }
    public MiscActions @Misc => new MiscActions(this);
    private int m_GamePadXboxSchemeIndex = -1;
    public InputControlScheme GamePadXboxScheme
    {
        get
        {
            if (m_GamePadXboxSchemeIndex == -1) m_GamePadXboxSchemeIndex = asset.FindControlSchemeIndex("GamePadXbox");
            return asset.controlSchemes[m_GamePadXboxSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnApplyForce(InputAction.CallbackContext context);
    }
    public interface IMiscActions
    {
        void OnMenu_Pause(InputAction.CallbackContext context);
        void OnTutorialBack(InputAction.CallbackContext context);
    }
}
