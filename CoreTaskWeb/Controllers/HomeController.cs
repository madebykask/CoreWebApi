using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoreTaskWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private string _baseUri = "http://localhost:53923/api/TodoItems/";
        public async Task<IActionResult> Index()
        {
            List<TodoItem> todoitems = new List<TodoItem>();
            using (HttpClient httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.GetAsync(_baseUri);
                string apiResponse = await response.Content.ReadAsStringAsync();
                todoitems = JsonConvert.DeserializeObject<List<TodoItem>>(apiResponse);
            }
            return View(todoitems);
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public async Task<IActionResult> Edit(TodoItem item)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.GetAsync(_baseUri + item.Id);
                string apiResponse = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<TodoItem>(apiResponse);
            }
            return View("Edit", item);
        }
        public async Task<IActionResult> UpdateTodo(TodoItem item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.PutAsync(_baseUri + item.Id, httpContent);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateTodo(TodoItem item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.PostAsync(_baseUri, httpContent);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTodo(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.DeleteAsync(_baseUri + id);
            }
            return RedirectToAction("Index");
        }

    }
}
