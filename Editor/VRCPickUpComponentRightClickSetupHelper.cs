#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Components;

namespace PogapogaEditor.RightClick
{
    /// <summary>
    /// VRC Pickupに関するComponentを追加する
    /// </summary>
    public class VRCPickUpComponentRightClickSetupHelper : MonoBehaviour
    {
        #region // 重力有効
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/BoxCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(UseGravity)", validate = false, priority = int.MinValue)]
        public static void SetBoxColliderRightClickUseGravity()
        {
            SetRightClickComponent<BoxCollider>(gravityFlag: true, kinematicFlag: false);
        }
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/SphereCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(UseGravity)", validate = false, priority = int.MinValue)]
        public static void SetSphereColliderRightClickUseGravity()
        {
            SetRightClickComponent<SphereCollider>(gravityFlag: true, kinematicFlag: false);
        }
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/CapsuleCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(UseGravity)", validate = false, priority = int.MinValue)]
        public static void SetCapsuleColliderRightClickUseGravity()
        {
            SetRightClickComponent<CapsuleCollider>(gravityFlag: true, kinematicFlag: false);
        }
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/MeshCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(UseGravity)", validate = false, priority = int.MinValue)]
        public static void SetMeshColliderRightClickUseGravity()
        {
            SetRightClickComponent<MeshCollider>(gravityFlag: true, kinematicFlag: false);
        }
        #endregion
        #region // 重力無効
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/BoxCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(IsKinematic)", validate = false, priority = int.MinValue)]
        public static void SetBoxColliderRightClickIsKinematic()
        {
            SetRightClickComponent<BoxCollider>(gravityFlag: false, kinematicFlag: true);
        }
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/SphereCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(IsKinematic)", validate = false, priority = int.MinValue)]
        public static void SetSphereColliderRightClickIsKinematic()
        {
            SetRightClickComponent<SphereCollider>(gravityFlag: false, kinematicFlag: true);
        }
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/CapsuleCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(IsKinematic)", validate = false, priority = int.MinValue)]
        public static void SetCapsuleColliderRightClickIsKinematic()
        {
            SetRightClickComponent<CapsuleCollider>(gravityFlag: false, kinematicFlag: true);
        }
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/MeshCollider,Rigidbody,VRC Pickup,OBjectSyncをセットする(IsKinematic)", validate = false, priority = int.MinValue)]
        public static void SetMeshColliderRightClickIsKinematic()
        {
            SetRightClickComponent<MeshCollider>(gravityFlag: false, kinematicFlag: true);
        }
        #endregion

        /// <summary>
        /// 選択しているGameObjectにVRC Pickup、OBjectSyncをセットする
        /// </summary>
        [MenuItem("GameObject/PogapogaTools/VRCPickupSetupHelper/VRC Pickup,OBjectSyncをセットする", validate = false, priority = int.MinValue)]
        public static void SetPickupAndObjectSync()
        {
            GameObject[] _targetObjects = Selection.gameObjects;
            foreach (GameObject targetObject in _targetObjects)
            {
                string componentName = "";
                if (targetObject.GetComponent<VRCPickup>() == null) { Undo.AddComponent(targetObject, typeof(VRCPickup)); componentName += $" {nameof(VRCPickup)}"; }
                if (targetObject.GetComponent<VRCObjectSync>() == null) { Undo.AddComponent(targetObject, typeof(VRCObjectSync)); componentName += $" {nameof(VRCObjectSync)}"; }
                EditorUtility.SetDirty(targetObject);
                if (componentName != "") { Debug.Log($"{targetObject.name}に{componentName} を追加しました"); }
                else { Debug.Log($"{targetObject.name}はセットアップ済みです"); }
            }
        }

        /// <summary>
        /// 配列内のGameObjectに指定したCollider、Rigidbody、VRC Pickup、OBjectSyncをセットする
        /// </summary>
        public static void SetVRCPickupComponent<TCollider>(GameObject[] _targetObjects, bool gravityFlag, bool kinematicFlag) where TCollider : UnityEngine.Collider
        {
            foreach (GameObject targetObject in _targetObjects)
            {
                string componentName = "";
                if (targetObject.GetComponent<TCollider>() == null) { Undo.AddComponent(targetObject, typeof(TCollider)); componentName += $" {typeof(TCollider).Name}"; }
                if (targetObject.GetComponent<Rigidbody>() == null) { 
                    Undo.AddComponent(targetObject, typeof(Rigidbody)); componentName += $" {nameof(Rigidbody)}";
                    targetObject.GetComponent<Rigidbody>().useGravity = gravityFlag;
                    targetObject.GetComponent<Rigidbody>().isKinematic = kinematicFlag;
                }
                if (targetObject.GetComponent<VRCPickup>() == null) { Undo.AddComponent(targetObject, typeof(VRCPickup)); componentName += $" {nameof(VRCPickup)}"; }
                if (targetObject.GetComponent<VRCObjectSync>() == null) { Undo.AddComponent(targetObject, typeof(VRCObjectSync)); componentName += $" {nameof(VRCObjectSync)}"; }
                EditorUtility.SetDirty(targetObject);
                if (componentName != "") { Debug.Log($"{targetObject.name}に{componentName} を追加しました"); }
                else { Debug.Log($"{targetObject.name}はセットアップ済みです"); }
            }
        }

        /// <summary>
        /// 選択しているGameObjectに指定したCollider、Rigidbody、VRC Pickup、OBjectSyncをセットする
        /// </summary>
        public static void SetRightClickComponent<TCollider>(bool gravityFlag, bool kinematicFlag) where TCollider : UnityEngine.Collider
        {
            GameObject[] _selectGameObject = Selection.gameObjects;
            SetVRCPickupComponent<TCollider>(_selectGameObject, gravityFlag, kinematicFlag);
            Debug.Log("セット完了");
        }
    }
}
#endif