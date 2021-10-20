using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IFilter FilterTwitter = new FilterTwitter();
            IFilter FilterSave = new FilterSavePicture();
            IFilter FilterNegative = new FilterNegative();
            IFilter FilterGreyscale = new FilterGreyscale();

            IPipe PipeNull = new PipeNull();
            IPipe PipeGuardar4 = new PipeSerial(FilterSave, PipeNull);

            IPipe PipeTwitter3 = new PipeSerial(FilterTwitter, PipeGuardar4);
            IPipe PipeGuardar3 = new PipeSerial(FilterSave, PipeTwitter3);
            IPipe PipeSerial2 = new PipeSerial(FilterNegative, PipeGuardar3);

            IPipe PipeTwitter2 = new PipeSerial(FilterTwitter, PipeSerial2);
            IPipe PipeGuardar2 = new PipeSerial(FilterSave, PipeTwitter2);
            IPipe PipeSerial1 = new PipeSerial(FilterGreyscale, PipeGuardar2);

            IPipe PipeTwitter1 = new PipeSerial(FilterTwitter, PipeSerial1);
            IPipe PipeGuardar1 = new PipeSerial(FilterSave, PipeTwitter1);

            picture = PipeGuardar1.Send(picture);
        }
    }
}
