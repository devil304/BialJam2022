using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputLowerManager : MonoBehaviour
{
    [SerializeField] InputGather[] _playersInputs;
    [SerializeField] bool _enableDebug = false;

    PlayerInputBaseMap[] _playerMaps;
    List<KeyValuePair<InputDevice,int>> _connectedDevices = new List<KeyValuePair<InputDevice,int>>();
    InputDeviceChange[] _assignMapChanges = {InputDeviceChange.Added, InputDeviceChange.Reconnected},
    _unassignMapChanges = {InputDeviceChange.Removed, InputDeviceChange.Disconnected};

    void Awake()
    {
        Application.targetFrameRate = 60;
        _playerMaps = new PlayerInputBaseMap[2];
        for(int i=0;i<_playerMaps.Length;i++){
            _playerMaps[i] = new PlayerInputBaseMap();
            _playerMaps[i].Disable();
            _playerMaps[i].Movement.Enable();
            _playerMaps[i].Misc.Enable();
            _playerMaps[i].devices = null;
        }

        for(int i=0;i<_playersInputs.Length;i++){
            _playersInputs[i].RegisterMap(_playerMaps[i]);
        }
        
        //Test only
        #if UNITY_EDITOR
        _playerMaps[0].Movement.Roll.performed += Movement1Performed;
        _playerMaps[1].Movement.Roll.performed += Movement2Performed;
        #endif

        foreach(var device in InputSystem.devices){
            DeviceStateChanged(device,InputDeviceChange.Added);
        }
        InputSystem.onDeviceChange += DeviceStateChanged;
    }

    #region  Test
    //Test only
    #if UNITY_EDITOR
    private void Movement1Performed(InputAction.CallbackContext obj)
    {
        if(_enableDebug)
            Debug.Log($"P1 Movement: {obj.ReadValue<Vector2>().ToString()}");
    }

    private void Movement2Performed(InputAction.CallbackContext obj)
    {
        if(_enableDebug)
            Debug.Log($"P2 Movement: {obj.ReadValue<Vector2>().ToString()}");
    }
    #endif
    #endregion

    private void DeviceStateChanged(InputDevice device, InputDeviceChange change)
    {
        if(!device.displayName.ToLower().Contains("xbox")) return;
        if(_assignMapChanges.Contains(change) && !_connectedDevices.Any(kvp=>kvp.Key.deviceId == device.deviceId)){
            int i =0;
            for(i=0;i<_playerMaps.Length;i++){
                if(_playerMaps[i].devices==null)
                    break;
            }
            _playerMaps[i].devices = new ReadOnlyArray<InputDevice>(new InputDevice[]{device});
            _playerMaps[i].Enable();
            _connectedDevices.Add(new KeyValuePair<InputDevice, int>(device,i));
            if(_enableDebug)
                Debug.Log($"Device {device.displayName};{device.deviceId}  added, to map {i}");
        }else if(_unassignMapChanges.Contains(change)){
            var KVP = _connectedDevices.FirstOrDefault(kv=>kv.Key.deviceId == device.deviceId);
            if(KVP.Key==null){
                if(_enableDebug)
                    Debug.Log($"Device {device.displayName} not found in base, id {device.deviceId}");
                return;
            }
            _playerMaps[KVP.Value].Disable();
            _playerMaps[KVP.Value].devices = null;
            _connectedDevices.Remove(KVP);
            if(_enableDebug)
                Debug.Log($"Device {device.displayName};{device.deviceId} removed, from map {KVP.Value}");
        }
    }
}
