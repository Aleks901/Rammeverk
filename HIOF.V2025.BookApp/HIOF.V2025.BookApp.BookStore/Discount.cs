using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIOF.V2025.BookApp.BookStore;

/// <summary>
/// En enkel verdi for hvor mye rabatt man skal kunne trekke fra verdien til et objekt. (Gavekort, Rabatt kode, Medlems rabatt, osv.)
/// </summary>
public readonly struct Discount
{
    /// <summary>
    /// Verdien som skal trekkes av den orginale prisen, dette kan være verdien på en kupong eller gavekort.
    /// <value>Value: decimal</value>
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// Når en kupong eller gavekort kode skal produseres vil den først sjekkes for om den er gyldig, altså ikke mindre enn 0.
    /// </summary>
    /// <param name="value">Verdien som skal trekkes fra orginal pris.</param>
    /// <exception cref="ArgumentOutOfRangeException">Kastes dersom verdien er ugyldig.</exception>
    public Discount(decimal value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    /// <summary>
    /// Trekker prisen til discount objektet av den orginale prisen til produktet.
    /// </summary>
    /// <param name="originalPrice">Den orginale prisen til produktet.</param>
    /// <returns>Ny verdi: decimal</returns>
    public decimal ApplyDiscount(decimal originalPrice) => Math.Max(0, originalPrice - Value);
}

