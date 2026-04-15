using System;

interface IReport
{
    void Generate();
}

class PdfReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Сгенерирован PDF-отчет");
    }
}

class ExcelReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Сгенерирован Excel-отчет");
    }
}

class WordReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Сгенерирован Word-отчет");
    }
}

abstract class ReportFactory
{
    public abstract IReport CreateReport();
}

class PdfReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new PdfReport();
    }
}

class ExcelReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new ExcelReport();
    }
}

class WordReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new WordReport();
    }
}

class Program
{
    static void Main()
    {
        ReportFactory pdfFactory = new PdfReportFactory();
        IReport pdfReport = pdfFactory.CreateReport();
        pdfReport.Generate();

        ReportFactory excelFactory = new ExcelReportFactory();
        IReport excelReport = excelFactory.CreateReport();
        excelReport.Generate();

        ReportFactory wordFactory = new WordReportFactory();
        IReport wordReport = wordFactory.CreateReport();
        wordReport.Generate();

        Console.ReadLine();
    }
}