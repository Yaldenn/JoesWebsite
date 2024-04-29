Open visual studio 2022

Click Clone a repository

Copy and paste the link below into the Repository location  
https://github.com/Yaldenn/JoesWebsite.git

Click Clone

At the top of Visual Studio, click Tools > NuGet Package Manager > Package Manager Console. This should open a terminal at the bottom of your screen.

Run these four commands by copying and pasting them into the Console and pressing return:

add-migration WorkingMigration -context rzawebcontext  
update-database -context rzawebcontext  
add migration WorkingAspMigration -context applicationdbcontext  
update-database -context applicationdbcontext  

The project should now be set up, run the website by pressing F5 or clicking the big green triangle at the top of the page.
