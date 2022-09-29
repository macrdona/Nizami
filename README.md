# Nizami

**Git Collaboration Workflow**

What is git fetch vs pull?
Git Fetch is the command that tells the local repository that there are changes available in the remote repository without bringing the changes into the local repository. Git Pull on the other hand brings the copy of the remote directory changes into the local repository.

A common Git collaboration workflow is:

    1. Fetch and merge changes from the remote. (You can also run 'git pull' which git pull = git fetch + git merge) 
    2. Create a branch to work on a new project feature
    3. Develop the feature on a branch and commit the work
    4. Fetch and merge from the remote again (in case new commits were made)(You can also run 'git pull' which git pull = git fetch + git merge) 
    5. Push branch up to the remote for review

Steps 1 and 4 are a safeguard against merge conflicts, which occur when two branches contain file changes that cannot be merged with the git merge command.

**Project Description**

The purpose of this project is to create an e-commerce website using the .NET Framework, which follows the Model-View-Controller(MVC) architecture. NOTE: This project was created for a college course, and it is not meant to be used for commercial purposes. 

**Frameworks/Software**

This is a list of the various software and languages used to create the website.

- .NET (Version 3.1), C#
- HTML5, CSS, JavaScript, Bootstrap (Version 5.1)
- Visual Studio 2022, Microsoft SQL Server Management Studio 18, SQL Server 2019
- Git & GitHub
