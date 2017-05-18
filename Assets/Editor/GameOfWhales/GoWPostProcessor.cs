using UnityEditor;
using UnityEngine;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif
using System.Collections;
using System.IO;
using System.Xml;
using UnityEditor.Callbacks;

namespace GameOfWhales {
	public class GoWPostProcessor {

#if UNITY_IOS
        [PostProcessBuild(9999)]
		public static void OnPostprocessBuild(BuildTarget buildTarget, string pathToBuiltProject) {
			if (buildTarget == BuildTarget.iOS) {

				string plistPath = Path.Combine(pathToBuiltProject, "Info.plist");

				PlistDocument plist = new PlistDocument();
				plist.ReadFromString(File.ReadAllText(plistPath));

				PlistElementDict rootDict = plist.root;

				var buildKey = "UIBackgroundModes";
				var backgroundModes = rootDict.CreateArray(buildKey);
				backgroundModes.AddString ("remote-notification");

				File.WriteAllText(plistPath, plist.WriteToString());

				Debug.Log("GOW: Info.plist fixed");

				string projPath = Path.Combine(pathToBuiltProject, Path.Combine("Unity-iPhone.xcodeproj",  "project.pbxproj"));

				PBXProject project = new PBXProject();
				project.ReadFromString(File.ReadAllText(projPath));

				var googleServicesPlistPath = Path.Combine(Application.dataPath, Path.Combine("Editor", Path.Combine("GameOfWhales", "GoogleService-Info.plist")));
				
                string targetGUID = project.TargetGuidByName("Unity-iPhone");

				if (File.Exists(googleServicesPlistPath)) {
					var plistGuid = project.AddFile (googleServicesPlistPath, "GoogleService-Info.plist");
					project.AddFileToBuild(targetGUID, plistGuid);
					Debug.Log("GOW: GoogleService-Info.plist copied");
				} else {
					Debug.LogWarning(string.Format("GOW: GoogleService-Info.plist doesn't finded. Searched path : {0}", googleServicesPlistPath));
				}

				//Set -ObjC flag
				project.AddBuildProperty(targetGUID, "OTHER_LDFLAGS", "-ObjC"); 

				//Enable Modules
				project.SetBuildProperty(targetGUID, "CLANG_ENABLE_MODULES", "YES");

				//Add Frameworks
				project.AddFrameworkToProject(targetGUID, "UserNotifications.framework", true);
				project.AddFrameworkToProject(targetGUID, "AddressBook.framework", true);
				//Add Libraries
				project.AddFileToBuild(targetGUID, project.AddFile("usr/lib/libsqlite3.0.tbd", "Frameworks/libsqlite3.0.tbd", PBXSourceTree.Sdk));
				project.AddFileToBuild(targetGUID, project.AddFile("usr/lib/libz.1.2.8.tbd", "Frameworks/libz.1.2.8.tbd", PBXSourceTree.Sdk));


				string projectString = project.WriteToString ();

//				File.WriteAllText (Path.Combine (Application.dataPath, "test1.txt"), projectString);

				projectString = projectString.Replace ("SystemCapabilities = {\n", "SystemCapabilities = {\n\t\t\t\t\t\t\tcom.apple.Push = {\n\t\t\t\t\t\t\t\tenabled = 1;\n\t\t\t\t\t\t\t};");

				File.WriteAllText(projPath, projectString);

//				File.WriteAllText (Path.Combine (Application.dataPath, "test2.txt"), projectString);
			}
		}
#endif
	}
}
