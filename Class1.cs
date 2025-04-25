using System;
using System.IO;

namespace POMFramework
{
    public static class ReportManager
    {
        private static readonly string ReportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestExecutionReport.txt");

        public static void InitializeReport()
        {
            File.WriteAllText(ReportFilePath, "Test Execution Report\n====================\n\n");
        }

        public static void LogTestResult(string testName, string status, string message = "")
        {
            var logEntry = $"[{DateTime.Now}] Test: {testName} | Status: {status} | Message: {message}\n";
            File.AppendAllText(ReportFilePath, logEntry);
        }

        public static string GetReportFilePath()
        {
            return ReportFilePath;
        }
    }

    public class Class1
    {

    }
}
