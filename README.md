## General information

Hello, thank you for being happy to help with feedback for my exams, I really appreciate it.  

You will need to download this project onto your device, instructions for this are at the bottom of this page.  

### There are two different feedback forms:  
The non-technical form can be found [Here](https://forms.office.com/Pages/ResponsePage.aspx?id=DQSIkWdsW0yxEjajBLZtrQAAAAAAAAAAAAO__XoDxItUOTYwTkNXOVJVVjJQREpaU0JHN0VOMlo5Vi4u)  
The technical form can be found [Here](https://forms.office.com/Pages/ResponsePage.aspx?id=DQSIkWdsW0yxEjajBLZtrQAAAAAAAAAAAAO__XoDxItUNE1aWTRVODU5UTY5N1JJRTdMRVpWWDJZRi4u)  

The technical form is meant to be if you are familiar with using asp.net MVC and c# in general, the non technical form can be taken by anyone.  
The forms do not overlap, so you can do both if you wish.

While filling out the non-technical form, you should focus on one to two specific sections of the website (for example the hotel booking system or the information pages), and should just leave blank or worry less about the details for the other pages and sections since there are too many questions to feasibly answer all of them to a good standard without it taking hours.

The sections to choose from include:
 - Layout  
 - Home page  
 - Zoo ticket booking    
 - Hotel room booking   
 - Information pages   
 - Legal pages   
 - Rewards system   
 - Profile pages   


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
This was developed over a 30-hour period split across 4 weeks alongside documenting it and creating test logs. I was allowed access to the internet during this time, but was not allowed to take this project out of the exam and work on it at home or bring anything into the exam. To make this website i used Asp.net MVC. There are many things I would change about this website, but just did not have enough time for.

I hope all of this make sense and i look forward to seeing the responses
