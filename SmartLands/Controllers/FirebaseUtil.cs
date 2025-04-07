using Firebase.Database;
using Firebase.Database.Query;
using SmartLands.Models;
using System.Net.WebSockets;
namespace SmartLands.Controllers
{
    public class FirebaseUtil
    {        
        public FirebaseUtil() { }
        public List<LandLog> GetLogs() 
        {
            List<LandLog> logs = new List<LandLog>();

            var firebaseUrl = "https://smartlands-41ed0-default-rtdb.firebaseio.com/";
            var firebaseSecret = "qSeotfJyhP7yy12e9tARsFVPC4u9PIApkiEoh6Ay"; 

            var client = new FirebaseClient(
                firebaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseSecret)
                });

            var data = client
                .Child("/logs") // thay bằng node chứa dữ liệu của bạn
                .OnceSingleAsync<Dictionary<string, int>>();

            var logsData = data.Result
                .Select(kvp => new LandLog
                {
                    Date = kvp.Key,
                    Value = kvp.Value
                })
                .ToList();
            logsData = logsData.OrderByDescending(x => x.Date).Take<LandLog>(10).ToList();

            //string[] dates = logsData.Select(item => item.Date).ToArray();
            //int[] values = logsData.Select(item => item.Value).ToArray();
            //// Chuyển đổi mảng thành chuỗi JSON
            //string jsonDates = Newtonsoft.Json.JsonConvert.SerializeObject(dates);
            //string jsonValues = Newtonsoft.Json.JsonConvert.SerializeObject(values);


            return logsData;
        }
    }
}
