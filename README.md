# Search app

  The exercise is to write a command line driven text search engine, usage being:
  
  ***search.exe pathToDirectoryContainingTextFiles***
  
  This should read all the text files in the given directory, building an in memory representation of the files and their contents, and then give a command prompt at which interactive searches can be performed.

  An example session might look like:
  
  $ SearchWords.exe c:\text files\
  14 files read in directory c:\text files\
  
  search> dogs
  filename1 : 234 occurrences
  filename2 : 54 occurrences
  
  search> cats
  no matches found
  
  Treat the above as an outline spec; you don’t need to exactly reproduce the above output.
  The search should take the word given on the command prompt and return the top 10 file names where that word appears and the word counter.
  Don’t spend any time on input handling, just assume sane input.
  What we are going to evaluate:

- SOLID principles.
  - S: Single responsibility principle
  - O: Open/closed principle
  - L: Liskov substitution principle
  - I: Interface segregation principle
  - D: Dependency inversion principle
- Unit tests.
- Clean code.
- Usage of GIT.

## Deliverables:
- Code to implement a version of the above (link to github repository)
- A README containing instructions so that we know how to build and run your code

## Download source code
***git clone https://github.com/rsvidal/SearchApp.git***

## Unit tests
  The unit tests has been created using NUnit and Moq

## Build
  This application has been created using NET 6 (Microsoft.NETCore.app 6.0.8).
  You can use the following sentence to build this app:

***dotnet build SearchApp.csproj -c Release***

## Run
***SearchApp.exe C:/tmp/*** (or any directory in your computer)

## Git

  This project uses Git as source code repository

  ***Notes:*** For this example, I use a master branch and Github as remote repository (origin)
  
- Add files: git add . 
- Commit changes: git commit -m "comment"
- Upload changes to the remote repository (Github): git push origin master

## Notes
- files reading is executed into the loop to refresh this data (E.g. User creates, modifies or removes files while this app is running).
- File Last modified datetime is read to know if the file has changed and reload the information in cache memory
