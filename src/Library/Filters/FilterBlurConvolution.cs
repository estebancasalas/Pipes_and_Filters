using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro de convolución que retorna la imagen recibida con los bordes suavizados. Basado en
    /// https://en.wikipedia.org/wiki/Box_blur utilizando el kernel
    /// https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
    /// Los metodos para obtener los valores de cada pixel los hereda de la clase Convoluter.
    /// </summary>
    public class FilterBlurConvolution : Convoluter , IFilter
    {
        protected int[,] kernel;
        protected int complement, divider;

        /// <summary>
        /// Inicializa una nueva instancia de <c>FilterBlurConvolution</c> asignando el kernel, complemento, y divisor
        /// según https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
        /// </summary>
        public FilterBlurConvolution()
        {
            this.kernel = new int[3, 3];
            this.complement = 0;
            this.divider = 9;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    kernel[x, y] = 1;
                }
            }
        }

        /// Procesa la imagen pasada por parametro mediante un kernel, y retorna la imagen resultante.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a plicar el filtro.</param>
        /// <returns>La imagen con el filtro aplicado.</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();
            Color[,] sample;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    sample = CreateSample(image, x, y);
                    result.SetColor(x, y, GetFilteredColor(sample, this.kernel, this.divider, this.complement));
                }
            }

            return result;
        }

        
    }
}