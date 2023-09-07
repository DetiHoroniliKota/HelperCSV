using Microsoft.VisualBasic.FileIO;

namespace HelperCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (TextFieldParser tfp = new TextFieldParser(@"C:\Users\Евгения\Desktop\лист отгрузки Озон\postings (52).csv"))
            {
                using (TextFieldParser tfp2 = new TextFieldParser(@"C:\Users\Евгения\Desktop\лист отгрузки Озон\Лист Microsoft Excel.csv"))
                {

                    tfp.TextFieldType = FieldType.Delimited;
                    tfp2.TextFieldType = FieldType.Delimited;

                    tfp.SetDelimiters(";");
                    tfp2.SetDelimiters(";");

                    List<string> selectionlist = new List<string>();
                    decimal selectionListSum = 0;
                    
                    while (!tfp.EndOfData)
                    {
                        string[] fields = tfp.ReadFields();
                        selectionlist.Add(fields[0]);
                        //selectionListSum += decimal.Parse(fields[6]); 
                        //Console.WriteLine(fields[0]);
                    }

                    List<string> report = new List<string>();
                    

                    while (!tfp2.EndOfData)
                    {
                        string[] fileds = tfp2.ReadFields();
                        report.Add(fileds[6].Substring(5,16));
                    }

                    var resalt = selectionlist.Except(report);

                    foreach (var item in report)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine(selectionListSum);
                }
            }
        }
    }
}