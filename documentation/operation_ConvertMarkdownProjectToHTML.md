## LudoScribe - Convert markdown project to html

**Inputs**

* Path to the root folder of the project.
* Destination path for the output of the generated html.

**Output**

* A website with HTML files in the same folder structure as the input. The root folder will have an index.html file that will be the entry point to the project documentation. 

**Program steps**

1. Scan input root folder and builds up a list of filenames including their relative path from the input root folder. Build up the project data structure fully at this stage.
2. Iterate through the generated project data structure and write out html files in the same relative path strucutre as the input project.


**Project structure data types**

Document
* filename
* relative path

Project
* list \<Document\>
* name 
* meta

**Command line format**

**command** --convert_markdown_project_to_html

**required parameters**
* input path
* output path

