// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable {
    public InputActionAsset asset { get; }
    public @Controls() {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9015453e-6069-4b53-b97d-7ccf915ac28c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4eb2b98b-36b2-4bc9-8160-90342f0a2cad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""96cde5c4-262d-41fb-8723-c49ee53d828f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rewind"",
                    ""type"": ""Button"",
                    ""id"": ""a4dd028e-d220-4322-bd7b-8dde8fa0b615"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""49112e21-13b4-44f8-b4e3-4059eb80bf72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""3cb108b3-e45b-43db-aae1-ae3309e11be5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""91d1a14d-331f-42cc-af33-8e4665f7384d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66ed623c-b308-4ae6-9bb3-2e9ab6cff15a"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""324561f2-9614-444c-9546-150b6b12d37f"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57e8b092-5cb7-40c7-b55d-347787771de8"",
                    ""path"": ""<Joystick>/hat"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dc3b5cf8-f6ff-4fd7-bb61-49800c0a7b9f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""05e8b294-ba08-4bb5-b8c3-79c3d22f147c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""edf572d9-8b03-4c5e-b81f-0e8bddd976b3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""200ec10e-7de7-4503-a2bd-8108e0d49d49"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""be6d3503-92f2-4b5e-af8c-2dc1750d02a3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a6e6517f-2085-415d-9eb8-76523db6f0c0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e8fe5b8b-cfc2-4a96-8742-917efdf0081a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7dd2abf8-4472-47f2-b665-52fedc49c35b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02125ea3-ed79-40b5-bcf3-86808c052fa7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""630e3b57-6542-4d00-9327-9b42a765214e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c37f301a-fbee-44e2-bcdd-22cab99c1197"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d45d9d31-74eb-42e7-ae00-a9a3626cecdb"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11815eca-7099-474b-aefc-9166ee8e1e58"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""743bcac1-1932-41dc-b9ee-72c4d45de799"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50b579e8-4fef-4760-930b-d67fe1524c04"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdd2d295-9e1a-4131-ad71-fae811c8c50c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc6f351-284b-4a58-bf61-e7042823788a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab7a42c9-7dc1-4b8d-9dcd-044b17a1b0fe"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70644f71-4b72-4920-ad4c-8ccf071c598b"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""489b8d98-386a-4205-a8f9-4c9a0c362d76"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7a67864-ef80-4db2-ac6b-f1e86f2d21e5"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e23c82e-9983-4374-b65f-416c31e271cf"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f39ea573-baa7-4852-afb6-0c832c35a34b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""740830d9-d7bd-4c64-8d8a-15f69fcb2e0d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf4b49f6-9029-4714-813a-8ffe4fba93b5"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b8813b2-0fa9-4fde-a505-2c537917b36a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2eb0bb8-aa6a-44ec-81c1-5d88c7ec9bde"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""840c9e7a-bbce-41fa-9c5b-d3d8f2fe2cfa"",
            ""actions"": [
                {
                    ""name"": ""F1"",
                    ""type"": ""Button"",
                    ""id"": ""4bdb4ccc-16ba-42a3-8e81-975d87692c68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F2"",
                    ""type"": ""Button"",
                    ""id"": ""39b05b19-bb4f-47f8-ada8-609ad7607e9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F3"",
                    ""type"": ""Button"",
                    ""id"": ""cbe72fe3-5640-4e43-895d-894ef3511c1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F4"",
                    ""type"": ""Button"",
                    ""id"": ""54a1100e-ddcf-4ba6-988b-f4e7cc205d06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F5"",
                    ""type"": ""Button"",
                    ""id"": ""9302eb4f-81f0-4d38-a99f-efb42fbf9ec5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F6"",
                    ""type"": ""Button"",
                    ""id"": ""f201ab28-0ff8-4672-b429-4128039c2b6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F7"",
                    ""type"": ""Button"",
                    ""id"": ""ab67c856-2e6a-4e90-b2ea-251389a49983"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F8"",
                    ""type"": ""Button"",
                    ""id"": ""1d49faaa-da2c-4c24-b0de-ca1ce3b1c707"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F9"",
                    ""type"": ""Button"",
                    ""id"": ""67d14326-7d51-4108-a59c-f1b4530cc83f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F10"",
                    ""type"": ""Button"",
                    ""id"": ""a7cc8df0-bc8a-4ebc-b505-aba2fc710ee5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F11"",
                    ""type"": ""Button"",
                    ""id"": ""4a1ce445-ea35-4300-b548-a0ac9f5d69af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F12"",
                    ""type"": ""Button"",
                    ""id"": ""e22f4924-d223-4ad9-b8d9-bc269240850e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7fd9c27a-01b2-45aa-8214-85349cfd4dbf"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb51bb6a-c561-4e6a-b020-cf2fb9ade896"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a893af0-8714-42c9-bcfb-392ccc143a12"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28e459cf-d6d2-48bd-a88c-0bb239243515"",
                    ""path"": ""<Keyboard>/f4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c59f430-5978-44c1-9084-9129eae0b746"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""043ed221-0f9e-478b-bedd-7c08bf4cdbeb"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""120e18c0-3bcf-485a-9389-14c43022a930"",
                    ""path"": ""<Keyboard>/f7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""404382ee-b7c5-4b1e-bf86-4c96c48346eb"",
                    ""path"": ""<Keyboard>/f8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34a2f3ad-d99b-447e-901f-2b24805a7e69"",
                    ""path"": ""<Keyboard>/f9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1daac438-d41a-4099-b1f9-d970db521a17"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F10"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cf12b73-88f8-44f9-b59e-5226ec6c3938"",
                    ""path"": ""<Keyboard>/f11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F11"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5da8272-54af-4ce8-828c-4314ae0d85d6"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F12"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Rewind = m_Player.FindAction("Rewind", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Roll = m_Player.FindAction("Roll", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_F1 = m_Debug.FindAction("F1", throwIfNotFound: true);
        m_Debug_F2 = m_Debug.FindAction("F2", throwIfNotFound: true);
        m_Debug_F3 = m_Debug.FindAction("F3", throwIfNotFound: true);
        m_Debug_F4 = m_Debug.FindAction("F4", throwIfNotFound: true);
        m_Debug_F5 = m_Debug.FindAction("F5", throwIfNotFound: true);
        m_Debug_F6 = m_Debug.FindAction("F6", throwIfNotFound: true);
        m_Debug_F7 = m_Debug.FindAction("F7", throwIfNotFound: true);
        m_Debug_F8 = m_Debug.FindAction("F8", throwIfNotFound: true);
        m_Debug_F9 = m_Debug.FindAction("F9", throwIfNotFound: true);
        m_Debug_F10 = m_Debug.FindAction("F10", throwIfNotFound: true);
        m_Debug_F11 = m_Debug.FindAction("F11", throwIfNotFound: true);
        m_Debug_F12 = m_Debug.FindAction("F12", throwIfNotFound: true);
    }

    public void Dispose() {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action) {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator() {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void Enable() {
        asset.Enable();
    }

    public void Disable() {
        asset.Disable();
    }

    // Player
    readonly InputActionMap m_Player;
    IPlayerActions m_PlayerActionsCallbackInterface;
    readonly InputAction m_Player_Move;
    readonly InputAction m_Player_Jump;
    readonly InputAction m_Player_Rewind;
    readonly InputAction m_Player_Run;
    readonly InputAction m_Player_Roll;
    public struct PlayerActions {
        @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Rewind => m_Wrapper.m_Player_Rewind;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Roll => m_Wrapper.m_Player_Roll;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance) {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null) {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Rewind.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRewind;
                @Rewind.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRewind;
                @Rewind.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRewind;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Roll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRoll;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null) {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Rewind.started += instance.OnRewind;
                @Rewind.performed += instance.OnRewind;
                @Rewind.canceled += instance.OnRewind;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Debug
    readonly InputActionMap m_Debug;
    IDebugActions m_DebugActionsCallbackInterface;
    readonly InputAction m_Debug_F1;
    readonly InputAction m_Debug_F2;
    readonly InputAction m_Debug_F3;
    readonly InputAction m_Debug_F4;
    readonly InputAction m_Debug_F5;
    readonly InputAction m_Debug_F6;
    readonly InputAction m_Debug_F7;
    readonly InputAction m_Debug_F8;
    readonly InputAction m_Debug_F9;
    readonly InputAction m_Debug_F10;
    readonly InputAction m_Debug_F11;
    readonly InputAction m_Debug_F12;
    public struct DebugActions {
        @Controls m_Wrapper;
        public DebugActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @F1 => m_Wrapper.m_Debug_F1;
        public InputAction @F2 => m_Wrapper.m_Debug_F2;
        public InputAction @F3 => m_Wrapper.m_Debug_F3;
        public InputAction @F4 => m_Wrapper.m_Debug_F4;
        public InputAction @F5 => m_Wrapper.m_Debug_F5;
        public InputAction @F6 => m_Wrapper.m_Debug_F6;
        public InputAction @F7 => m_Wrapper.m_Debug_F7;
        public InputAction @F8 => m_Wrapper.m_Debug_F8;
        public InputAction @F9 => m_Wrapper.m_Debug_F9;
        public InputAction @F10 => m_Wrapper.m_Debug_F10;
        public InputAction @F11 => m_Wrapper.m_Debug_F11;
        public InputAction @F12 => m_Wrapper.m_Debug_F12;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance) {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null) {
                @F1.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF1;
                @F1.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF1;
                @F1.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF1;
                @F2.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF2;
                @F2.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF2;
                @F2.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF2;
                @F3.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF3;
                @F3.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF3;
                @F3.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF3;
                @F4.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF4;
                @F4.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF4;
                @F4.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF4;
                @F5.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF5;
                @F5.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF5;
                @F5.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF5;
                @F6.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF6;
                @F6.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF6;
                @F6.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF6;
                @F7.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF7;
                @F7.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF7;
                @F7.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF7;
                @F8.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF8;
                @F8.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF8;
                @F8.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF8;
                @F9.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF9;
                @F9.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF9;
                @F9.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF9;
                @F10.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF10;
                @F10.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF10;
                @F10.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF10;
                @F11.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF11;
                @F11.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF11;
                @F11.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF11;
                @F12.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF12;
                @F12.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF12;
                @F12.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF12;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null) {
                @F1.started += instance.OnF1;
                @F1.performed += instance.OnF1;
                @F1.canceled += instance.OnF1;
                @F2.started += instance.OnF2;
                @F2.performed += instance.OnF2;
                @F2.canceled += instance.OnF2;
                @F3.started += instance.OnF3;
                @F3.performed += instance.OnF3;
                @F3.canceled += instance.OnF3;
                @F4.started += instance.OnF4;
                @F4.performed += instance.OnF4;
                @F4.canceled += instance.OnF4;
                @F5.started += instance.OnF5;
                @F5.performed += instance.OnF5;
                @F5.canceled += instance.OnF5;
                @F6.started += instance.OnF6;
                @F6.performed += instance.OnF6;
                @F6.canceled += instance.OnF6;
                @F7.started += instance.OnF7;
                @F7.performed += instance.OnF7;
                @F7.canceled += instance.OnF7;
                @F8.started += instance.OnF8;
                @F8.performed += instance.OnF8;
                @F8.canceled += instance.OnF8;
                @F9.started += instance.OnF9;
                @F9.performed += instance.OnF9;
                @F9.canceled += instance.OnF9;
                @F10.started += instance.OnF10;
                @F10.performed += instance.OnF10;
                @F10.canceled += instance.OnF10;
                @F11.started += instance.OnF11;
                @F11.performed += instance.OnF11;
                @F11.canceled += instance.OnF11;
                @F12.started += instance.OnF12;
                @F12.performed += instance.OnF12;
                @F12.canceled += instance.OnF12;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IPlayerActions {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRewind(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
    }
    public interface IDebugActions {
        void OnF1(InputAction.CallbackContext context);
        void OnF2(InputAction.CallbackContext context);
        void OnF3(InputAction.CallbackContext context);
        void OnF4(InputAction.CallbackContext context);
        void OnF5(InputAction.CallbackContext context);
        void OnF6(InputAction.CallbackContext context);
        void OnF7(InputAction.CallbackContext context);
        void OnF8(InputAction.CallbackContext context);
        void OnF9(InputAction.CallbackContext context);
        void OnF10(InputAction.CallbackContext context);
        void OnF11(InputAction.CallbackContext context);
        void OnF12(InputAction.CallbackContext context);
    }
}
