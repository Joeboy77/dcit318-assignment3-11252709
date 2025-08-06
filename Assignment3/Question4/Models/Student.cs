namespace Assignment3.Question4.Models
{
    public class Student
    {
        public int Id { get; }
        public string FullName { get; }
        public int Score { get; }

        public Student(int id, string fullName, int score)
        {
            Id = id;
            FullName = fullName;
            Score = score;
        }

        public string GetGrade()
        {
            if (Score >= 80 && Score <= 100)
                return "A";
            else if (Score >= 70 && Score <= 79)
                return "B";
            else if (Score >= 60 && Score <= 69)
                return "C";
            else if (Score >= 50 && Score <= 59)
                return "D";
            else if (Score >= 0 && Score < 50)
                return "F";
            else
                return "N/A (Invalid Score)";
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {FullName}, Score: {Score}, Grade: {GetGrade()}";
        }
    }
}