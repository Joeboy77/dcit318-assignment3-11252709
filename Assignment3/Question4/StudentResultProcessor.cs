using Assignment3.Question4.Exceptions;
using Assignment3.Question4.Models;

namespace Assignment3.Question4
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            List<Student> students = new List<Student>();
            int lineNumber = 0;

            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        string[] fields = line.Split(',');

                        if (fields.Length < 3)
                        {
                            throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields (ID, Name, Score), but found {fields.Length}. Line: '{line}'");
                        }

                        if (!int.TryParse(fields[0].Trim(), out int id))
                        {
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format. Value: '{fields[0].Trim()}'");
                        }

                        string fullName = fields[1].Trim();
                        if (string.IsNullOrWhiteSpace(fullName))
                        {
                            throw new MissingFieldException($"Line {lineNumber}: Full Name is missing. Line: '{line}'");
                        }

                        if (!int.TryParse(fields[2].Trim(), out int score))
                        {
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid score format. Value: '{fields[2].Trim()}'");
                        }

                        students.Add(new Student(id, fullName, score));
                    }
                    catch (InvalidScoreFormatException ex)
                    {
                        Console.WriteLine($"Warning: {ex.Message}");
                    }
                    catch (MissingFieldException ex)
                    {
                        Console.WriteLine($"Warning: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Warning: Line {lineNumber}: An unexpected error occurred while processing line: '{line}'. Error: {ex.Message}");
                    }
                }
            }
            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter sw = new StreamWriter(outputFilePath))
            {
                sw.WriteLine("Student Grading Report");
                sw.WriteLine();

                foreach (var student in students.OrderBy(s => s.Id))
                {
                    sw.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
                }
                sw.WriteLine($"Total valid students: {students.Count}");
            }
        }
    }
}
