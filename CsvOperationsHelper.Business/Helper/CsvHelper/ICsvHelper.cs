using System.Collections.Generic;
using CsvHelper.Configuration;

namespace CsvOperationsHelper.Business.Helper.CsvHelper
{
    public interface ICsvHelper<T> where T : class
    {
        /// <summary>
        /// Csv Oluşturmayı sağlar
        /// </summary>
        /// <param name="result"> CSV'ye yazılacak veri </param>
        /// <param name="filePath">Dosya yolu</param>
        /// <param name="fileName">Dosya İsmi</param>
        /// <param name="nonHeader">CSV'ye veri yazarken Modele göre Başlık(porperty nameleri) hariç tutulur Default false</param>
        /// <param name="map">Özel olarak Maplenmiş özellikleri ifade eder. Default Null (Null geçilebilir.Mapleme uygulanmaz)</param>
        /// <returns>Belirtilen dosya yoluna .csv uznatılı doya oluşturur </returns>
        bool CreateCsv(IEnumerable<T> result, string filePath, string fileName, bool nonHeader = false, ClassMap map = null);
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
        bool CreateCsv(IEnumerable<T> result, string filePath, string fileName, bool deleteExitFile = false, bool nonHeader = false, ClassMap map = null);
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
        bool CreateCsv(IEnumerable<T> result, string filePath, string fileName, bool excelSeparator, bool deleteExitFile = false, bool nonHeader = false, ClassMap map = null);
        /// <summary>
        /// Csv Okuma
        /// </summary>
        /// <param name="filePath">Dosya yolu</param>
        /// <param name="map">Özel olarak Maplenmiş özellikleri ifade eder. Default Null (Null geçilebilir.Mapleme uygulanmaz) </param>
        /// <returns>CSV'den okunmuş değerleri döner</returns>
        IEnumerable<T> ReadCsv(string filePath, ClassMap map = null);
    }
}
