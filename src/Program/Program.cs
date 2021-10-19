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

            IPipe pipenull = new PipeNull();

            IFilter filternegative = new FilterNegative();
            IPipe pipeserial2 = new PipeSerial(filternegative, pipenull);

            IFilter save = new FilterSavePicture();
            IPipe pipeserialguardar2 = new PipeSerial(save, pipeserial2);
            
            IFilter filtergreyscale = new FilterGreyscale();
            IPipe pipeserial1 = new PipeSerial(filtergreyscale, pipeserialguardar2);

            picture = pipeserial1.Send(picture);
        }
    }
}
