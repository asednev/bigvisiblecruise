# What Is BVC? #

BVC simply shows the status of your build at a specific moment in time. It's either green, yellow, or red. BVC will display all of the projects that are at the url that you provide.

BVC has a very simple and informative interface. A new row is added to the screen for each of the projects hosted in Cruise Control. The color of each row indicates the status of the build.

| **Color** | **Meaning** |
|:----------|:------------|
|Green      |Successful Build|
|Yellow     |Building     |
|Red        |Broken Build or Exception|
|White      |Unknown (or any other value)|

BVC was intended to run full-screen on a dedicated monitor.

The default BVC setup will point to the CCNet Live site.

![http://farm3.static.flickr.com/2015/2514731478_13114b868d.jpg](http://farm3.static.flickr.com/2015/2514731478_13114b868d.jpg)

# Setting Up BVC #

Setting up the application is easy. Very Easy. Copy the distribution from the Downloads page (http://code.google.com/p/bigvisiblecruise/downloads), unzip it, and run BigVisibleCruise.exe.

# Shortcuts #
All the interaction with BVC can be done easily using keyboard shortcuts. There are only a few things that you can do, so these key combos are displayed on the bottom of the screen in very small type.

| **Shortcut Key** | **Functionality** |
|:-----------------|:------------------|
|F5                |Forces a refresh (regardless of poll interval)|
|F11               |Toggle Fullscreen Mode|
|F12               |Open the settings window|

# Configuring BVC #

The "Open BVC Settings" link (or F12) brings up the configuration...

http://farm4.static.flickr.com/3174/2566075209_d3bab2f83e.jpg?v=0

The options that are available are:

| **Field** | **Meaning** |
|:----------|:------------|
|Dashboard Url|This is the url to the Cruise dashboard (e.g. http://ccnetlive.thoughtworks.com/ccnet) |
|Check Status|The slider will adjust the frequency that BVC will poll for status updates.|
|Visual Appearance|The view for seeing the current status. If you have multiple projects, they can have a stacked view or a uniform view.|

The "Validate Url" link will check for successful communication with the Cruise dashboard. If something goes wrong, you will receive an error message regarding the issue.

The "Save" button will save the valid settings. If the Dashboard Url is not valid, it **will not** be saved.

Clicking the save button will apply changes immediately.

# Dependencies For Running BVC #

The Big Visible Cruise display makes use of the REST-style interface exposed from Cruise. All of the recent Cruise builds should support this interface. To see if your Cruise instance exposes this interface, try and browse to ...

  * `http://<server>/<ccnet dir>/XmlStatusReport.aspx`

You'll also need .Net 3.5 installed.

# Developing For BVC #

The source is provided as a VS2008 solution.

If you would like to submit modifications, patches are appreciated. If you think something can be done better, please feel free to tell me. I'm a WPF newb, so I'm sure I've made a lot of mistakes.

If you are submitting a patch, please include the associated tests.

If you have an idea for a visualization, feel free to hack one together and send it to me. There's a lot of improvement that can be done here.