using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna un bool que indica si la imagen tiene una cara o no.
    /// </summary>
    public class FilterCognitiveAPI : IFilterConditional
    {
        public bool Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(@"luke.jpg");
            return cog.FaceFound;  
        }
    }
}