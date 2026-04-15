using System;

class Report
{
    public string Title;
    public string Content;
    public string Footer;

    public void Show()
    {
        Console.WriteLine("Заголовок: " + Title);
        Console.WriteLine("Содержимое: " + Content);
        Console.WriteLine("Подвал: " + Footer);
    }
}

// интерфейс строителя
interface IReportBuilder
{
    void BuildTitle();
    void BuildContent();
    void BuildFooter();
    Report GetReport();
}

// PDF-строитель
class PDFReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void BuildTitle()
    {
        report.Title = "PDF отчет";
    }

    public void BuildContent()
    {
        report.Content = "Содержимое PDF файла";
    }

    public void BuildFooter()
    {
        report.Footer = "PDF footer";
    }

    public Report GetReport()
    {
        return report;
    }
}

// Word-строитель
class WordReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void BuildTitle()
    {
        report.Title = "Word отчет";
    }

    public void BuildContent()
    {
        report.Content = "Содержимое Word документа";
    }

    public void BuildFooter()
    {
        report.Footer = "Word footer";
    }

    public Report GetReport()
    {
        return report;
    }
}

// Excel-строитель
class ExcelReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void BuildTitle()
    {
        report.Title = "Excel отчет";
    }

    public void BuildContent()
    {
        report.Content = "Содержимое Excel таблицы";
    }

    public void BuildFooter()
    {
        report.Footer = "Excel footer";
    }

    public Report GetReport()
    {
        return report;
    }
}

// директор
class ReportDirector
{
    public void Construct(IReportBuilder builder)
    {
        builder.BuildTitle();
        builder.BuildContent();
        builder.BuildFooter();
    }
}

class Program
{
    static void Main()
    {
        ReportDirector director = new ReportDirector();

        IReportBuilder pdfBuilder = new PDFReportBuilder();
        director.Construct(pdfBuilder);
        Report pdfReport = pdfBuilder.GetReport();

        Console.WriteLine("PDF отчет:");
        pdfReport.Show();

        Console.WriteLine();

        IReportBuilder wordBuilder = new WordReportBuilder();
        director.Construct(wordBuilder);
        Report wordReport = wordBuilder.GetReport();

        Console.WriteLine("Word отчет:");
        wordReport.Show();

        Console.WriteLine();

        IReportBuilder excelBuilder = new ExcelReportBuilder();
        director.Construct(excelBuilder);
        Report excelReport = excelBuilder.GetReport();

        Console.WriteLine("Excel отчет:");
        excelReport.Show();

        Console.ReadLine();
    }
}