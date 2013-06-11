# BugTracking

This BugTracking tool helps you keep track of source code files and blocks of lines that involve a particular variable.
Each file together with its blocks of lines form an entry in the report.
The Add/Remove/Preview button will allow you to add/remove/preview an entry.
The format of a block is either {start line} or {start line}-{end line}. Blocks are separated by { ';', ' ', ',', '.', ':', '\t' }
For example: 1168,1338-1340,1347-1352,1358-1362 is a collection of 4 blocks. Block 1 contains only one line of 1168. Block 2 contains lines 1338 to 1340, and so on...
The Save button will put all entries together and save the result into a report file (.txt file)