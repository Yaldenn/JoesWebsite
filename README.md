## How to set up the website on your device:

Open visual studio 2022

Click Clone a repository

Copy and paste the link below into the Repository location  
https://github.com/Yaldenn/JoesWebsite.git

Click Clone

At the top of Visual Studio, click Tools > NuGet Package Manager > Package Manager Console. This should open a terminal at the bottom of your screen.

Run these four commands by copying and pasting them into the Console and pressing return:

add-migration WorkingMigration -context rzawebcontext  
update-database -context rzawebcontext  
add-migration WorkingAspMigration -context applicationdbcontext  
update-database -context applicationdbcontext  

The project should now be set up, run the website by pressing F5 or clicking the big green triangle at the top of the page.

You will need to create an account to use some of the features, for this you can use a fake email such as test@test.com

## More information:
This is a prototype for a fake company called Riget Zoo Adventures (RZA), which was developed over a 30-hour period split across 4 weeks alongside documenting it and creating test logs. I was allowed access to the internet during this time, but was not allowed to take this project out of the exam and work on it at home or bring anything into the exam. To make this website i used Asp.net MVC. There are many things I would change about this website, but just did not have enough time for.
