# TweetGrabber

This repository makes it possibly to enter in a person's twitter handle and download an organized text document of their tweets.
The project was originally created as a way to help with testing Markov Chains but it has other uses as well. 

Starting the project:
In order to use this program, you must create a text file called "settings.txt" in the base directory. Within this text file, you'll be entering your credentials from the twitter dev account as follows:
* Line 1: customerKey
* Line 2: customerSecret
* Line 3: accessToken
* Line 4: accessSecret

With that taken care of, the only thing left is your person's twitter user ID.
If you don't have the user's ID, gettwitterid.com is an easy way to get the numeric code for whichever account you're looking for.
This number needs to be entered into the program.cs file on line 22. Once that's done, run the program and you'll be good to go!
