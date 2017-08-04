using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Login {
    public class AccountHandler : MonoBehaviour{

        public UnityEvent SaveData;
        public UnityEvent LoadData;

        private void Start() {
            if (SaveData == null) SaveData = new UnityEvent();
            if (LoadData == null) LoadData = new UnityEvent();
            if (PlayerHandler.Instance.IsSceneBeingLoaded) {
                PlayerState.Instance.LocalData = PlayerHandler.Instance.LocalData_Copy;
                PlayerHandler.Instance.IsSceneBeingLoaded = false;
            }
        }

        public void Save() {
            PlayerHandler.Instance.SaveData();
            SaveData.Invoke();
        }

        public void Load() {
            PlayerHandler.Instance.LoadData();
            PlayerHandler.Instance.IsSceneBeingLoaded = true;
            LoadData.Invoke();
        }

    }
}
