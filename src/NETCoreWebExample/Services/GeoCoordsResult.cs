namespace NETCoreWebExample.Services
{
    public class GeoCoordsResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public double Longitutde { get; set; }
        public double Latitude { get; set; }
    }
}