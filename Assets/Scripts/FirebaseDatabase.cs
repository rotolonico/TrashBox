using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public static class FirebaseDatabase
    {
        private const string DatabaseURL = "https://trashbox-6d390-default-rtdb.europe-west1.firebasedatabase.app/";
    
        public static async Task<RequestResponse<T>> Get<T>(string path)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync($"{DatabaseURL}{path}.json");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseBody);
                    return new RequestResponse<T>(data);
                }
                catch (Exception e)
                {
                    return new RequestResponse<T>(e);
                }
            }

            return new RequestResponse<T>(
                new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}"));
        }
    
        public static async Task<RequestResponse<T>> Put<T>(string path, T dataObject)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(dataObject);
        
            using var client = new HttpClient();

            var response = await client.PutAsync($"{DatabaseURL}{path}.json", new StringContent(data));

            if (response.IsSuccessStatusCode)
                return new RequestResponse<T>(dataObject);

            return new RequestResponse<T>(
                new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}"));
        }
        
        public static async Task<RequestResponse<T>> Push<T>(string path, T dataObject)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(dataObject);
        
            using var client = new HttpClient();
 
            var response = await client.PostAsync($"{DatabaseURL}{path}.json", new StringContent(data));

            if (response.IsSuccessStatusCode)
                return new RequestResponse<T>(dataObject);

            return new RequestResponse<T>(
                new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}"));
        }
    }

public class RequestResponse<T>
{
    public T data;
    public bool isFaulted;
    public Exception error;
    
    public RequestResponse(T data)
    {
        this.data = data;
        isFaulted = false;
        error = null;
    }
    
    public RequestResponse(Exception error) => MakeFaulted(error);

    public void MakeFaulted(Exception error)
    {
        data = default;
        isFaulted = true;
        this.error = error;
    }
}