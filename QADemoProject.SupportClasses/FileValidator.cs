using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QADemoProject.SupportClasses
{

    //Not used in this demo , this is just file validator class

    public static class FileValidator
    {


        
        private static Dictionary<string, int> index = new Dictionary<string, int>();


        public static void Validator(string sourceFile, string destinationFile, string resultFile, string delimiter, List<string> removeColumns)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] filePaths = Directory.GetFiles(directoryPath, destinationFile);
            string[] File1Lines = File.ReadAllLines(sourceFile);
            string[] File2Lines = File.ReadAllLines(filePaths[0]);
            List<string> NewLines = new List<string>();
            string[] sourceHeaders = File1Lines[0].Split(delimiter);
            string[] destinationHeaders = File2Lines[0].Split(delimiter);

            if (sourceHeaders.Length == destinationHeaders.Length)
            {

                for (int headerindex = 0; headerindex < sourceHeaders.Length; headerindex++)
                {
                    if (!String.IsNullOrEmpty(sourceHeaders[headerindex]) && !String.IsNullOrEmpty(destinationHeaders[headerindex]) && !String.Equals(destinationHeaders[headerindex], ""))
                    {
                        if (String.Compare(sourceHeaders[headerindex], destinationHeaders[headerindex]) != 0)
                            NewLines.Add("Header Validation : Mismatch in Header--->" + " Column-Number:" + headerindex + " Expected-Value:" + sourceHeaders[headerindex] + " Actual-Value:" + destinationHeaders[headerindex]);
                        else
                            index.Add(destinationHeaders[headerindex], headerindex);

                    }
                    else if (!String.IsNullOrEmpty(sourceHeaders[headerindex]) && String.Equals(destinationHeaders[headerindex], ""))
                    {
                        NewLines.Add("Header Validation : Column is missing in header--->" + "Column-Number:" + headerindex + " Expected-Value:" + sourceHeaders[headerindex] + " Actual-Value:" + destinationHeaders[headerindex]);
                    }
                    else
                    {
                        NewLines.Add(destinationHeaders[headerindex]);
                    }
                }

            }
            else
            {
                foreach (String column in sourceHeaders)
                {


                    // go through all in second list
                    if (!destinationHeaders.Contains(column))
                    {
                        NewLines.Add("Header Validation : Column is missing in header--->" + column);
                        sourceHeaders = sourceHeaders.Where(s => s != column).ToArray();
                    }
                    else
                    {
                        index.Add(column, Array.IndexOf(destinationHeaders, column));
                    }
                }


            }

            if (NewLines.Count > 0)
            {
                File.WriteAllLines(resultFile, NewLines);
                ValidateTransactionDataInExtractFileWithHeaders(sourceFile, destinationFile, resultFile, delimiter, removeColumns);
            }
            else
            {
                NewLines.Add("Header Validation : All columns in headers are matching expected standard");
                File.WriteAllLines(resultFile, NewLines);
                ValidateTransactionDataInExtractFileWithHeaders(sourceFile, destinationFile, resultFile, delimiter, removeColumns);
            }
        }


        public static void ValidateTransactionDataInExtractFileWithoutHeaders(string sourceFile, string destinationFile, string resultFile, string delimiter, List<string> removeColumns)
        {
            string[] File1Lines = File.ReadAllLines(sourceFile);
            string[] File2Lines = File.ReadAllLines(destinationFile);
            List<string> NewLines = new List<string>();
            for (int row = 0; row < File1Lines.Length; row++)
            {
                string[] sourceHeaders = File1Lines[row].Split(delimiter);
                string[] destinationHeaders = File2Lines[row].Split(delimiter);

                for (int headerindex = 0; headerindex < sourceHeaders.Length; headerindex++)
                {
                    if (!String.IsNullOrEmpty(sourceHeaders[headerindex]) && !String.IsNullOrEmpty(destinationHeaders[headerindex]) && !String.Equals(destinationHeaders[headerindex], "") && !removeColumns.Contains(sourceHeaders[headerindex]))
                    {
                        if (String.Compare(sourceHeaders[headerindex], destinationHeaders[headerindex]) != 0)
                            NewLines.Add("Data Validation : Mismatch in Row Number--->" + row + " Column-Number:" + headerindex + " Expected-Value:" + sourceHeaders[headerindex] + " Actual-Value:" + destinationHeaders[headerindex]);

                    }

                }
            }
            if (NewLines.Count > 0)
            {
                File.WriteAllLines(resultFile, NewLines);
            }
            else
            {
                NewLines.Add("Data Validation : All data is matching expected standard");
                File.WriteAllLines(resultFile, NewLines);
            }

        }

        public static void ValidateTransactionDataInExtractFileWithHeaders(string sourceFile, string destinationFile, string resultFile, string delimiter, List<string> removeColumns)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] filePaths = Directory.GetFiles(directoryPath, destinationFile);
            string[] File1Lines = File.ReadAllLines(sourceFile);
            string[] File2Lines = File.ReadAllLines(filePaths[0]);
            List<string> NewLines = new List<string>();
            List<string> MissingLines = new List<string>();
            int counter = 0;
            string[] sourceHeadersRow = File1Lines[0].Split(delimiter);
            for (int row = 1; row < File1Lines.Length; row++)
            {
                counter = 0;
                for (int destinationindex = 1; destinationindex < File2Lines.Length; destinationindex++)
                {

                    string[] sourceHeaders = File1Lines[row].Split(delimiter);
                    string[] destinationHeaders = File2Lines[destinationindex].Split(delimiter);


                    if (sourceHeaders[0] == destinationHeaders[0])
                    {
                        counter += 1;
                        for (int headerindex = 0; headerindex < sourceHeaders.Length; headerindex++)
                        {

                            MissingLines.Remove(File1Lines[row]);
                            try
                            {
                                //if (!String.IsNullOrEmpty(sourceHeaders[headerindex]) && !String.IsNullOrEmpty(destinationHeaders[index[sourceHeaders[headerindex]]]) && !String.Equals(destinationHeaders[headerindex], ""))
                                if (!String.IsNullOrEmpty(sourceHeaders[headerindex]) && !String.IsNullOrEmpty(destinationHeaders[index[sourceHeadersRow[headerindex]]]) && !String.Equals(destinationHeaders[index[sourceHeadersRow[headerindex]]], "") && !removeColumns.Contains(sourceHeadersRow[headerindex]))

                                {
                                    if (String.Compare(sourceHeaders[headerindex], destinationHeaders[headerindex]) != 0)
                                        NewLines.Add("Data Validation : Mismatch in Row Number--->" + row + " Column-Number:" + headerindex + " Expected-Value:" + sourceHeaders[headerindex] + " Actual-Value:" + destinationHeaders[headerindex]);


                                }
                            }
                            catch (Exception ex)
                            {

                            }


                        }
                        break;
                    }




                }

                if (!MissingLines.Contains(File1Lines[row]) && counter == 0)
                {
                    MissingLines.Add("Data Validation : Missing Row--->" + File1Lines[row]);

                }
            }


            if (NewLines.Count > 0)
            {
                File.AppendAllLines(resultFile, NewLines);
                File.AppendAllLines(resultFile, MissingLines);
            }
            else
            {
                NewLines.Add("Data Validation : All data is matching expected standard");
                File.AppendAllLines(resultFile, NewLines);
                File.AppendAllLines(resultFile, MissingLines);
            }

        }

    }
}
