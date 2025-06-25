using Core.models;
using Core.Repository;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bll_Service.Services
{
    public class Services_Address : IServices_Address
    {
        private readonly IRepository_Address _repository_Address;
        public Services_Address(IRepository_Address repository_Address)
        {
            _repository_Address = repository_Address;
        }
        public Task<int> deleteAsync(int id)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<List<Address>> getAllAsync()
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<Address> getById(int id)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public async Task<int> postAsync(Address entity)
        {
            //DALקריאה לפונקציית הגישה ב
            return await _repository_Address.postAsync(entity);
        }

        public Task<int> updateAsync(Address entity)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        // החזרת כל הכתובות שנוספו בחודש האחרון
        public async Task<List<Address>> getLastMonthAsync()
        {
            var l = await _repository_Address.getAllAsync();
            DateTime lastMonth = DateTime.Today.AddMonths(-1);// חזרה בדיוק חודש אחורה
            return l.Where(a => a.Date >= lastMonth).ToList();
        }

        // החזרת 10 המקומות הקרובים אלי ביותר לפי מרחק אווירי 
        public async Task<List<Address>> getProtectedSpaseAsync(decimal lat, decimal lng, bool driving)
        {
            List<Address> l = await _repository_Address.getAllAsync();

           
            var lWithDistances = l.Select(a => (address: a,
                                               walkingTimeSec: CalculateDistanceInKm(lat, lng, a.Latitude, a.Longitude),
                                               drivingTimeSec: CalculateDistanceInKm(lat, lng, a.Latitude, a.Longitude)))
                                 .ToList();
            //רלוונטי רק אם אני עושה חישוב מרחק ע"י גוגל-במרחק אוירי אין הבדל..
            if (driving == true)
            {
                return SortByDriveTime(lWithDistances).Take(10).Select(t => t.address).ToList();
            }
            return SortByWalkingTime(lWithDistances).Take(10).Select(t => t.address).ToList();
        }

        // פונקציה לחישוב מרחק אווירי (Haversine) בק"מ בין שתי נקודות גיאוגרפיות
        private decimal CalculateDistanceInKm(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            const double R = 6371; // רדיוס כדור הארץ בק"מ

            // המרה ל-double לצורך שימוש בפונקציות מתמטיות
            double latRad1 = DegreesToRadians((double)lat1);
            double latRad2 = DegreesToRadians((double)lat2);
            double deltaLat = DegreesToRadians((double)(lat2 - lat1));
            double deltaLon = DegreesToRadians((double)(lon2 - lon1));

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(latRad1) * Math.Cos(latRad2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c;

            return (decimal)distance;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
        
        // מיון עפ"י רגלי 
        public List<(Address address, decimal walkingTimeSec, decimal drivingTimeSec)>
        SortByWalkingTime(List<(Address address, decimal walkingTimeSec, decimal drivingTimeSec)> laddresses)
        {
            return laddresses.OrderBy(item => item.walkingTimeSec).ToList();
        }

        // מיון עפ"י נסיעה ברכב 
        public List<(Address address, decimal walkingTimeSec, decimal drivingTimeSec)>
        SortByDriveTime(List<(Address address, decimal walkingTimeSec, decimal drivingTimeSec)> laddresses)
        {
            return laddresses.OrderBy(item => item.drivingTimeSec).ToList();
        }





        //פונקציה הבודקת אם התז היא תז ישראלית
        public bool IsIsraeliIdValid(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return false;

            // הסרת רווחים ו-0 מובילים
            id = id.Trim().PadLeft(9, '0');

            if (!id.All(char.IsDigit) || id.Length != 9)
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int num = (id[i] - '0') * ((i % 2) + 1);
                if (num > 9)
                    num -= 9;
                sum += num;
            }

            return sum % 10 == 0;
        }


        
        // גוגל לא מאפשרים שימוש ללא הכנסת אמצעי תשלום
        // מחשבת מרחק עם התחשבות בכבישים אמוסים דרך מפותלת ולא רק אווירי..
        /*
        public async Task<List<(Address address, decimal walkingTimeSec, decimal drivingTimeSec)>>
        GetTravelTimesToAllAddressesAsync(List<Address> addresses, decimal originLat, decimal originLng)
        {
            var results = new List<(Address, decimal, decimal)>();

            using var client = new HttpClient();
            string apiKey = "AIzaSyAmVDk3IM1RiN1jIlZCNKWtt8xqLgLK41I";
            string origin = $"{originLat},{originLng}";

            foreach (var address in addresses)
            {
                string destination = $"{address.Latitude},{address.Longitude}";

                async Task<decimal> GetDuration(string mode)
                {
                    var url = $"https://maps.googleapis.com/maps/api/distancematrix/json?" +
                              $"origins={origin}&destinations={destination}&mode={mode}&key={apiKey}";

                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return -1;

                    var content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("========== DEBUG ==========");
                    Console.WriteLine("Mode: " + mode);
                    Console.WriteLine("Origin: " + origin);
                    Console.WriteLine("Destination: " + destination);
                    Console.WriteLine("Response:");
                    Console.WriteLine(content);
                    Console.WriteLine("===========================");

                    dynamic data = JsonConvert.DeserializeObject(content);

                    if (data?.rows == null || data.rows.Count == 0 ||
                        data.rows[0]?.elements == null || data.rows[0].elements.Count == 0)
                    {
                        return -1;
                    }

                    var status = data.rows[0].elements[0].status?.ToString();
                    if (status == "OK")
                    {
                        return (decimal?)(double?)data.rows[0].elements[0].duration?.value ?? -1;
                    }

                    return -1;
                }

                var walking = await GetDuration("walking");
                var driving = await GetDuration("driving");

                results.Add((address, walking, driving));
            }

            return results;
        }
        */
    }
}
