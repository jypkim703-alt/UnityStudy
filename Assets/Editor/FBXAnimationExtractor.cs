using UnityEngine;
using UnityEditor;
using System.IO;

public class FBXAnimationExtractor
{
    [MenuItem("Tools/Extract Animations From FBX")]
    static void ExtractAnimations()
    {
        Object selected = Selection.activeObject;

        if (selected == null)
        {
            Debug.LogError("FBX를 선택해주세요.");
            return;
        }

        string assetPath = AssetDatabase.GetAssetPath(selected);

        if (!assetPath.EndsWith(".fbx", System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.LogError("FBX 파일이 아닙니다.");
            return;
        }

        // FBX 안의 모든 AnimationClip 가져오기
        Object[] assets = AssetDatabase.LoadAllAssetsAtPath(assetPath);

        // 저장 폴더 생성
        string folderPath = Path.GetDirectoryName(assetPath) + "/" + Path.GetFileNameWithoutExtension(assetPath) + "_Animations";

        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder(Path.GetDirectoryName(assetPath), Path.GetFileNameWithoutExtension(assetPath) + "_Animations");
        }

        int count = 0;

        foreach (Object asset in assets)
        {
            if (asset is AnimationClip clip)
            {
                // 미리보기 클립 제외
                if (clip.name.StartsWith("__preview__"))
                    continue;

                string newPath = folderPath + "/" + clip.name + ".anim";

                AnimationClip newClip = Object.Instantiate(clip);
                AssetDatabase.CreateAsset(newClip, newPath);

                count++;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"애니메이션 {count}개 추출 완료 → {folderPath}");
    }
}