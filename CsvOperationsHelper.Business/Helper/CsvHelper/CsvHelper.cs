using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;

namespace CsvOperationsHelper.Business.Helper.CsvHelper
{
    /// <summary>
    /// Csv İşlemleri
    /// </summary>
    public class CsvHelper<T> : ICsvHelper<T> where T : class
    {
        public readonly List<string> ErrorList = new List<string>();

        private readonly ILogger<CsvHelper<T>> _logger;

        public CsvHelper(ILogger<CsvHelper<T>> logger) => _logger = logger;

        /// <summary>
        /// Csv Oluşturmayı sağlar
        /// </summary>
        /// <param name="result"> CSV'ye yazılacak veri </param>
        /// <param name="filePath">Dosya yolu</param>
        /// <param name="fileName">Dosya İsmi</param>
        /// <param name="nonHeader">CSV'ye veri yazarken Modele göre Başlık(porperty nameleri) hariç tutulur Default false</param>
        /// <param name="map">Özel olarak Maplenmiş özellikleri ifade eder. Default Null (Null geçilebilir.Mapleme uygulanmaz)</param>
        /// <returns>Belirtilen dosya yoluna .csv uznatılı doya oluşturur </returns>
        public bool CreateCsv(IEnumerable<T> result, string filePath, string fileName, bool nonHeader = false, ClassMap map = null)
        {
            try
            {
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

                var filePathCombine = $"{filePath}/{fileName}.csv";

                using (var fileStream = new FileStream(filePathCombine, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            if (map != null) csv.Configuration.RegisterClassMap(map);

                            if (nonHeader) csv.Configuration.HasHeaderRecord = false;
                            else
                            {
                                csv.WriteHeader(typeof(T));
                                csv.NextRecord();
                            }

                            csv.WriteRecords(result);

                            csv.Flush();
                            writer.Flush();
                            fileStream.Flush();
                            writer.Close();
                            fileStream.Close();
                            csv.Dispose();
                        }
                    }
                }

                return File.Exists(filePathCombine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ErrorList.Add(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Csv Oluşturmayı sağlar
        /// </summary>
        /// <param name="result"> CSV'ye yazılacak veri </param>
        /// <param name="filePath">Dosya yolu</param>
        /// <param name="fileName">Dosya İsmi</param>
        /// <param name="deleteExitFile">Var olan dosyanın silinmesi Default False </param>
        /// <param name="nonHeader">CSV'ye veri yazarken Modele göre Başlık(porperty nameleri) hariç tutulur Default false</param>
        /// <param name="map">Özel olarak Maplenmiş özellikleri ifade eder. Default Null (Null geçilebilir.Mapleme uygulanmaz)</param>
        /// <returns>Belirtilen dosya yoluna .csv uznatılı doya oluşturur </returns>
        public bool CreateCsv(IEnumerable<T> result, string filePath, string fileName, bool deleteExitFile = false, bool nonHeader = false, ClassMap map = null)
        {
            try
            {
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

                var filePathCombine = $"{filePath}/{fileName}.csv";

                if (deleteExitFile)
                    if (File.Exists(filePathCombine)) File.Delete(filePathCombine);

                using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            if (map != null) csv.Configuration.RegisterClassMap(map);

                            if (nonHeader) csv.Configuration.HasHeaderRecord = false;
                            else
                            {
                                csv.WriteHeader(typeof(T));
                                csv.NextRecord();
                            }

                            csv.WriteRecords(result);

                            csv.Flush();
                            writer.Flush();
                            fileStream.Flush();
                            writer.Close();
                            fileStream.Close();
                            csv.Dispose();
                        }
                    }
                }

                return File.Exists(filePathCombine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ErrorList.Add(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Csv Oluşturmayı sağlar
        /// </summary>
        /// <param name="result"> CSV'ye yazılacak veri </param>
        /// <param name="filePath">Dosya yolu</param>
        /// <param name="fileName">Csv Dosya ismi</param>
        /// <param name="excelSeparator">Excel Hücre yapısına uygun olarak oluştur</param>
        /// <param name="deleteExitFile">Var olan dosyanın silinmesi Default False </param>
        /// <param name="nonHeader">CSV'ye veri yazarken Modele göre Başlık(porperty nameleri) hariç tutulur Default false</param>
        /// <param name="map">Özel olarak Maplenmiş özellikleri ifade eder. Default Null (Null geçilebilir.Mapleme uygulanmaz)</param>
        /// <returns>Belirtilen dosya yoluna .csv uznatılı doya oluşturur </returns>
        public bool CreateCsv(IEnumerable<T> result, string filePath, string fileName, bool excelSeparator, bool deleteExitFile = false, bool nonHeader = false, ClassMap map = null)
        {
            try
            {
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

                var filePathCombine = $"{filePath}/{fileName}.csv";

                if (deleteExitFile)
                    if (File.Exists(filePathCombine)) File.Delete(filePathCombine);

                using (var fileStream = new FileStream(filePathCombine, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (var writer = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            if (map != null) csv.Configuration.RegisterClassMap(map);

                            if (excelSeparator)
                            {
                                csv.WriteField("sep=,", false);
                                csv.NextRecord();
                            }

                            if (nonHeader) csv.Configuration.HasHeaderRecord = false;
                            else
                            {
                                csv.WriteHeader(typeof(T));
                                csv.NextRecord();
                            }

                            csv.WriteRecords(result);

                            csv.Flush();
                            writer.Flush();
                            fileStream.Flush();
                        }
                    }
                }

                return File.Exists(filePathCombine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ErrorList.Add(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Csv Okuma
        /// </summary>
        /// <param name="filePath">Dosya yolu</param>
        /// <param name="map">Özel olarak Maplenmiş özellikleri ifade eder. Default Null (Null geçilebilir.Mapleme uygulanmaz) </param>
        /// <returns>CSV'den okunmuş değerleri döner</returns>
        public IEnumerable<T> ReadCsv(string filePath, ClassMap map = null)
        {
            try
            {
                if (!File.Exists(filePath)) ErrorList.Add($"No File Available.");

                using (var reader = new StreamReader(filePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        if (map != null) csv.Configuration.RegisterClassMap(map);

                        var file = File.ReadAllLines(filePath).Select(line => line.Split(',')).ToArray();
                        if (file[0][0] == "sep=") //Excel Separator varsa bunu atlaması için aksi taktirde hata verecektir.
                            for (var i = 0; i < 1; i++) csv.Read();

                        var result = csv.GetRecords<T>().ToList();

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                ErrorList.Add(ex.Message);
            }
            return null;
        }
    }
}
