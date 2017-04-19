# The Namegame: C# / Xamarin

Leading scientists have proven, via science, that learning your coworkers names while starting a new job is useful. Your test project is to make it happen! The api is located at [https://www.willowtreeapps.com/api/v1.0/profiles](https://www.willowtreeapps.com/api/v1.0/profiles).


## Your mission

We're only asking you to implement this on one of the platforms (iOS, Android, or UWP), but you are welcome to do as many as you'd like. All of the projects are already set up with MVVMCross to make working with multiple platforms easier, but you are welcome to remove it if you'd like to use something different.

To spruce things up, implement a few features of your choice.

1. Stat tracking. How many correct / incorrect attempts did the user make? How long does it take on average for a person to identify the subject?
2. Spruce up transitions and image loading.  Don't let images pop in and show the user that loading is happening
3. Game modes:
    * Mat(t) Mode. Roughly 90% of our co-workers are named Mat(t), so add a challenge mode where you only present the users with A Mat(t).
    * Reverse mode: Show one face with 5 names. Ask the user to identify the correct name.
4. Hint mode. As people wait, faces disappear until only the correct one is left.
5. Insert your own idea here!


## Notes:
1. This exercise should take no more than 8 hours, please do not spend more than that!
2. The app needs to support portrait and landscape on all mobile devices, and resizing for UWP. On Android, we ask that you do this without using the manifest flag android:configChanges. Note that we're curious how you might go about solving for destroyed activities and fragments. 

When reviewing your project, we will be focusing on the following areas:
* Code architecture
* Code quality
* Code correctness
* Overall creativity
Note: Feel free to include a text file describing your thoughts and approach if you feel that's appropriate. 

Good luck and have fun!

## My Approach:
I approached this project with the goal of establishing a strong data-binding relationship that allowed for functionality such a binding-driven animations based on click events.
This goal required the creation of custom android views, which responded to changes in the underlying data-contexts to produce color filter animations on top of images.
Additionally, I set out to provide a clean and self-evident navigation and interface to allow users to pick up the app and use it without needing excessive trial-and-error or tutorials.
My approach to supporting various viewport types was to utilize android's support of alternative layout folders to automatically choose layouts based on viewport characteristics.
This approach to viewport support required a small bit of checking within the attached data-contexts to prevent view flushing which would reset the view anytime it needed to reload for any reason.
I believe my work on this project ended with a strong application with an intuitive interface and high usability to the end user trying to learn the names of his/her co-workers.