using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment FirstClass = new Assignment((string)"Nathaniel", (string)"Introduction");
        FirstClass.GetSummary();

        
        MathAssignment MathClass = new MathAssignment((string)"Nathaniel", (string)"Multivariable Vectors", (string)"Chapter 14", (string)"1-13");
        MathClass.GetSummary();
        MathClass.DisplayHomeworkList();

        WritingAssignment WritingClass = new WritingAssignment((string)"Nathaniel", (string)"Multivariable Vectors", (string)"What was buried in your backyard");
        WritingClass.GetSummary();
        WritingClass.DisplayWritingInformation();

    }
}