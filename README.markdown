### About Draco RegexTest for Windows

Draco RegexTest is a regular expression testing developer tool aimed at heavy regular expression crafting. To help increase workflow, regular expressions may be stored and accessed quickly for re-use and combining. Other shortcuts include grabbing text from the source with auto-escaped characters and common replacements, un-escaping escape sequences, and inserting favorite clips into the current working text.

Source written in C# using Visual Studio 2013 for Windows Desktop.


### Working Feature List

* Checkmark select active regular expression
* working text box is multi-line, auto single-line on checkmarked
* add working text box contents to stored data table using plus button
* double-click table row header to insert into working text box
* edit table entry regular expression or title text inline
* table auto-saves on changes to working file (XML)
* editable source text box
* fetch URL replaces source text box
* results appear in table
* Edit menu features
* * Grab Source Selection (CTL+G) copies selection from source, auto-escapes characters with common regex replacements, and pastes into working text box.
* * strip escaped escapes from working text. useful after pasting expression from source code
* * escape escapes in workext text. useful before pasting into source code
* search source text
* highlight matches in source text
* drop-down selection matches with list of capture names to limit results table

### Suggested Features

* add File menu to load/save/add lists of other favorite regular expressions
* add more common error warnings to pre-check
* color syntax for regular expression strings
* parenthesis matching in working text box
* time-out for regular expression work
* sort list of regular expressions by column
