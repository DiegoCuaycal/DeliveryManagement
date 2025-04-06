using System.Text;
using System;
using Newtonsoft.Json;

namespace Delivery.ConsumeAPI
{
    public static class Crud<T>
    {

        public static async Task<T?> Create(string apiUrl, T data)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                );

                var json = JsonConvert.SerializeObject(data);
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al crear: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    return default;
                }

                json = await response.Content.ReadAsStringAsync();
                return json != null ? JsonConvert.DeserializeObject<T>(json) : default;
            }
        }



        public static async Task<T[]> Read_All(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    return json != null ? JsonConvert.DeserializeObject<T[]>(json) ?? new T[0] : new T[0]; // Devuelve un array vacío si es null
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la petición: {ex.Message}");
                return new T[0]; // Devuelve un array vacío en caso de error
            }
        }


        /*
        public static T[] Read_All(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetStringAsync(apiUrl);
                response.Wait();

                var json = response.Result;
                var result = JsonConvert.DeserializeObject<T[]>(json);
                return result;
            }
        }
        */

        public static async Task<T?> Read_ById(string apiUrl, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                apiUrl = $"{apiUrl}/{id}";
                var response = await client.GetAsync(apiUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return default; // Retorna null si la API no responde correctamente
                }
                var json = await response.Content.ReadAsStringAsync();
                return json != null ? JsonConvert.DeserializeObject<T>(json) : default;
            }
        }




        public static bool Update(string apiUrl, int id, T data)
        {
            using (HttpClient client = new HttpClient())
            {
                apiUrl = $"{apiUrl}/{id}";
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Add(
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json")
                );

                var json = JsonConvert.SerializeObject(data);
                var request = new HttpRequestMessage(HttpMethod.Put, apiUrl)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                var response = client.SendAsync(request);
                response.Wait();

                if (!response.Result.IsSuccessStatusCode)
                {
                    return false; // Fallo en la actualización
                }

                return true; // Éxito en la actualización
            }
        }


        public static bool Delete(string apiUrl, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                apiUrl = $"{apiUrl}/{id}";
                var response = client.DeleteAsync(apiUrl);
                response.Wait();

                if (!response.Result.IsSuccessStatusCode)
                {
                    return false; // Fallo en la eliminación
                }

                return true; // Éxito en la eliminación
            }
        }





    }
}
