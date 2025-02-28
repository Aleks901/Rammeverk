using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIOF.V2025.BookApp.BookStore
{
    /// <summary>
    /// Bestemmer hvilke objekter som kan ha en discount.
    /// </summary>
    public interface IDiscountable
    {
        /// <summary>
        /// Putter en discount på et objekt.
        /// Det kan være alt fra en konstant discount som følge av medlems tilbud til gavekort kjøpt på en butikk.
        /// </summary>
        /// <param name="discount">Et Discount objekt (Altså en rabatt kode, Gavekort, osv.)</param>
        void ApplyDiscount(Discount discount);
    }
}
