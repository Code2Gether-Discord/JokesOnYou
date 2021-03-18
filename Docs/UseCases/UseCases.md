#Use Cases

### Admin
- Manage Jokes
- Manage Users
### Registered user.
- Favorite Jokes
- Like Joke
- Report Joke
- CRUD jokes
- Add or +1 tags on other people's jokes
### Guest
- Register
- View Jokes
- Sort jokes
  - By tags
  - By upload date
  - By Likes

## How to read:
#### Every use case contains three essential elements:
**The actor** The system user -- this can be a single person or a group of people interacting with the process.

**The goal** The final successful outcome that completes the process.

**The system** The process and steps taken to reach the end goal, including the necessary functional requirements and their anticipated behaviors.

# Guests
- Looking through jokes for a fun time
- Finding specific joke
- View Jokes based on tags
- Sort jokes
- Become a Registered user
- Find out how the website was made and by who
- Share Joke

###### Goal
Looking through jokes for a fun time
###### The system
- Come to the website and be greeted by a Reddit like page.  
- Here you can see a quick overview of jokes and the Likes for the joke.
- Press on a joke to have it expand and view the joke.
- If the joke has a Punchline click on it to expand.
- the more you scroll the more jokes you get to see.
- when trying to Like/report a joke you will be asked to register

###### Goal
Finding specific joke
###### The system
1. In the search bar search for tag or name of joke
2. get results based on search criteria in the view.

###### Goal
View Jokes based on tags
###### The system
1. Press on the category button to choose a Joke category
2. You will then see all jokes of the category in the view.

###### Goal
Sort jokes
###### The system
1. when viewing jokes you will be able to sort them by different attributes:
  - By Tags
  - By upload date
  - By Likes

###### Goal
Become a Registered user
###### The system
1. Go to the **Login Page**
2. Press **Register** button
3. be greeted with the register **form**, filling in all the info needed.
    - Name
    - password
    - double check password
    - email
4. press **submit**
5. verify e-mail
6. **login** with account

###### Goal
Find out how the website was made and by who
###### The system
1. go to the **About page**
2. see **who** made the website
3. what **tools** were used
4. **how** to help
5. Donate?

###### Goal
Share joke
###### The system
1. when viewing jokes There will be a button to share the joke
 - Through a direct link
 - Facebook
 - Twitter
 - Reddit
 - Email

# Registered user.
- Favorite Jokes
- Like/Dislike Joke
- Report Joke
- CRUD jokes
    - Create jokes
    - Edit jokes
    - Delete jokes
- Add or +1 Tags on other people's jokes
- Report a Tag for voilating rules

###### Goal
Favorite Jokes
###### The system
1. When **viewing** a joke press on the **Star button** to add it to your **favorites**
2. In your profile, you will find a **list** of all your **favorite** jokes

###### Goal
Like/Dislike Joke
###### The system
1. When **viewing** a joke you can **+1 or -1** a joke
2. Press on **arrow** up next to the joke to **+1** it
3. press on **arrow** down next to the joke to **-1** it
4. In your profile, you will find a list of all your **Liked/Disliked** jokes

###### Goal
Report Joke
###### The system
1. When viewing a joke and you think the joke is **violating** the websites **Guidelines**
2. press on the **flag icon** to **report** the joke
3. you will have to **select** which guideline is being violated
4. the joke will then be **flagged** for review by one of the **admins** of the site.

###### Goal
CRUD jokes
###### The system
1. Registered user is able to **CRUD** jokes:
2. Create
3. Read
4. Update
5. Delete
6. In your profile, you will find a button for **managing** your jokes
7. There you will find a **list** of all Jokes you have created.

###### Goal
Create jokes
###### The system
1. On the **Manage** jokes page you will find a button to **Create** a new Joke
2. When pressed it will redirect you to the Joke **Creation page**
3. Here you will give the joke a tags, Name, the joke Premise and punchline.
4. Press **create** to publish the joke.

###### Goal
Edit jokes
###### The system
1. Next to an **existing** joke you will be able to delete it or **edit** it.
2. press **Edit** and it will take you to the **Edit page** which is almost the same as Create except:
3. you will find **Save** in stead of **Create**
4. Delete will also be found on this page.

###### Goal
Delete jokes
###### The system
1. Next to an **existing** joke you will be able to **delete** it or edit it.
2. press **Delete** and it will **Prompt** you if you would like to Delete the joke, This can not be undone.
3. Or on the **Manage** page you will find the **Delete button**
4. press **Delete** and it will **Prompt** you if you would like to Delete the joke, This can not be undone.

###### Goal
Add or +1 Tags on other people's jokes
###### The system
1. When **viewing** a joke you can find a list of all the **tags** ?beneath? the joke
2. Press on a **existing** tag to +1 it and make it **move** to the front of the tags
3. if you want to **add** a tag press on the **+ button** next to the tags and fill in a name and press enter

###### Goal
Report a Tag for voilating rules
###### The system
1. When **viewing** a joke you can find a list of all the **tags** ?beneath? the joke
2. there is a **flag button** in the tag if that's pressed you can report a **tag** for being offensive.
3. you will have to **select** which guideline is being violated
4. the Tag will then be **flagged** for review by one of the **admins** of the site.


# Admin
- Manage Jokes
- Manage Users
- Review Joke Flags
- Review tag flags

###### Goal
Manage Jokes
###### The system
1. Login to your account.
2. press on the account settings button
3. press on manage jokes
4. from here you will see a list of all jokes
5. You can press on only view new jokes to only review new jokes.
6. press on a joke to Delete it.
7. Pick a reason why the joke was removed.
8. you can add your personal message.
9. the owner of the joke will get notified about the removal of the joke.
10. the joke will be sent together with the removal notification.
11. the user should get reprocussion, a strike and with 3 strikes banned from the website.

###### Goal
Manage Users
###### The system
1. Login to your account.
2. press on the account settings button
3. Press on Manage Users
4. see a list of all users
5. there will be buttons next to the user for removal or banning.

###### Goal
Review Joke Flags
###### The system
1. Login to your account.
2. press on the account settings button
3. Press review joke flags
4. here you will see a list of all flagged jokes.
5. you can manage the joke with deletion or dismiss the flag.
6. Deletion:
    - the owner of the joke will get notified about the removal of the joke.
    - the joke will be sent together with the removal notification.
    - the user should get reprocussion, a strike and with 3 strikes banned from the website.
7. if you dismiss the flag you will have to write a message why its not being removed.
8. the owner of the flag will get notified with the dismissal.

###### Goal
Review Tag Flags
###### The system
1. Login to your account.
2. press on the account settings button
3. Press review joke flags
4. here you will see a list of all flagged Tags.
5. you can manage the Tag with deletion or dismiss the flag.
6. Deletion:
    - the owner of the Tag will get notified about the removal of the Tag.
    - the Tag will be sent together with the removal notification.
    - the user should get reprocussion, a strike and with 3 strikes banned from the website.
7. if you dismiss the flag you will have to write a message why its not being removed.
8. the owner of the flag will get notified with the dismissal.