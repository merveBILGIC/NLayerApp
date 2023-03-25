using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }
        //herhangi bir class içerisinde static fonk üzerinden geriye newlwnmiş bir obje dönülüyorsa buna => !staticFactory! method denir.
        //FacctoryDesingPattern den gelir. geriye intanse dönülüyor.
        public static CustomResponseDto<T> Succes(int statusCode,T data)
        {
            return new CustomResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                Errors = null
            };
        }
        
        public static CustomResponseDto<T> Succes(int statusCode)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode
            };
        }
        public static CustomResponseDto<T> Fail(int statusCode,List<string> errors)
        {
            return new CustomResponseDto<T>
            {
               
                StatusCode = statusCode,
                Errors = errors
            };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string errors)
        {
            return new CustomResponseDto<T>
            {

                StatusCode = statusCode,
                Errors =new List<string> {errors}
            };
        }
    }
}
