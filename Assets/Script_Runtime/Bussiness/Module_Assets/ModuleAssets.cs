using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

    public class ModuleAssets {
        Dictionary<string, GameObject> entities;
        Dictionary<string, GameObject> uiPrefabs;
        AsyncOperationHandle entityPtr;
        AsyncOperationHandle uiPrefabPtr;
        public ModuleAssets() {
            entities = new Dictionary<string, GameObject>();
            uiPrefabs = new Dictionary<string, GameObject>();
        }
        public void Load() {
            // {
            //     AssetLabelReference labelReference = new AssetLabelReference();
            //     labelReference.labelString = "Entity";
            //     var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
            //     var list = ptr.WaitForCompletion();
            //     foreach (var go in list) {
            //         entities.Add(go.name, go);
            //     }
            //     this.entityPtr = ptr;
            // }
            
            {
                // 从`硬盘`加载到`内存`
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "UI";
                var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = ptr.WaitForCompletion();
                foreach (var go in list) {
                    uiPrefabs.Add(go.name, go);
                }
                this.uiPrefabPtr = ptr;
            }
        }

        public void Unload() {
            if (entityPtr.IsValid()) {
                Addressables.Release(this.entityPtr);
            }

            if (uiPrefabPtr.IsValid()) {
                Addressables.Release(this.uiPrefabPtr);
            }

        }


        public bool TryGetEntity(string name, out GameObject entity) {
            return entities.TryGetValue(name, out entity);
        }
        public bool TryGetUIPrefab(string name, out GameObject prefab) {
            return uiPrefabs.TryGetValue(name, out prefab);
        }
    }