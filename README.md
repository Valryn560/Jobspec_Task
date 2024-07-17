# Task from LEXACOM

First string:
> Today we saw 3 patients[[new-line]]The first was Name:Michael Michaelson NHS Number:333444[[New-Line]]the second was Name:Jane Bridge NHS NUmber:55666 with her son Name:David Bridge NHS Number:a44t55[[new-line]]We then saw[[new-line]]NHS Number:999 James McDonald[[new-line]][[new-line]]NHS Number:444
 
Second string:
>{[{"Name":"James Jamerson","NHSNumber":12345},{"Name":"Bob Sinclair","NHSNumber":5555},{"Name":"Sally Jamerson","NHSNumber":66554},{"Name":"Michael Myers","NHSNumber":6666},{"Name":"James Jamerson","NHSNumber":12345}]}


## Objectives

- Replace all instances of [[new-line]] with a new line character in the text transcription.
- Extract all instances of NHS Number: and Name: from the text transcription.
- Import and save files from GitHub, Dropbox, Google Drive and One Drive
- Create a table of all the names with their corresponding NHS numbers.

## Desired Result
![desired Result](https://i.ibb.co/YyN4rZj/Desired-Result.png)
## My Result
![output](https://i.ibb.co/pL8LGrb/output.png)
##### Please bare in mind
This is only the way its being displayed in console for my own readability, the table format is still exactly as specified.

## My take
Honestly this took me longer than requested, like 4 hours but thats only due to formatting the Strings themselves. Was constantly referring to Microsofts C# tech docs. Table creation and extracting data to populate table was easier. 

## Improvements
* Better way of formatting the content
* A function for every format sort of like an automated checklist (removed hash, removed colons etc..)
* Make the whole thing as modular as possible, some of the formatting felt a little hardcoded.