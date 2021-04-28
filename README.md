# Assignment 1
 BIS Unity intro assignment

## to submit  your assigment
in short:
- clone this repository
- create your branch (the branch name should be “firstname_lastname”)
- change code on your branch
- commit and push the code on your branch

if you use GitHub Desktop
- [Cloning a repository from GitHub to GitHub Desktop](https://help.github.com/en/desktop/contributing-to-projects/cloning-a-repository-from-github-to-github-desktop)
- [Creating a branch for your work](https://help.github.com/en/desktop/contributing-to-projects/creating-a-branch-for-your-work)
- [Committing and reviewing changes to your project](https://help.github.com/en/desktop/contributing-to-projects/committing-and-reviewing-changes-to-your-project)

## Fix: Failed to load window layout

In case you are getting the "Failed to load window layout" error when opening the project do the following to fix this.

1. Close Unity/ Unity Hub.
2. Open the following folder
   1. If you are using <kbd>Windows</kbd> open `AppData\Roaming\Unity\Editor-5.x\Preferences\Layouts\default`.
   2. If you are using <kbd>Mac</kbd> open `~/Library/Preferences/Unity/Editor-5.x/Layouts/default`.
3. Delete the file `LastLayout.dwlt`.
4. Copy the file `Default.wlt` and paste it into `path/to/BIS21-assigment1-unity-intro/Library`.
5. Delete `CurrentLayout-default.dwlt`.
6. Rename `Default.wlt` to `CurrentLayout-default.dwlt`.
7. Back when opening the Unity project go to the _Layout_ dropdown (top-right corner of the window) and click on _Revert Factory Settings..._.

![Screenshot 2021-04-23 172141](https://user-images.githubusercontent.com/39165900/115893444-790e7500-a458-11eb-8d9d-8a69485446aa.png)

Now you should be able to open up the project without any errors 🚀

[Source](https://medium.com/@siqueiragleidson/unity-failed-to-load-windows-layout-when-start-a-new-project-b142f31c632a)

BTW this error gets caused due to the _UserSettings_ folder (now deleted in this repo) which got introduced in Unity 2020. Be sure when publishing to GitHub you have the newest [`.gitignore`](https://github.com/github/gitignore/blob/master/Unity.gitignore) which also excludes the _UserSettings_ folder.
