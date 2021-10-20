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
            IFilterConditional FilterConditional = new FilterCognitiveAPI();

            IPipe PipeNull = new PipeNull();

            //EJERCICIO 1, 2 y 3
            /*
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
            */


            //EJERCICIO 4
            IPipe Rama2PipeTwitter = new PipeSerial(FilterTwitter, PipeNull);
            IPipe Rama2PipeGuardar = new PipeSerial(FilterSave, Rama2PipeTwitter);
            IPipe Rama2Pipe1 = new PipeSerial(FilterGreyscale, Rama2PipeGuardar);

            IPipe Rama1PipeTwitter = new PipeSerial(FilterTwitter, PipeNull);
            IPipe Rama1PipeGuardar = new PipeSerial(FilterSave, Rama1PipeTwitter);
            IPipe Rama1Pipe1 = new PipeSerial(FilterNegative, Rama1PipeGuardar);

            IPipeConditionalFork PipeConditional = new PipeConditionalFork(FilterConditional, Rama1Pipe1, Rama2Pipe1);

            picture = PipeConditional.Send(picture);

        }
    }
}
