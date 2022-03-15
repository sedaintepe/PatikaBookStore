using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PatikaBookStoreWebapi.Middlewares{
    public class CustomExceptionMiddleware{
        private readonly RequestDelegate _next;
      public CustomExceptionMiddleware(RequestDelegate next){
            _next=next;
      }

      public async Task Invoke(HttpContext context)
      {
          var watch=Stopwatch.StartNew();
          try
          {
                string message="[Request] HTTP "+context.Request.Method+"- "+context.Request.Path;
          Console.WriteLine(message);
         // watch.Stop();
          await _next(context);
          message="[Request] HTTP "+context.Request.Method+"- "+context.Request.Path+" responded "+ context.Response.StatusCode+" in "+watch.Elapsed.TotalMilliseconds+ " ms ";
          Console.WriteLine(message);
          }
           catch (Exception ex)
          {
                watch.Stop();
               await  HandleException(context,ex,watch);
              
          }
      }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType="application/json";
           context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

           string message="[Error] HTTP"+ context.Request.Method+ "-"+ context.Response.StatusCode+" ErrorMessage "+ex.Message+" in "+ watch.Elapsed.TotalMilliseconds+ " ms ";
           Console.WriteLine(message);
           
           var result=JsonConvert.SerializeObject(new {error=ex.Message},Formatting.None);
           return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension{ //yapılan http requestleri ekranda görürüz.
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder){
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}