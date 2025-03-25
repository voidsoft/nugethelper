# Nuget Preview Generator Utility

A utility to help users quickly and easily generate preview NuGet packages and place
them in a local repository to allow easier debugging when the need arises to make changes
to a NuGet package as part of a change to another project.

## The Problem

In many situations writing code, you'll find a generic code repository, let's imagine a hypothetical **Company X** which has a repository *Company X Generic Code Package Y* which we'll call *Package Y*. This project contains code that's reasonably generic and designed for use across a number of different projects within Company X. 

Now lets imagine that as part of their work on *Project Z* a developer needs to make changes to *Package Y*. The usual way would be:

- Make the change to *Package Y*
- Publish a new version of *Package Y* 
- Consume the new version in *Project Z*
 
If the change required is simple then this is all well and good, but there are often situations where this could be quite time consuming. Sometimes the interdependencies between the packages might be quite complex. You may publish *Package Y* only to find that you're missing some vital code and you need to make further changes to *Package Y*, the overall result is that you may end up flooding your company's nuget feed with unnecessary packages and waste serious amounts of time publishing your changes.

## The Solution

*Nuget Preview Generator* is designed so that a click on a Project in the Solution Explorer will create a preview build of the assembly in question and deploy it to a local NuGet repository on your machine. This preview package will include the debug symbols and since it's built on the same machine it will allow you to step into the code and make sure it's behaving as expected. The aim is to make working with interdependent NuGet packages faster and easier.

## Setup

In order to use the preview generator you'll need to create a local Nuget Repository, this is far easier than it sounds, it's simply a folder on your computer somewhere for putting *.nupkg* files. 

To add a new source:
1. Create a folder on the file system to be your NuGet repository 
2. In Visual Studio go to **Tools** &gt; **Options** to open the options pages. From the list of options choose **Nuget Package Manager** &gt; **Package Sources** and add your new folder through the UI

Once you've added your new source, the next stage is to configure the *Nuget Preview Generator* to use that source, to do this:

1. Go to **Tools** &gt; **Options** pages. Choose **Nuget Package Manager** &gt; **Nuget Preview Generator** to open the Preview Generator options page.
2. On the options page, change the **Local Nuget Repository Folder** to your newly created folder.

## Generating the Preview

Once you've configured Preview Generator, 

