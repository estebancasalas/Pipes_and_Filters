using System;
namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipeConditionalFork
    {
        IPipe next1Pipe;
        IPipe next2Pipe;
        IFilterConditional filtro;
        public PipeConditionalFork(IFilterConditional filtro, IPipe next1Pipe, IPipe next2Pipe)
        {
            this.next1Pipe = next1Pipe;
            this.next2Pipe = next2Pipe;
            this.filtro = filtro;
        }
        public IPicture Send(IPicture image)
        {
            if (this.filtro.Filter(image))
            {
                return this.next1Pipe.Send(image);
            }
            else
            {
                return this.next2Pipe.Send(image);
            }
            
        }
    }
}