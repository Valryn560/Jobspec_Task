using System.Data;
using System.Text.RegularExpressions;

// lets get cleaner data on strings using replace.
string first_String = "Today we saw 3 patients[[new-line]]The first was Name:Michael Michaelson NHS Number:333444[[New-Line]]the second was Name:Jane Bridge NHS Number:55666 with her son Name:David Bridge NHS Number:a44t55[[new-line]]We then saw[[new-line]]NHS Number:999 James McDonald[[new-line]][[new-line]]NHS Number:444";

string removelast2NL_first_String = Regex.Replace(first_String, @"\[\[new-line\]\]\[\[new-line\]\]", " ", RegexOptions.IgnoreCase);
string first_String_removenl = Regex.Replace(removelast2NL_first_String, @"\[\[new-line\]\]", "\n", RegexOptions.IgnoreCase);
string first_String_remove_colons = Regex.Replace(first_String_removenl, @":", ": ");
string first_String_remove_misplacement = Regex.Replace(first_String_remove_colons, @"NHS Number: 999", "Name:", RegexOptions.IgnoreCase);
string cleaned_first_String = Regex.Replace(first_String_remove_misplacement, @" 444", " 999444");

// Below is tackling second string, trim method seemed to work well for some of the characters
string second_string = "[{\"Name\":\"James Jamerson\",\"NHSNumber\":12345},{\"Name\":\"Bob Sinclair\",\"NHSNumber\":5555},{\"Name\":\"Sally Jamerson\",\"NHSNumber\":66554},{\"Name\":\"Michael Myers\",\"NHSNumber\":6666},{\"Name\":\"James Jamerson\",\"NHSNumber\":12345}]";
string second_String_first_stage = second_string.Trim( new Char[]{'{','[', '"', '}', ']',}) ; //note '"' worked for characters between but not all

// I have to remove "},{" so im going to use replace again same goes for ","
string cleaned_second_String_second_stage = Regex.Replace(second_String_first_stage, "},{", "", RegexOptions.IgnoreCase);
string cleaned_second_String_third_stage = Regex.Replace(cleaned_second_String_second_stage, ",", "\n", RegexOptions.IgnoreCase);
string cleaned_second_String = cleaned_second_String_third_stage.Replace("\"", "").Replace("Name:", " Name:").Replace("NHSNumber:", " NHS Number:");

// Then concatenate the two strings
string Final_String = cleaned_first_String + cleaned_second_String;

// Create the table & populate columns with appropriate datatypes
 DataTable table = new DataTable();
             table.Columns.Add("Name", typeof(string));
             table.Columns.Add("NHS Number", typeof(string));

 // Regular expressions to match the pattern of Name and NHS Number
 string pattern = @"Name: (?<name>[^N]+)NHS Number: (?<nhs>[^\s]+)";
 string pattern_two = @"Name:(?<name>[\w\s]+?)\s+NHS Number:(?<nhs>\d+)";
 
 // Use Regex to find matches
 MatchCollection matches = Regex.Matches(Final_String, pattern);
 MatchCollection matches2 = Regex.Matches(Final_String, pattern_two);

 // Using a for loop to find matches 
 foreach (Match match in matches)
         {
             string name = match.Groups["name"].Value.Trim();
             string nhsNumber = match.Groups["nhs"].Value.Trim();
 
             // Add the extracted values to the DataTable
             table.Rows.Add(name, nhsNumber);
         } 
 foreach (Match match in matches2)
         {
             string name = match.Groups["name"].Value.Trim();
             string nhsNumber = match.Groups["nhs"].Value.Trim();
 
             // Add the extracted values to the DataTable
             table.Rows.Add(name, nhsNumber);
         }      
// Display the table
      foreach (DataRow row in table.Rows)
      {
          Console.WriteLine($"Name: {row["Name"]} NHS Number: {row["NHS Number"]}");
      }