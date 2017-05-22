Firebase Unity SDK
==================

The Firebase Unity SDK provides Unity packages for the following Firebase
features on *iOS* and *Android*:

| Feature                            | Unity Package                     |
|:----------------------------------:|:---------------------------------:|
| Firebase Analytics                 | FirebaseAnalytics.unitypackage    |
| Firebase Authentication            | FirebaseAuth.unitypackage         |
| Firebase Realtime Database         | FirebaseDatabase.unitypackage     |
| Firebase Invites and Dynamic Links | FirebaseInvites.unitypackage      |
| Firebase Messaging                 | FirebaseMessaging.unitypackage    |
| Firebase Realtime Database         | FirebaseDatabase.unitypackage     |
| Firebase Remote Config             | FirebaseRemoteConfig.unitypackage |
| Firebase Storage                   | FirebaseStorage.unitypackage      |

## AdMob

The AdMob Unity plugin is distributed separately and is available from the
[AdMob Get Started](https://firebase.google.com/docs/admob/unity/start) guide.

## Stub Implementations

Stub (non-functional) implementations are provided for convenience when
building for Windows, OSX and Linux so that you don't need to conditionally
compile code when also targeting the desktop.

Setup
-----

You need to follow the
[SDK setup instructions](https://firebase.google.com/preview/unity).
Each Firebase package requires configuration in the
[Firebase Console](https://firebase.google.com/console).  If you fail to
configure your project your app's initialization will fail.

Support
-------

[Firebase Support](http://firebase.google.com/support/)

Release Notes
-------------
## 3.0.3
  - Overview
    - Bug fixes for Auth.
  - Changes
    - Auth: Fixed a crash caused by a stale memory reference when a
      firebase::auth::Auth object is destroyed and then recreated for the same
      App object.
    - Auth: Fixed potential memory corruption when AuthStateListener is
      destroyed.
    - Auth: Fixed occasional crash in Unity editor when using Auth sign-in
      methods.
## 3.0.2
  - Overview
    - Bug fixes for Auth, Database, Invites, Messaging, Storage, and a general
      fix, plus improved compatibility with Unity 5.6 when using the GoogleVR
      SDK.
  - Changes
    - General (Android): Fixed unhandled exception if FirebaseApp creation
      fails due to an out of date Google Play services.
    - General (Android): Fixed Google Play Services updater crash when clicking
      outside of the dialog on Android 4.x devices.
    - Auth: Fixed user being invalidated when linking a credential fails.
    - Auth: Fixed an occasional crash when events are fired.  This could
      manifest in a crash when signing in.
    - Auth: Deprecated FirebaseUser.RefreshToken.
    - Database: Fixed an issue which caused the application to manually
      refresh the auth token.
    - Messaging: Fixed incorrectly notifying the app of a message when a
      notification is received while the app is in the background and the app
      is then opened by via the app icon rather than the notification.
    - Invites (iOS): Fixed an issue which resulted in the app delegate method
      application:openURL:sourceApplication:annotation: not being called
      when linking the invites library.  This caused the Facebook SDK login
      flow to fail.
    - Storage: Fixed a bug that prevented the construction of Metadata without
      a storage reference.
    - Editor (Android): Fixed referenced Android dependencies in maven
      where the POM references a specific version e.g '[1.2.3]'.
    - Editor (iOS): Improved compatibility with Unity 5.6's Cocoapods support
      required to use the GoogleVR SDK.
    - Editor (Android): Fixed Android dependency resolution when the bundle ID
      is modified.

## 3.0.1
  - Overview
    - Fixed Google Play Services checker on Android and improved Android
      build configuration checks.
  - Changes
    - (Android): Fixed Google Play Services checker on Android.  Previously
      when Google Play Services was out of date,
      FirebaseApp.CheckDependencies() incorrectly returned
      DependencyStatus.Available.
    - Editor (Android): Added check for auto-resolution being enabled in the
      Android Resolver.
      If auto-resolution is disabled by the user or by another plugin
      (e.g Google Play Games), the user is warned about the configuration
      problem and given the opportunity to fix it.
    - (Android) Fixed single architecture builds when using Gradle.
    - (Android) Resolved an issue which caused the READ_PHONE_STATE
      permission to be requested.

## 3.0.0
  - Overview
    - Streamlined editor integration, build support and some bug fixes for
      Auth, Database, Messaging, Invites and Storage.
  - Changes
    - Added link.xml files to allow byte stripping to be enabled.
    - Fixed issues with Android builds when targeting a single ABI.
    - Auth: Fixed race condition when accessing user properties.
    - Auth: Added SetCurrentScreen() method.
    - Database: Resolved issue where large queries resulted in empty results.
    - Database: Fixed an issue which prevented saving boolean values.
    - Mesaging: Fixed issue with initialization on iOS that caused problems
      with other SDKs.
    - Invites: Fixed issue with initialization on iOS that caused problems
      with other SDKs.
    - Storage: Fixed a bug which prevented download URLs from containing
      slashes.
    - Storage: Fixed a bug on iOS which caused networking to fail when the
      full .NET 2.0 is used.
    - Editor: Added process of cleaning stale / moved files when upgrading
      to a newer plugin version.
    - Editor: Automated Cocoapod tool installation and improved Pod tool
      detection when using RVM.  This enables iOS projects to build with
      Unity Cloud Build.
    - Editor: Added support for pods that reference static libraries.
    - Editor: Bundle ID selection dialog for iOS and Android is now displayed
      when the project bundle ID doesn't match the Firebase configuration.
    - Editor: Added experimental support for building with Proguard stripping
      enabled.
    - Editor: Fixed Android package (AAR) synchronization when the project
      bundle ID is modified.
    - Editor: Fixed clean up of stale AAR dependencies when users change
      Android SDK versions.
    - Editor: Android Jar Resolver now remembers - for the editor session -
      which AARs to keep when new AARs are available compared to what is
      included in a project.
    - Editor: Added support for projects that use Google Play Services at
      different versions.
    - Editor: Fixed minor issue with the Firebase window not being repainted as
      Firebase configuration files are added to or removed from a project.
    - Desktop: Added fake - but valid - JWT in the Authentication mock.


## 1.1.2
  - Overview
    - Fix for a major bug causing Auth to hang, as well as other bug fixes.
  - Changes
    - Auth: Fixed a potential deadlock when running callbacks registered via
      Task.ContinueWith()
    - Auth: (Android) Fixed an error in `Firebase.Auth.FirebaseUser.PhotoUrl`.
    - Messaging: (iOS) Removed hard dependency on Xcode 8.
    - Messaging: (Android) Fixed an issue where the application would receive an
      empty message on startup.

## 1.1.1
  - Overview
    - Bug fixes for the editor plugin, Firebase Authentication, Messaging,
      Invites, Real-Time Database and Storage.
  - Changes
    - Fixed an issue in the editor plugin that caused an exception to be
      thrown when the project bundle ID didn't match a bundle ID in the Android
      configuration file (google-services.json).
    - Fixed a bug in the editor plugin that caused a stack overflow when
      multiple iOS configuration files (GoogleServices-Info.plist) are
      present in a project.
    - Auth: (Android) Fixed an issue that caused a Task to never complete
      when signing in while a user is already signed in.
    - Auth: Renamed the Auth.UserProfile.ProtoUri property to
      Auth.UserProfile.ProtoUrl in order to be consistent with the other URL
      properties across the SDK.
    - Messaging / Invites: Fixed an issue with method swizzling that caused
      some of the application's UIApplicationDelegate methods to not be called.
    - Storage: The Storage  plugin was using a Unity API that is only
      present in Unity 5.4. We have modified the component so that it is now
      backwards compatible with previous versions of Unity.
    - Real-Time Database: Fixed an issue that prevented saving floating point
      values.

## 1.1.0
  - Overview
    - Added support for Firebase Storage and bug fixes.
  - Changes
    - Added support for Firebase Storage.
    - Fixed crash in Firebase Analytics when logging arrays of parameters.
    - Fixed crash in Firebase Messaging when receiving messages with empty
      payloads on Android.
    - Fixed random hang when initializing Firebase Messaging on iOS.
    - Fixed topic subscriptions in Firebase Messaging.
    - Fixed an issue that resulted in a missing app icon when using Firebase
      Messaging on Android.
    - Fixed exception in error message construction when FirebaseApp
      initialization fails.
    - Fixed reporting of null events in the Firebase Realtime Database.
    - Fixed unsubscribe for complex queries in the Firebase Realtime Database.
    - Fixed service account authentication in the Firebase Realtime Database.
    - Fixed Firebase.Database.Unity being stripped from iOS builds.
    - Fixed support for building with Firebase plugins in Microsoft
      Visual Studio.
    - Fixed scene transitions causing event routing to break across all
      components.
    - Changed editor plugins for Firebase Authentication and Invites to
      return success for all operations instead of raising exceptions.
    - Changed editor plugin to read JAVA_HOME from the Unity editor
      preferences.
    - Changed editor plugin to scan all google-services.json and
      GoogleService-Info.plist files in the project and select the config file
      matching the project's current bundle ID.
    - Improved the performance of AAR / JAR resolution when the Android config
      is selected and auto-resolution is enabled.
    - Improved error messages in the editor plugin.
  - Known Issues
    - Proguard is not integrated into Android builds. We have distributed
      proguard files that can be manually integrated into Android builds
      within AAR files matching the following pattern in each
      Unity package:
      `Firebase/m2repository/com/google/firebase/firebase-*-unity/*firebase-*.srcaar`
    - Incompatible AARs are not resolved correctly when building for Android.
      This can require manual intervention when using multiple plugins
      (e.g Firebase + AdMob + Google Play Games).  A workaround is documented
      on the
      [AdMob Unity plugin issue tracker](https://github.com/googleads/googleads-mobile-unity/issues/314).

## 1.0.1
  - Overview
    - Bug fixes.
  - Changes
    - Fixed Realtime Database restricted access from the Unity Editor on
      Windows.
    - Fixed load and build errors when iOS support is not installed.
    - Fixed an issue that prevented the creation of multiple FirebaseApp
      instances and customization of the default instance on iOS.
    - Removed all dependencies on Python for Android resource generation on
      Windows.
    - Fixed an issue with pod tool discovery when the Ruby Gem binary directory
      is modified from the default location.
    - Fixed problems when building for Android with the IL2CPP scripting
      backend.
  - Known Issues
    - Proguard is not integrated into Android builds. We have distributed
      proguard files that can be manually integrated into Android builds
      within AAR files matching the following pattern in each
      Unity package:
      `Firebase/m2repository/com/google/firebase/firebase-*-unity/*firebase-*.srcaar`

## 1.0.0
  - Overview
    - First public release with support for Firebase Analytics,
      Authentication, Real-time Database, Invites, Dynamic Links and
      Remote Config.
      See our
      [setup guide](https://firebase.google.com/docs/unity/setup) to
      get started.
  - Known Issues
    - Proguard is not integrated into Android builds.  We have distributed
      proguard files that can be manually integrated into Android builds
      within AAR files matching the following pattern in each
      Unity package:
      `Firebase/m2repository/com/google/firebase/firebase-*-unity/*firebase-*.srcaar`
