### About Draco RegexTest for Windows

Draco RegexTest is a regular expression testing developer tool aimed at heavy regular expression crafting. To help increase workflow, regular expressions may be stored and accessed quickly for re-use and combining. Other shortcuts include grabbing text from the source with auto-escaped characters and common replacements, un-escaping escape sequences, and inserting favorite clips into the current working text.

Source written in C# using Visual Studio 2013 for Windows Desktop.


### Working Feature List

* Checkmark active regular expression
* working text box is multi-line, auto single-line on checkmark
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

### To-Do Feature List

* add File menu to load/save/add lists of other favorite regular expressions
* finish Grab Source Selection feature with common replacements
* add more common error warnings to pre-check
* highlight matches in source text
* search source text
* color syntax for regular expression strings
* paranthesis matching in working text box
* remove stored regular expression
* re-work checked regular expression on source text change
* time-out for regular expression work
* enable drop-down matches with list of capture names to limit results table
* sort list of regular expressions by column